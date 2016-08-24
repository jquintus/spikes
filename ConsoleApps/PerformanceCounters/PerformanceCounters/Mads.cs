using System.Diagnostics;

namespace PerformanceCounters
{
    /// <summary>
    /// A helper class to create the specified performance counters.
    /// http://madskristensen.net/post/create-performance-counters-using-net-and-c
    /// </summary>
    public class PerfmormanceMonitor
    {
        private string _category = string.Empty;

        private CounterCreationDataCollection _counters = new CounterCreationDataCollection();

        /// <summary>
        /// Creates an instance of the class.
        /// </summary>
        /// <param name="categoryName">The name of the performance counter category.</param>
        public PerfmormanceMonitor(string categoryName)
        {
            _category = categoryName;
        }

        /// <summary>
        /// Add a performance counter to the category of performance counters.
        /// </summary>
        public void AddCounter(string name, string helpText, PerformanceCounterType type)
        {
            CounterCreationData ccd = new CounterCreationData();
            ccd.CounterName = name;
            ccd.CounterHelp = helpText;
            ccd.CounterType = type;
            _counters.Add(ccd);
        }

        /// <summary>
        /// Creates the performance counters
        /// </summary>
        public void CreateCounters()
        {
            if (!PerformanceCounterCategory.Exists(_category))
            {
                PerformanceCounterCategory.Create(_category, _category, PerformanceCounterCategoryType.Unknown, _counters);
            }
        }
    }
}
