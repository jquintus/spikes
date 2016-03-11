using Intermediary;
using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //File.Delete("PlatformSpecific.dll");

                MultiPlatformDllLoader.Enable = true;

                Console.WriteLine(Class1.DiggingDeep);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nope");
                Console.WriteLine(ex);
            }
        }
    }
}