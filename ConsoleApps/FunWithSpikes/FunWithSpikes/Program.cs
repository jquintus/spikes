using System;

namespace FunWithSpikes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Foo foo = new Foo();

            //Disposable.FunWithDisposable();

            Foo f = new Foo().WithValue("what");

            Console.WriteLine(f.Value);
        }
    }
}