using Ninject;
using NUnit.Framework;

namespace FunWithNinject.Provider
{
    [TestFixture]
    public class ProviderTests
    {
        [Test]
        public void Get_DirectDependency_InjectsMultipleInstancesOfIFoo()
        {
            using (var k = CreateKernel())
            {
                // Assemble
                k.Bind<IFoo>().ToProvider<NamedFooProvider>().Named(NamedFooProvider.Foo1);
                k.Bind<IFoo>().ToProvider<NamedFooProvider>().Named(NamedFooProvider.Foo2);

                // Act
                var direct = k.Get<DirectDualDependency>();

                // Assert
                Assert.IsInstanceOf<Foo1>(direct.FirstFoo);
                Assert.IsInstanceOf<Foo2>(direct.SecondFoo);
            }
        }

        [Test]
        public void Get_IndirectDependencyOnFoo1_InjectsInstanceOfFoo1()
        {
            using (var k = CreateKernel())
            {
                // Assemble
                k.Bind<DirectDependency>().ToSelf();
                k.Bind<DirectDependency>().ToSelf().Named(NamedFooProvider.Foo1);
                k.Bind<DirectDependency>().ToSelf().Named(NamedFooProvider.Foo2);

                // Act
                var indirect = k.Get<IndirectDependencyOnFoo1>();

                // Assert
                Assert.IsInstanceOf<Foo1>(indirect.DirectDependency.Foo);
            }
        }

        [Test]
        public void Get_IndirectDependencyOnFoo2_InjectsInstanceOfFoo2()
        {
            using (var k = CreateKernel())
            {
                // Assemble
                k.Bind<DirectDependency>().ToSelf();
                k.Bind<DirectDependency>().ToSelf().Named(NamedFooProvider.Foo1);
                k.Bind<DirectDependency>().ToSelf().Named(NamedFooProvider.Foo2);

                // Act
                var indirect = k.Get<IndirectDependencyOnFoo2>();

                // Assert
                Assert.IsInstanceOf<Foo2>(indirect.DirectDependency.Foo);
            }
        }

        [Test]
        public void Get_MoreIndirectDependencyOnFoo1_InjectsInstanceOfFoo1()
        {
            using (var k = CreateKernel())
            {
                // Assemble
                k.Bind<IntermediateDependency>().ToSelf();
                k.Bind<IntermediateDependency>().ToSelf().Named(NamedFooProvider.Foo1);
                k.Bind<IntermediateDependency>().ToSelf().Named(NamedFooProvider.Foo2);

                // Act
                var indirect = k.Get<MoreIndirectDependencyOnFoo1>();

                // Assert
                Assert.IsInstanceOf<Foo1>(indirect.IntermediateDependency.DirectDependency.Foo);
            }
        }

        private IKernel CreateKernel()
        {
            var k = new StandardKernel();
            k.Bind<IFoo>().To<Foo1>().WhenInjectedExactlyInto<NamedFooProvider>().Named(NamedFooProvider.Foo1);
            k.Bind<IFoo>().To<Foo2>().WhenInjectedExactlyInto<NamedFooProvider>().Named(NamedFooProvider.Foo2);

            k.Bind<IFoo>().ToProvider<NamedFooProvider>();

            return k;
        }
    }
}