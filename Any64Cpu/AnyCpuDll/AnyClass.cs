using System;
using System.Reflection;

namespace AnyCpuDll
{
    public class AnyClass
    {
        public static void Access64BitDll()
        {
            Console.WriteLine();
            Console.WriteLine("Accessing 64 bit DLL in AnyCPU class");
            _64BitDll.Class64.GetInfo();
        }

        public static void Access86BitDll()
        {
            Console.WriteLine();
            Console.WriteLine("Accessing 64 bit DLL in AnyCPU class");
            x86Dll.Class86.GetInfo();
        }

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