using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Adapters
{
    public class CommandLineAdapter : ISettingsAdapter
    {
        private readonly Dictionary<string, object> _data;

        public CommandLineAdapter(IEnumerable<string> args, IDictionary<string, string> switchMappings = null)
        {
            Args = args;
            var mappings = switchMappings == null
                ? null
                : GetValidatedSwitchMappingsCopy(switchMappings);

            _data = Load(args, mappings);
        }

        public IEnumerable<string> Args { get; }

        public object this[string name]
        {
            get { return _data[name]; }
            set
            {
                new InvalidOperationException($"Reading values is not supported by the {nameof(CommandLineAdapter)}");
            }
        }

        public bool CanRead(string name)
        {
            return _data.ContainsKey(name);
        }

        public bool CanWrite(string name)
        {
            return false;
        }

        private static Dictionary<string, string> GetValidatedSwitchMappingsCopy(IDictionary<string, string> switchMappings)
        {
            // The dictionary passed in might be constructed with a case-sensitive comparer
            // However, the keys in configuration providers are all case-insensitive
            // So we check whether the given switch mappings contain duplicated keys with case-insensitive comparer
            var switchMappingsCopy = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var mapping in switchMappings)
            {
                // Only keys start with "--" or "-" are acceptable
                if (!mapping.Key.StartsWith("-") && !mapping.Key.StartsWith("--"))
                {
                    throw new ArgumentException(
                        $"Invalid switch: {mapping.Key}",
                        nameof(switchMappings));
                }

                if (switchMappingsCopy.ContainsKey(mapping.Key))
                {
                    throw new ArgumentException(
                        $"Duplicated key in switch {mapping.Key}",
                        nameof(switchMappings));
                }

                switchMappingsCopy.Add(mapping.Key, mapping.Value);
            }

            return switchMappingsCopy;
        }

        /// <summary>
        /// Loads the configuration data from the command line args.
        /// </summary>
        /// <remarks>
        /// Stolen from the Asp.Net Configuration
        /// https://github.com/aspnet/Configuration/commit/dc6fbde39f532bf154ee1eb02d8be08a0a1605e4
        /// </remarks>
        private static Dictionary<string, object> Load(IEnumerable<string> args, IDictionary<string, string> switchMappings)
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            string key, value;

            using (var enumerator = args.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var currentArg = enumerator.Current;
                    var keyStartIndex = 0;

                    if (currentArg.StartsWith("--"))
                    {
                        keyStartIndex = 2;
                    }
                    else if (currentArg.StartsWith("-"))
                    {
                        keyStartIndex = 1;
                    }
                    else if (currentArg.StartsWith("/"))
                    {
                        // "/SomeSwitch" is equivalent to "--SomeSwitch" when interpreting switch mappings
                        // So we do a conversion to simplify later processing
                        currentArg = string.Format("--{0}", currentArg.Substring(1));
                        keyStartIndex = 2;
                    }

                    var separator = currentArg.IndexOf('=');

                    if (separator < 0)
                    {
                        // If there is neither equal sign nor prefix in current arugment, it is an invalid format
                        if (keyStartIndex == 0)
                        {
                            throw new FormatException($"Unrecognized argument {currentArg}");
                        }

                        // If the switch is a key in given switch mappings, interpret it
                        if (switchMappings != null && switchMappings.ContainsKey(currentArg))
                        {
                            key = switchMappings[currentArg];
                        }
                        // If the switch starts with a single "-" and it isn't in given mappings , it is an invalid usage
                        else if (keyStartIndex == 1)
                        {
                            throw new FormatException($"Short switch not defined for {currentArg}");
                        }
                        // Otherwise, use the switch name directly as a key
                        else
                        {
                            key = currentArg.Substring(keyStartIndex);
                        }

                        var previousKey = enumerator.Current;
                        if (!enumerator.MoveNext())
                        {
                            throw new FormatException($"Value is missing for {previousKey}");
                        }

                        value = enumerator.Current;
                    }
                    else
                    {
                        var keySegment = currentArg.Substring(0, separator);

                        // If the switch is a key in given switch mappings, interpret it
                        if (switchMappings != null && switchMappings.ContainsKey(keySegment))
                        {
                            key = switchMappings[keySegment];
                        }
                        // If the switch starts with a single "-" and it isn't in given mappings , it is an invalid usage
                        else if (keyStartIndex == 1)
                        {
                            throw new FormatException($"Short switch not defined for {currentArg}");
                        }
                        // Otherwise, use the switch name directly as a key
                        else
                        {
                            key = currentArg.Substring(keyStartIndex, separator - keyStartIndex);
                        }

                        value = currentArg.Substring(separator + 1);
                    }

                    // Override value when key is duplicated. So we always have the last argument win.
                    data[key] = value;
                }
            }
            return data;
        }
    }
}