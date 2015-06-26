using AnyCpuDll;

namespace _64bitExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SomeClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());
        }
    }
}