using System;
using System.Reflection;

namespace x86Dll
{
    public class Class86
    {
        public static void GetInfo()
        {
            GetAsmInfo(typeof(Class86).Assembly);
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