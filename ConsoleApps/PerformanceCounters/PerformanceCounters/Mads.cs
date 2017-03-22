using System.Diagnostics;

namespace PerformanceCounters
{
    /// <summary>
    /// A helper class to create the specified performance counters.
    /// http://madskristensen.net/post/create-performance-counters-using-net-and-c
    /// </summary>
    public class PerfmormanceMonitor
    {
        private readonly string _categoryMultiInstance = string.Empty;
        private readonly string _categorySingleInstance = string.Empty;
        private readonly CounterCreationDataCollection _countersMultiInstance;
        private readonly CounterCreationDataCollection _countersSingleInstance;

        /// <summary>
        /// Creates an instance of the class.
        /// </summary>
        /// <param name="categoryNameSingleInstance">The name of the performance counter category.</param>
        public PerfmormanceMonitor(string categoryNameSingleInstance, string categoryMultiInstance)
        {
            _categorySingleInstance = categoryNameSingleInstance;
            _categoryMultiInstance = categoryMultiInstance;

            _countersSingleInstance = new CounterCreationDataCollection();
            _countersMultiInstance = new CounterCreationDataCollection();

            AddCounter(Program._animalsCounterName, "Number of instances", PerformanceCounterType.NumberOfItems32, _countersMultiInstance);
        }

        /// <summary>
        /// Add a performance counter to the category of performance counters.
        /// </summary>
        public void AddCounter(string name, string helpText, PerformanceCounterType type)
        {
            AddCounter(name, helpText, type, _countersSingleInstance);
        }

        public PerformanceCounter CreateCounter(string name, string instanceName)
        {
            return new PerformanceCounter
            {
                CategoryName = _categoryMultiInstance,
                CounterName = name,
                MachineName = ".",
                ReadOnly = false,
                InstanceName = instanceName,
                InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
            };
        }

        /// <summary>
        /// Creates the performance counters
        /// </summary>
        public void CreateCounters()
        {
            if (!PerformanceCounterCategory.Exists(_categorySingleInstance))
            {
                PerformanceCounterCategory.Create(_categorySingleInstance, _categorySingleInstance, PerformanceCounterCategoryType.SingleInstance, _countersSingleInstance);
            }

            if (!PerformanceCounterCategory.Exists(_categoryMultiInstance))
            {
                PerformanceCounterCategory.Create(_categoryMultiInstance, _categoryMultiInstance, PerformanceCounterCategoryType.MultiInstance, _countersMultiInstance);
            }
        }

        public void DeleteCounters()
        {
            if (PerformanceCounterCategory.Exists(_categorySingleInstance))
            {
                PerformanceCounterCategory.Delete(_categorySingleInstance);
            }

            if (PerformanceCounterCategory.Exists(_categoryMultiInstance))
            {
                PerformanceCounterCategory.Delete(_categoryMultiInstance);
            }
        }

        public PerformanceCounter GetCounter(string name)
        {
            return new PerformanceCounter
            {
                CategoryName = _categorySingleInstance,
                CounterName = name,
                MachineName = ".",
                ReadOnly = false,
                InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
            };
        }

        private void AddCounter(string name, string helpText, PerformanceCounterType type, CounterCreationDataCollection counters)
        {
            CounterCreationData ccd = new CounterCreationData
            {
                CounterName = name,
                CounterHelp = helpText,
                CounterType = type,
            };

            counters.Add(ccd);
        }
    }
}