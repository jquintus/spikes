using System;
using System.Reflection;

namespace AnyCpuDll
{
    public class AnyClass
    {
        public static void GetInfo(Assembly entryAsm)
        {
            GetAsmInfo(entryAsm);
            GetAsmInfo(typeof(AnyClass).Assembly);
        }

        private static void GetAsmInfo(Assembly asm)
        {
            PortableExecutableKinds peKind;
            ImageFileMachine imageFileMachine;

            asm.ManifestModule.GetPEKind(out peKind, out imageFileMachine);
            Console.WriteLine("{0} {1}", asm.ManifestModule.Name, imageFileMachine);
        }
    }
}