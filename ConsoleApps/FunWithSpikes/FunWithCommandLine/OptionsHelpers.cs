using System;

namespace FunWithCommandLine
{
    public static class OptionsHelpers
    {
        public static T Parse<T>(params string[] args) where T : new()
        {
            var options = new T();
            Parse(options, args);
            return options;
        }

        public static T Parse<T>(T options, params string[] args)
        {
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                throw new Exception("could not parse args");
            }

            return options;
        }
    }
}