using Intermediary;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CheckEnvironment();

                MultiPlatformDllLoader.Enable = true;

                Console.WriteLine(Class1.DiggingDeep);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nope");
                Console.WriteLine(ex);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to quit");
                Console.ReadKey();
            }
        }

        private static void CheckEnvironment()
        {
            var dllName = "PlatformSpecific.dll";
            if (File.Exists(dllName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{dllName} exists (it shouldn't). Deleting it...");
                File.Delete(dllName);
            }

            if (Environment.Is64BitProcess)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Process Type:  x64");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Process Type:  x86");
            }

            if (!File.Exists($"x64\\{dllName}"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not find x64 dll");
            }

            if (!File.Exists($"x86\\{dllName}"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not find x86 dll");
            }
            Console.ResetColor();
        }
    }
}