using System;
using System.Diagnostics;
using System.Management;

namespace Wmi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WMI Code Creator v1.0
            // https://www.microsoft.com/en-us/download/confirmation.aspx?id=8572

            TotalRam();

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

        private static void TotalRam()
        {
            Console.WriteLine("Calculating total installed RAM...");
            TotalRamFromComputerSystem();

            // As per the documentation, this is the 
            // preferred way to get the total installed RAM.
            TotalRamFromPhysicalMemory();
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

        private static void TotalRamFromComputerSystem()
        {

            // https://msdn.microsoft.com/en-us/library/aa394102%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
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
    }
}