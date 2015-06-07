using log4net.Config;
using System;
using System.IO;

namespace FunWithLogs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            Console.WriteLine(Path.Combine(@"C:\folder", @"folder2"));

            Console.ReadLine();
        }
    }
}