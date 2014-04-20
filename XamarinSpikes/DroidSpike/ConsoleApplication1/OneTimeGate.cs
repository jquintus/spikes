using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class ManualResetEventSlimExtensions
    {
        public static async Task WaitAsync(this ManualResetEventSlim mre)
        {
            Task waitForIt = new Task(() => mre.Wait());
            waitForIt.Start();
            await waitForIt;
        }
    }

    public class MRE : ManualResetEventSlim
    {
        //private ManualResetEventSlim mre;

        public MRE()
        {
            //mre = new ManualResetEventSlim();
        }

        //public void Reset()
        //{
        //    mre.Reset();
        //}

        //public void Set()
        //{
        //    mre.Set();
        //}

        public async Task WaitAsync()
        {
            Task waitForIt = new Task(() => Wait());
            waitForIt.Start();
            await waitForIt;
        }
    }

    public class OneTimeGate
    {
        private readonly ManualResetEventSlim _mre;

        private SemaphoreSlim _semaphore;

        public OneTimeGate()
        {
            _mre = new ManualResetEventSlim();
            _semaphore = new SemaphoreSlim(0, 1);
        }

        public void Set()
        {
            _semaphore.Release();
        }

        public async Task WaitAsync()
        {
            Console.WriteLine("Current Count:  " + _semaphore.CurrentCount);
            if (_semaphore.CurrentCount > 0)
            {
                Console.WriteLine("Not waiting in line");
                return;
            }

            await _semaphore.WaitAsync();
            _semaphore.Release();
        }
    }
}