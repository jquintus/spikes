using FunWithSQLite.Workers;
using System;
using System.Diagnostics;

namespace FunWithSQLite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new BackupWorker().Work();

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
            }
        }
    }
}