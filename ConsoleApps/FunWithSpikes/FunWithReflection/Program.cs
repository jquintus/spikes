using FunWithInternals;
using System;
using System.Linq;
using System.Reflection;

namespace FunWithReflection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Get the internal class
            var internalAsm = typeof(MyPublicClass).Assembly;  // We are using MyPublicClass just to easily get a handle on the assembly.  The assembly could be loaded many other ways.
            var internalClass = internalAsm.GetTypes().Where(t => t.Name.Contains("Internal")).First();

            // Get the internal ctor and methods on the class
            var ctor = internalClass.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var method = internalClass.GetMethod("MyInternalMethod", BindingFlags.NonPublic | BindingFlags.Instance);


            // Invoke the ctor and internal method
            var instance = ctor.Invoke(new object[0]);

            Console.WriteLine(instance);

            method.Invoke(instance, new object[0]);
        }
    }
}