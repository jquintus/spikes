namespace FunWithNinject.Factories
{
    using Ninject;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FactoryTests
    {
        [Test]
        [ExpectedException(typeof(Ninject.ActivationException))]
        public void FactoryDoesNotPassParametersToSubDependency()
        {
            using (var kernel = new StandardKernel())
            {
                // Assemble
                kernel.Bind<IFoo>().To<Foo>();
                kernel.Bind<IBar>().To<Bar>();

                var factory = kernel.Get<Func<int, IFoo>>();

                // Act
                var foo = factory(7);
            }
        }

        [Test]
        public void FactoryPrefersParametersOverBindings()
        {
            using (var kernel = new StandardKernel())
            {
                // Assemble
                kernel.Bind<FunWithNinject.IFoo>().To<FunWithNinject.FooDependingOnBar>();
                kernel.Bind<FunWithNinject.IBar>().To<FunWithNinject.Bar>();

                var factory = kernel.Get<Func<FunWithNinject.IBar, FunWithNinject.IFoo>>();

                // Act
                var foo = factory(new FunWithNinject.Bar2());

                // Assert
                Assert.IsInstanceOf<FunWithNinject.Bar2>(((FooDependingOnBar)foo).Bar);
            }
        }

        [Test]
        public void Func_RegisterDependencyAsSingleton_FuncAlwaysReturnsSameInstance()
        {
            using (var kernel = new StandardKernel())
            {
                // Assemble
                kernel.Bind<FunWithNinject.IFoo>().To<FunWithNinject.Foo>().InSingletonScope();

                var factory = kernel.Get<Func<FunWithNinject.IFoo>>();

                // Act
                var foo1 = factory();
                var foo2 = factory();

                // Assert
                Assert.AreSame(foo1, foo2);
            }
        }

        [Test]
        public void Func_RegisterDependencyAsTransient_FuncAlwaysReturnsNewInstance()
        {
            using (var kernel = new StandardKernel())
            {
                // Assemble
                kernel.Bind<FunWithNinject.IFoo>().To<FunWithNinject.Foo>().InTransientScope();

                var factory = kernel.Get<Func<FunWithNinject.IFoo>>();

                // Act
                var foo1 = factory();
                var foo2 = factory();

                // Assert
                Assert.AreNotSame(foo1, foo2);
            }
        }
    }
}