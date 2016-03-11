using System;
using System.IO;
using System.Reflection;

namespace ConsoleApplication
{
    /// <summary>
    /// stackoverflow.com/questions/108971/using-side-by-side-assemblies-to-load-the-x64-or-x32-version-of-a-dll
    /// </summary>
    public static class MultiPlatformDllLoader
    {
        private static readonly object _lock = new object();
        private static bool _isEnabled;

        public static bool Enable
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                lock (_lock)
                {
                    if (_isEnabled != value)
                    {
                        if (value)
                            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
                        else
                            AppDomain.CurrentDomain.AssemblyResolve -= Resolver;
                        _isEnabled = value;
                    }
                }
            }
        }

        public static bool Is64BitProcess { get; set; } = Environment.Is64BitProcess;

        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            /// Attempt to load missing assembly from either x86 or x64 sub directory

            var basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var platformFolder = Is64BitProcess ? "x64" : "x86";
            string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
            var archSpecificPath = Path.Combine(basePath, platformFolder, assemblyName);

            if (!File.Exists(archSpecificPath))
            {
                archSpecificPath = Path.Combine(basePath, platformFolder, "Dynamic." + assemblyName);
            }

            Assembly asm = null;

            if (File.Exists(archSpecificPath))
            {
                Console.WriteLine($"Loading assembly {archSpecificPath}");
                asm = Assembly.LoadFile(archSpecificPath);
            }
            else
            {
                Console.WriteLine($"Could not find assembly {args.Name}");
            }

            return asm;
        }
    }
}