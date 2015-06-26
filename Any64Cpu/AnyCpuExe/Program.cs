using AnyCpuDll;
using System;
using System.Reflection;

namespace AnyCpuExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var asm = Assembly.GetEntryAssembly();
            PortableExecutableKinds peKind;
            ImageFileMachine imageFileMachine;

            asm.ManifestModule.GetPEKind(out peKind, out imageFileMachine);
            var someClass = new SomeClass();


            Console.WriteLine("{0} {1} {2}", asm.ManifestModule.Name, imageFileMachine, SomeClass.DllInfo);
        }
    }
}