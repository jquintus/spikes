using Ninject;
using Ninject.Activation;
using NUnit.Framework;

namespace FunWithNinject.Provider
{
    public class DirectDependency
    {
        public DirectDependency(
            [Named(NamedFooProvider.First)]IFoo firstFoo,
            [Named(NamedFooProvider.Second)]IFoo secondFoo
            )
        {
            FirstFoo = firstFoo;
            SecondFoo = secondFoo;
        }

        public IFoo FirstFoo { get; }
        public IFoo SecondFoo { get; }
    }

    public class NamedFooProvider : Provider<IFoo>
    {
        public const string First = "First";
        public const string Second = "Second";
        private readonly IFoo _first;
        private readonly IFoo _second;

        public NamedFooProvider(
            [Named(First)]IFoo firstFoo,
            [Named(Second)]IFoo secondFoo)
        {
            _first = firstFoo;
            _second = secondFoo;
        }

        protected override IFoo CreateInstance(IContext context)
        {
            if (context.Binding.Metadata.Name == Second)
            {
                return _second;
            }
            {
                return _first;
            }
        }
    }

    [TestFixture]
    public class ProviderTests
    {
        [Test]
        public void Get_DirectDependency_Returns()
        {
            using (var k = new StandardKernel())
            {
                k.Bind<IFoo>().To<Foo1>().WhenInjectedExactlyInto<NamedFooProvider>().Named(NamedFooProvider.First);
                k.Bind<IFoo>().To<Foo2>().WhenInjectedExactlyInto<NamedFooProvider>().Named(NamedFooProvider.Second);

                k.Bind<IFoo>().ToProvider<NamedFooProvider>();
                k.Bind<IFoo>().ToProvider<NamedFooProvider>().Named(NamedFooProvider.First);
                k.Bind<IFoo>().ToProvider<NamedFooProvider>().Named(NamedFooProvider.Second);

                // Act
                var direct = k.Get<DirectDependency>();

                // Assert
                Assert.IsInstanceOf<Foo1>(direct.FirstFoo);
                Assert.IsInstanceOf<Foo2>(direct.SecondFoo);
            }
        }
    }
}