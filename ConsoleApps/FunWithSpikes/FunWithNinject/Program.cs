namespace FunWithNinject
{
    using System;
    using Ninject;
    using Ninject.Extensions.Factory;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var k = new StandardKernel();
            k.Bind<IDependency>().To<Dependency>();
            k.Bind<IService>().To<MyService>();
            k.Bind<IMyServiceFactory>().ToFactory();

            //var s = k.Get<IService>();


            var f = k.Get<IMyServiceFactory>();
            MyService s = f.Create("world");
            Console.WriteLine(s.Do());
        }
    }
}