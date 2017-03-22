using System;
using System.Diagnostics;

namespace FunWithSpikes
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            VirtualFun.Run();

            if (Debugger.IsAttached)
            {
                Console.Write("Press any key to continue . . .");
                Console.ReadKey();
            }

        }
    }
}