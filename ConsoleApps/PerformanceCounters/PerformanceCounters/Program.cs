using System;
using System.Diagnostics;
using System.Linq;

namespace PerformanceCounters
{
    public class Program
    {
        public static readonly string _animalsCounterName = "# of animals";
        private static readonly string _dogsCounterName = "# of dogs";
        private static readonly string _entersCounterName = "# of enters";
        private static readonly PerfmormanceMonitor _mon = new PerfmormanceMonitor(".DotAlign-Single", ".DotAlign-Multi");

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello world");

                if (args.FirstOrDefault() == "-d")
                {
                    _mon.DeleteCounters();
                }
                else
                {
                    CreatePerformanceCounter();
                    Run();
                }
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

        private static void ClearCounter(PerformanceCounter counter)
        {
            counter.IncrementBy(-1 * counter.RawValue);
        }

        private static void CreatePerformanceCounter()
        {
            // This needs to be run as an administrator
            _mon.AddCounter(_entersCounterName, "Total number of times enter is hit", PerformanceCounterType.NumberOfItems64);
            _mon.AddCounter(_dogsCounterName, "Total number of times user types in 'dog'", PerformanceCounterType.NumberOfItems64);
            _mon.AddCounter(_animalsCounterName, "Total number of times user types in 'cat'", PerformanceCounterType.NumberOfItems64);
            _mon.CreateCounters();
        }

        private static void Run()
        {
            ShowInstructions();

            var enterCounter = _mon.GetCounter(_entersCounterName);
            var dogCounter = _mon.GetCounter(_dogsCounterName);

            //ClearCounter(dogCounter);
            //ClearCounter(enterCounter);

            var input = "";
            while (input.ToLower() != "exit")
            {
                input = Console.ReadLine().Trim().ToLower();
                var isAnimal = false;

                switch (input)
                {
                    case "dog":
                        dogCounter.Increment();
                        isAnimal = true;
                        break;

                    case "cat":
                        isAnimal = true;
                        dogCounter.Decrement();
                        break;

                    case "duck":
                    case "worm":
                    case "bear":
                    case "horse":
                        isAnimal = true;
                        break;

                    case "clear":
                        ClearCounter(dogCounter);
                        ClearCounter(enterCounter);
                        break;

                    default:
                        break;
                }

                if (isAnimal)
                {
                    using (var animal = _mon.CreateCounter(_animalsCounterName, input))
                    {
                        animal.Increment();
                    }
                }

                enterCounter.Increment();
            }
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("Type 'dog' to increase the count of dogs");
            Console.WriteLine("Type 'cat' to decrease the count of dogs");
            Console.WriteLine("Type 'clear' to reset the enter and the dog counters");
        }
    }
}