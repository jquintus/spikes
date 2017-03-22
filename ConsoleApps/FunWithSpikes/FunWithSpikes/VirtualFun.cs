using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithSpikes
{
    public static class VirtualFun
    {
        public static void Run()
        {
            var timer = new Stopwatch();
            const int count = 100_000_000;

            var test = new TestClass();

            for (int i = 0; i < 4; i++)
            {
                TimeIt("static   ", count, () => TestClass.StaticMethod());
                TimeIt("interface", count, () => test.InterfaceMethod());
                TimeIt("abstract ", count, () => test.AbstractMethod());
                TimeIt("virtual  ", count, () => test.VirtualMethod());
                TimeIt("sealed   ", count, () => test.SealedMethod());
                Console.WriteLine();
            }
            // Sample output:
            //static    - 335
            //interface - 266
            //abstract  - 509
            //virtual   - 400
            //sealed    - 315

            //static    - 275
            //interface - 270
            //abstract  - 370
            //virtual   - 395
            //sealed    - 226

            //static    - 262
            //interface - 279
            //abstract  - 395
            //virtual   - 365
            //sealed    - 283

            //static    - 234
            //interface - 275
            //abstract  - 377
            //virtual   - 429
            //sealed    - 227
        }

        private static void TimeIt(string name, int count, Action action)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine($"{name} - {sw.ElapsedMilliseconds}");
        }

        public interface ISomething
        {
            void InterfaceMethod();
        }

        public abstract class BaseClass
        {
            public abstract void AbstractMethod();
        }
        public class TestClass : BaseClass, ISomething
        {
            public void InterfaceMethod() { }
            public override void AbstractMethod() { }
            public static void StaticMethod() { }
            public virtual void VirtualMethod() { }
            public void SealedMethod() { }
        }
    }
}
