using Ninject;
using NUnit.Framework;

namespace FunWithNinject.Attributes
{
    [TestFixture]
    public class AttributeTests
    {
        public void WhenMemberHas_DependsOnDefaultFoo_InjectsDefaultFoo()
        {
            // Assemble
            using (var kernel = CreateKernel())
            {
                // Act
                var resolved = kernel.Get<DependsOnDefaultFoo>();

                // Assert
                Assert.IsInstanceOf<Foo1>(resolved.Foo);
            }
        }

        public void WhenMemberHas_DependsOnSpecialFoo_InjectsSpecialFoo()
        {
            // Assemble
            using (var kernel = CreateKernel())
            {
                // Act
                var resolved = kernel.Get<DependsOnSpecialFoo>();

                // Assert
                Assert.IsInstanceOf<Foo2>(resolved.Foo);
            }
        }

        private static IKernel CreateKernel()
        {
            var k = new StandardKernel();

            k.Bind<IFoo>().To<Foo1>();
            k.Bind<IFoo>().To<Foo2>().WhenMemberHas<SpecialFooAttribute>();

            return k;
        }
    }
}