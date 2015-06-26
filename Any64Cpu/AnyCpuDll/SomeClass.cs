using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnyCpuDll
{
    public class SomeClass
    {
        static SomeClass()
        {
            Assembly asm = typeof(SomeClass).Assembly;

            PortableExecutableKinds peKind;
            ImageFileMachine imageFileMachine;

            asm.ManifestModule.GetPEKind(out peKind, out imageFileMachine);

            DllInfo = "DLL built with" + imageFileMachine;
        }

        public static string DllInfo { get; set; }
    }
}
