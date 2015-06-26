namespace AnyCpuExe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AnyCpuDll.AnyClass.GetInfo(System.Reflection.Assembly.GetEntryAssembly());

            //_64BitDll.Class64.GetInfo();               // This will throw a bad image exception
            //AnyCpuDll.AnyClass.Access64BitDll();       // This will throw a bad image exception
        }
    }
}