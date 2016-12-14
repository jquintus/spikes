using System;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace Wmi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WMI Code Creator v1.0
            // https://www.microsoft.com/en-us/download/confirmation.aspx?id=8572

            DumpTotalRamInfo();
            DumpProcessorInfo();
            DumpDiskInfo();

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        private static double BytesToGigs(ManagementObject queryObj, string column)
        {
            var totalPhysicalMemoryString = queryObj[column];
            var totalPhysicalMemory = Convert.ToDouble(totalPhysicalMemoryString);
            var totalPhysicalGigs = Math.Round(totalPhysicalMemory / 1024 / 1024 / 1024, digits: 2);
            return totalPhysicalGigs;
        }

        private static void DumpAllPropertiesForClass(string queryClass, string root = @"Root\CIMV2")
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

        private static void DumpDiskInfo()
        {
            Console.WriteLine("Disk Info");

            /* Win32_DiskDrive
             * https://msdn.microsoft.com/en-us/library/aa394132(v=vs.85).aspx
             * Properties found to be useful:
             * - Model
             * - Size
             */
            DumpAllPropertiesForClass("Win32_DiskDrive");
            Console.WriteLine();

            /*
             * https://msdn.microsoft.com/en-us/library/windows/desktop/hh830532(v=vs.85).aspx
             * Properties found to be useful:
             * - MediaType
             * - SpindleSpeed
             */
            DumpAllPropertiesForClass("MSFT_PhysicalDisk", @"Root\Microsoft\Windows\Storage");

            Console.WriteLine();
        }

        private static void DumpProcessorInfo()
        {
            Console.WriteLine("Processor Info");

            /* Win32_Processor
             * https://msdn.microsoft.com/en-us/library/aa394373(v=vs.85).aspx
             * Properties found to be useful:
             * - Architecture
             * - Name
             * - NumberOfLogicalProcessors
             */
            DumpAllPropertiesForClass("Win32_Processor");
            Console.WriteLine();
        }

        private static void DumpTotalRamInfo()
        {
            /*
             * As per the documentation, Win32_PhysicalMemory.Capacity is the
             * preferred way to get the total installed RAM, since
             * Win32_ComputerSystem.TotalPhysicalMemory does not report the full
             * installed ram.  It removes
             */

            Console.WriteLine("Calculating total installed RAM...");
            TotalRamFromComputerSystem();
            TotalRamFromPhysicalMemory();

            Console.WriteLine();
        }

        private static void TotalRamFromComputerSystem()
        {
            // https://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx
            // From the docs:
            // --------------------------------------------------------------------------
            // Total size of physical memory. Be aware that, under some circumstances,
            // this property may not return an accurate value for the physical memory.
            // For example, it is not accurate if the BIOS is using some of the physical
            // memory. For an accurate value, use the Capacity property in
            // Win32_PhysicalMemory instead.
            // --------------------------------------------------------------------------

            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                var physical = BytesToGigs(queryObj, "TotalPhysicalMemory");
                Console.WriteLine($"Win32_ComputerSystem.TotalPhysicalMemory: {physical} GB");
            }
        }

        private static void TotalRamFromPhysicalMemory()
        {
            // https://msdn.microsoft.com/en-us/library/aa394347(v=vs.85).aspx
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                var capacity = BytesToGigs(queryObj, "Capacity");
                Console.WriteLine($"Win32_PhysicalMemory.Capacity:            {capacity} GB");
            }
        }
    }
}