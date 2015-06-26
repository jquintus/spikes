namespace _64bitExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AnyCpuDll.AnyClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());
            _64BitDll.Class64.GetInfo();
        }
    }
}