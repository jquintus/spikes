using System;
using System.Linq;
using System.Management;

namespace Wmi
{
    public static class Utils
    {
        public static double BytesToGigs(ManagementObject queryObj, string column)
        {
            var totalPhysicalMemoryString = queryObj[column];
            var totalPhysicalMemory = Convert.ToDouble(totalPhysicalMemoryString);
            var totalPhysicalGigs = Math.Round(totalPhysicalMemory / 1024 / 1024 / 1024, digits: 2);
            return totalPhysicalGigs;
        }

        public static void DumpAllPropertiesForClass(string queryClass, string root = @"Root\CIMV2")
        {
            using (var searcher = new ManagementObjectSearcher(root, $"SELECT * FROM {queryClass}"))
            {
                foreach (var queryObj in searcher.Get().OfType<ManagementObject>())
                {
                    foreach (var prop in queryObj.Properties)
                    {
                        Console.WriteLine($"{queryClass}\\{prop.Name}: {prop.Value}");
                    }
                }
            }
        }
    }
}