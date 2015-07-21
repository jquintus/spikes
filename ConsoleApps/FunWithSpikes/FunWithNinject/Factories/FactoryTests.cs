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
    }
}