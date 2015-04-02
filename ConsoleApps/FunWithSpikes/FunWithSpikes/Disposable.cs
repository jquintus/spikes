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
                d = null;
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}