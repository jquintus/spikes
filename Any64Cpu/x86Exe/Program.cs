using AnyCpuDll;
using System;
using System.Reflection;

namespace x86Exe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SomeClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());
        }
    }
}