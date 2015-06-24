namespace FunWithNinject.ModulesModulesModules
{
    using Ninject.Modules;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Module2:NinjectModule
    {
        public override void Load()
        {
            Rebind<IFoo>().To<Foo2>();
        }
    }
}
