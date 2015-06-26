namespace _64bitExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AnyCpuDll.AnyClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());

            //x86Dll.Class86.GetInfo();              // This will throw a bad image exception
            //AnyCpuDll.AnyClass.Access86BitDll();   // This will throw a bad image exception

            _64BitDll.Class64.GetInfo();             
            AnyCpuDll.AnyClass.Access64BitDll();
        }
    }
}