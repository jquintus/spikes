using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FunWithSpikes
{
    public static class VirtualFun
    {
        public static void Run()
        {
            const int count = 100000000;
            var dict = CreateDataDictionary();

            TimeAll(count, dict);
            PrintResults(dict);

            // Results
            //             Run 1   Run 2   Run 3   Run 4   Run 5   Total               % Delta
            //    Static    1113     743     855     839     946    4496                0.00 %
            // Interface    1264     882    1067    1180    1012    5405               20.22 %
            //    Sealed     954    1027    1105    1110     926    5122               13.92 %
            //  Abstract    1267    1148    1105    1344    1009    5873               30.63 %
            //   Virtual    1227    1174    1200    1389    1065    6055               34.68 %
        }

        private static Dictionary<string, List<long>> CreateDataDictionary()
        {
            return new Dictionary<string, List<long>>
            {
                { "Static", new List<long>() },
                { "Interface", new List<long>() },
                { "Sealed", new List<long>() },
                { "Abstract", new List<long>() },
                { "Virtual", new List<long>() },
            };
        }

        private static void PrintResults(Dictionary<string, List<long>> dict)
        {
            var staticTotalMs = dict["Static"].Sum();
            PrintResultsHeader(dict["Static"].Count);
            foreach (var kvp in dict)
            {
                PrintResults(kvp, staticTotalMs);
            }
        }

        private static void PrintResults(KeyValuePair<string, List<long>> kvp, double staticTotalMs)
        {
            var total = kvp.Value.Sum();
            var percentDelta = staticTotalMs == 0
                ? 0
                : (total - staticTotalMs) / staticTotalMs;

            var sb = new StringBuilder();
            sb.Append($"{kvp.Key,10}");

            foreach (var item in kvp.Value)
            {
                sb.AppendFormat("{0,8}", item);
            }

            sb.AppendFormat("{0,8}", total);
            sb.AppendFormat("{0,22:P2}", percentDelta);

            Console.WriteLine(sb);
        }

        private static void PrintResultsHeader(int count)
        {
            var sb = new StringBuilder();
            sb.Append($"{"",12}");

            for (int i = 0; i < count; i++)
            {
                sb.AppendFormat("{0,8}", $"Run {i + 1}");
            }

            sb.AppendFormat("{0,8}", "Total");
            sb.AppendFormat("{0,20}", "% Delta");

            Console.WriteLine(sb);
        }

        private static long TimeAbstract(int count, BaseClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.AbstractMethod();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static void TimeAll(int count, Dictionary<string, List<long>> dict)
        {
            var test = new TestClass();
            for (int i = 0; i < 5; i++)
            {
                dict["Static"].Add(TimeStatic(count));
                dict["Interface"].Add(TimeInterface(count, test));
                dict["Abstract"].Add(TimeAbstract(count, test));
                dict["Virtual"].Add(TimeVirtual(count, test));
                dict["Sealed"].Add(TimeSealed(count, test));
            }
        }

        private static long TimeInterface(int count, ISomething test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.InterfaceMethod();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static long TimeSealed(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.SealedMethod();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static long TimeStatic(int count)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                TestClass.StaticMethod();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static long TimeVirtual(int count, TestClass test)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                test.VirtualMethod();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
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

        #endregion Nested Classes
    }
}