using System;
using System.Diagnostics;

namespace PerformanceCounters
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello world");
                CreatePerformanceCounter();

                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (Debugger.IsAttached) throw;
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press Enter to finish");
                Console.ReadLine();
            }
            Console.WriteLine("Goodbye world");
        }

        private static void Run()
        {
            Console.WriteLine("Type 'dog' to increase the count of dogs");
            Console.WriteLine("Type 'cat' to decrease the count of dogs");
            Console.WriteLine("Type 'clear' to reset the enter and the dog counters");

            var enterCounter = new PerformanceCounter
            {
                CategoryName = "DotAlign",
                CounterName = "# of enters",
                MachineName = ".",
                ReadOnly = false,
            };

            var dogCounter = new PerformanceCounter
            {
                CategoryName = "DotAlign",
                CounterName = "# of dogs",
                MachineName = ".",
                ReadOnly = false,
            };
            ClearCounter(dogCounter);
            ClearCounter(enterCounter);


            var input = "";
            while (input.ToLower() != "exit")
            {
                input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "dog":
                        dogCounter.Increment();
                        break;
                    case "cat":
                        dogCounter.Decrement();
                        break;
                    case "clear":
                        ClearCounter(dogCounter);
                        ClearCounter(enterCounter);
                        break;
                    default:
                        break;
                }

                enterCounter.Increment();
            }
        }

        private static void ClearCounter(PerformanceCounter dogCounter)
        {
            dogCounter.IncrementBy(-1 * dogCounter.RawValue);
        }

        private static void CreatePerformanceCounterFromMads()
        {
            PerfmormanceMonitor mon = new PerfmormanceMonitor("Headlight Parser");
            mon.AddCounter("# operations executed", "Total number of executed commands", PerformanceCounterType.NumberOfItems64);
            mon.AddCounter("# logfiles parsed", "Total number of logfiles parsed", PerformanceCounterType.NumberOfItems64);
            mon.AddCounter("# operations / sec", "Number of operations executed per second", PerformanceCounterType.RateOfCountsPerSecond32);
            mon.AddCounter("average time per operation", "Average duration per operation execution", PerformanceCounterType.AverageTimer32);
            mon.AddCounter("average time per operation base", "Average duration per operation execution base", PerformanceCounterType.AverageBase);
            mon.CreateCounters();
        }

        private static void CreatePerformanceCounter()
        {
            // This needs to be run as an administrator
            PerfmormanceMonitor mon = new PerfmormanceMonitor("DotAlign");
            mon.AddCounter("# of enters", "Total number of times enter is hit", PerformanceCounterType.NumberOfItems64);
            mon.AddCounter("# of dogs", "Total number of times user types in 'dog'", PerformanceCounterType.NumberOfItems64);
            mon.CreateCounters();
        }


        private static void MsdnSample()
        {
            // Create a collection of type CounterCreationDataCollection.
            CounterCreationDataCollection CounterDatas = new CounterCreationDataCollection();

            // Create the counters and set their properties.
            var cdCounter1 = new CounterCreationData
            {
                CounterName = "Counter1",
                CounterHelp = "help string1",
                CounterType = PerformanceCounterType.NumberOfItems64,
            };

            var cdCounter2 = new CounterCreationData
            {
                CounterName = "Counter2",
                CounterHelp = "help string 2",
                CounterType = PerformanceCounterType.NumberOfItems64,
            };

            // Add both counters to the collection.
            CounterDatas.Add(cdCounter1);
            CounterDatas.Add(cdCounter2);

            // Create the category and pass the collection to it.
            PerformanceCounterCategory.Create(
                "Multi Counter Category", "Category help",
                PerformanceCounterCategoryType.SingleInstance, CounterDatas);
        }
    }
}