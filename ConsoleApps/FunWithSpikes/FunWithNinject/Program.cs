namespace FunWithNinject
{
    using Ninject;
    using Ninject.Extensions.Factory;
    using System;

    internal class Program
    {
        public static void Main(string[] args)
        {
            FunWithFuncs();
            FunWithFactories();
        }

        private static void FunWithFactories()
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

        private static void FunWithFuncs()
        {
            var k = new StandardKernel();

            var bar = k.Get<Bar>();
            bar.Do();
        }
    }
}