using Ninject;
using Ninject.Extensions.ChildKernel;
using NUnit.Framework;

namespace FunWithNinject.NamedScope
{
    [TestFixture]
    public class ChildKernelTests
    {
        [Test]
        public void ChildKernel_IFooBoundInChildKernel_ParentKernelCannotResolveIFoo()
        {
            // Assemble
            var parentKernel = new StandardKernel();

            var childKernel = new ChildKernel(parentKernel);
            childKernel.Bind<IFoo>().To<Foo>();

            // Act
            Assert.Throws<ActivationException>(() => parentKernel.Get<IFoo>());
        }

        [Test]
        public void ChildKernel_IFooBoundInParentAndChildKernel_ChildCanResolveIFoo()
        {
            // Assemble
            var parentKernel = new StandardKernel();
            parentKernel.Bind<IFoo>().To<Foo1>();

            var childKernel = new ChildKernel(parentKernel);
            childKernel.Bind<IFoo>().To<Foo2>();

            // Act
            var foo = childKernel.Get<IFoo>();

            // Act
            Assert.IsInstanceOf<Foo2>(foo);
        }

        [Test]
        public void ChildKernel_IFooBoundInParentAndChildKernel_ParentCanResolveIFoo()
        {
            // Assemble
            var parentKernel = new StandardKernel();
            parentKernel.Bind<IFoo>().To<Foo1>();

            var childKernel = new ChildKernel(parentKernel);
            childKernel.Bind<IFoo>().To<Foo2>();

            // Act
            var foo = parentKernel.Get<IFoo>();

            // Act
            Assert.IsInstanceOf<Foo1>(foo);
        }

        [Test]
        public void ChildKernel_SameInterfaceBoundInTwoChildKernels_EachKernelResolvesInstanceCorrectly()
        {
            // Assemble
            var parentKernel = new StandardKernel();
            parentKernel.Bind<IBar>().To<Bar>();

            var barNoneKernel = new ChildKernel(parentKernel);
            barNoneKernel.Bind<IFoo>().To<Foo>();

            var allTheBarsKernel = new ChildKernel(parentKernel);
            allTheBarsKernel.Bind<IFoo>().To<FooDependingOnBar>();

            // Act
            var barNone = barNoneKernel.Get<IFoo>();
            var bars = allTheBarsKernel.Get<IFoo>();

            // Assert

            Assert.IsInstanceOf<Foo>(barNone);
            Assert.IsInstanceOf<FooDependingOnBar>(bars);
        }
    }
}
