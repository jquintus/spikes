using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FunWithBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(Md5VsSha256),
                typeof(VirtualFun),
            });
            switcher.Run(args);


            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
            }
        }
    }
}
