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

            Console.WriteLine("{0} {1}", asm.ManifestModule.Name, imageFileMachine);
        }
    }
}