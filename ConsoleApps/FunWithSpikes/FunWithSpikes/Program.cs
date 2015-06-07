using System;

namespace FunWithSpikes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Disposable.FunWithDisposable();

            Foo f = new Foo().WithValue("what");

            Console.WriteLine(f.Value);
        }
    }
}