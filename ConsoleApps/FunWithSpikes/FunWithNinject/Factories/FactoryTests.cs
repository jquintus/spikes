namespace FunWithNinject.Factories
{
    using Ninject;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FactoryTests
    {
        [Test]
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

                // Assert
                Assert.AreNotEqual(7, foo.InternalRuntimeDependency);
            }
        }
    }
}