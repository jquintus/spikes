using AnyCpuDll;
using System;
using System.Reflection;

namespace AnyCpuExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SomeClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());
        }
    }
}