using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));


            Console.WriteLine(Path.Combine(@"C:\folder", @"folder2"));

            Console.ReadLine();

        }
    }
}
