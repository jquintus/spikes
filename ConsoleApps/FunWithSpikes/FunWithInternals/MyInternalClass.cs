using System;

namespace FunWithInternals
{
    internal class MyInternalClass
    {
        internal MyInternalClass()
        {
        }

        public override string ToString()
        {
            return "I'm so internal";
        }

        internal void MyInternalMethod()
        {
            Console.WriteLine("Hello World");
        }
    }
}