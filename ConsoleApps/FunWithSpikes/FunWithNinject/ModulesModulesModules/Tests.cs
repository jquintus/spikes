namespace FunWithNinject.ModulesModulesModules
{
    using Ninject;
    using Ninject.Infrastructure;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void LoadModules_ConflictingBindings_LastModuleLoadedRules()
        {
            // Assemble
            var k1 = new StandardKernel(new Module2(), new Module1());
            var k2 = new StandardKernel(new Module1(), new Module2());

            // Act
            var foo1 = k1.Get<IFoo>();
            var foo2 = k2.Get<IFoo>();

            // Assert
            Assert.IsInstanceOf<Foo1>(foo1);
            Assert.IsInstanceOf<Foo2>(foo2);
        }

        [Test]
        public void LoadModules_KernelDefaultsToSingletonScope_UnspecifiedBindingsInModuleAreInSingletonScope()
        {
            // Assemble
            var k = new StandardKernel(
                new NinjectSettings { DefaultScopeCallback = StandardScopeCallbacks.Singleton },
                new Module1());

            // Act
            var fooOne = k.Get<IFoo>();
            var fooTwo = k.Get<IFoo>();

            // Assert
            Assert.AreSame(fooOne, fooTwo);
        }
    }
}