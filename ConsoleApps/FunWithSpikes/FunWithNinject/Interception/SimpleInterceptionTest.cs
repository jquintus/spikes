using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;

namespace FunWithNinject.Interception
{
    [TestFixture]
    public class SimpleInterceptionTest
    {
        [Test]
        public void Intercept_InterfaceMethod_InterceptionSucceeds()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<IFoo>().To<NonVirtualFoo>().Intercept().With<ReturnMaxIntInterceptor>();

                // Act
                var foo = k.Get<IFoo>();

                // Assert
                Assert.AreEqual(int.MaxValue, foo.Bar("Hello"));
            }
        }

        [Test]
        public void Intercept_NonvirtualMethod_InterceptionFails()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<NonVirtualFoo>().ToSelf().Intercept().With<ReturnMaxIntInterceptor>();

                // Act
                var foo = k.Get<NonVirtualFoo>();

                // Assert
                Assert.AreNotEqual(int.MaxValue, foo.Bar("Hello"));
            }
        }

        [Test]
        public void Intercept_VirtualMethod_InterceptionSucceeds()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<VirtualFoo>().ToSelf().Intercept().With<ReturnMaxIntInterceptor>();

                // Act
                var foo = k.Get<VirtualFoo>();

                // Assert
                Assert.AreEqual(int.MaxValue, foo.Bar("Hello"));
            }
        }

        [Test]
        public void InterceptWithAttribute_InteceptionSucceeds()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<IFoo>().To<AttributedFoo>();

                // Act
                var foo = k.Get<IFoo>();

                // Assert
                Assert.AreEqual(606, foo.Bar("Hello"));
            }
        }
    }
}