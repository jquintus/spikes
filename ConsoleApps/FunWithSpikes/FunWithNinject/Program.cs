using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithNinject
{
    using Ninject.Extensions.Factory;

    class Program
    {
        static void Main(string[] args)
        {

            var k = new StandardKernel();
            k.Bind<IDependency>().To<Dependency>();
            k.Bind<IService>().To<MyService>();
            k.Bind<IMyServiceFactory>().ToFactory();

            //var s = k.Get<IService>();


            var f = k.Get<IMyServiceFactory>();
            var s = f.Create("world");
            Console.WriteLine(s.Do());
        }
    }
}
