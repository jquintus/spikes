using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        public static int _isLoaded;
        static void Main(string[] args)
        {

            //FunWithCompareAndSwap();
            //FunWithMRE();


            FunWithContinuation();

            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        private static void FunWithContinuation()
        {
            Task task = SimpleTask();
            task.ContinueWith(t =>
            {
                if (t.IsCompleted)
                {
                    Console.WriteLine("    Happy");
                }
                else
                {
                    Console.WriteLine("sad");
                }
            });

            Console.WriteLine("  all done");
            //task.Start();
            //task.Wait();
            //await task;
        }

        private static async Task SimpleTask()
        {
            CW(" Creating SimpleTask");
            await Task.Delay(10);

            //TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            //tcs.SetResult(true);

            //await tcs.Task;

            //await new Task(() => CW("Awaited Task Started"));
            CW("   Simple task created");
        }

        private static void FunWithMRE()
        {
            ManualResetEventSlim mre = new ManualResetEventSlim();
            //MRE mre = new MRE();
            mre.WaitAsync().ContinueWith(t => CW("Wait 1 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 2 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 3 complete"));

            WaitUntilKey("set");

            mre.Set();

            mre.WaitAsync().ContinueWith(t => CW("Wait 4 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 5 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 6 complete"));



            //WaitUntilKey("reset");
            mre.Reset();

            mre.WaitAsync().ContinueWith(t => CW("Wait 7 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 8 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 9 complete"));

            WaitUntilKey("set again");

            mre.Set();

        }

        public static void WaitUntilKey(string key)
        {
            key = key.Trim().ToLower();
            Console.WriteLine("Type <{0}> to continue", key);
            string input = null;

            while (input != key)
            {
                input = Console.ReadLine().Trim().ToLower();
            }
        }

        private static void FunWithOneTimeGate()
        {
            OneTimeGate mre = new OneTimeGate();
            mre.WaitAsync().ContinueWith(t => CW("Wait 1 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 2 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 3 complete"));

            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

            mre.Set();

            mre.WaitAsync().ContinueWith(t => CW("Wait 4 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 5 complete"));
            mre.WaitAsync().ContinueWith(t => CW("Wait 6 complete"));


            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

        }

        public static void CW(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void FunWithCompareAndSwap()
        {
            Load();
            Load();
            Load();
            Load();
            Load();
        }




        public static void Load()
        {

            Console.WriteLine("I'm doing a compare and swap");
            int rv = Interlocked.CompareExchange(ref _isLoaded, 1, 0);

            bool isLoaded = rv == 1;


            Console.WriteLine("_IsLoaded = {0};RV = {1};  isLoaded = {2}", _isLoaded, rv, isLoaded);
            if (isLoaded)
            {
                Console.WriteLine("                          Nope");
                return;
            }
            Console.WriteLine("Yes");
        }

    }
}
