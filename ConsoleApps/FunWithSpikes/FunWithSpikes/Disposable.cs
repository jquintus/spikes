using System;

namespace FunWithSpikes
{
    public class Disposable : IDisposable
    {
        public static void FunWithDisposable()
        {
            var d = new Disposable();
            using (d)
            {
#pragma warning disable 0728
                d = null;
#pragma warning restore 0728
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}