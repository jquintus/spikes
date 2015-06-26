namespace x86Exe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AnyCpuDll.AnyClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());

            x86Dll.Class86.GetInfo();
            AnyCpuDll.AnyClass.Access86BitDll();


            //_64BitDll.Class64.GetInfo();               // This will throw a bad image exception
            //AnyCpuDll.AnyClass.Access64BitDll();       // This will throw a bad image exception
        }
    }
}