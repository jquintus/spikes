using System;
using System.Diagnostics;

namespace FunWithSpikes
{
    public static class VirtualFun
    {
        public static void Run()
        {
            const int count = 100_000_000;

            var test = new TestClass();

            for (int i = 0; i < 4; i++)
            {
                TimeStatic(count);
                TimeInterface(count, test);
                TimeAbstract(count, test);
                TimeVirtual(count, test);
                TimeSealed(count, test);
                Console.WriteLine();
            }

            // Results
            //             Run 1   Run 2   Run 3   Run 4
            // Static    :  47      32      33      38
            // Interface :  37      32      32      33
            // Sealed    :  32      32      37      34
            // Abstract  : 183     168     164     171
            // Virtual   : 239     189     223     200
        }

        private static void TimeAbstract(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.AbstractMethod();
            }
            sw.Stop();
            Console.WriteLine($"abstract  : {sw.ElapsedMilliseconds}");
        }

        private static void TimeInterface(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.InterfaceMethod();
            }
            sw.Stop();
            Console.WriteLine($"interface : {sw.ElapsedMilliseconds}");
        }

        private static void TimeSealed(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.SealedMethod();
            }
            sw.Stop();
            Console.WriteLine($"sealed    : {sw.ElapsedMilliseconds}");
        }

        private static void TimeStatic(int count)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                TestClass.StaticMethod();
            }
            sw.Stop();
            Console.WriteLine($"static    : {sw.ElapsedMilliseconds}");
        }

        private static void TimeVirtual(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.VirtualMethod();
            }
            sw.Stop();
            Console.WriteLine($"virtual   : {sw.ElapsedMilliseconds}");
        }

        #region Nested Classes

        private interface ISomething
        {
            void InterfaceMethod();
        }

        public abstract class BaseClass
        {
            public abstract void AbstractMethod();
        }

        public class TestClass : BaseClass, ISomething
        {
            public static void StaticMethod()
            {
            }

            public override void AbstractMethod()
            {
            }

            public void InterfaceMethod()
            {
            }

            public void SealedMethod()
            {
            }

            public virtual void VirtualMethod()
            {
            }
        }

        #endregion
    }
}