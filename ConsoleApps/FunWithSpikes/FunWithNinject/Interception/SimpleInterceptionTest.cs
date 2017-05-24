using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;

namespace FunWithNinject.Interception
{
    [TestFixture]
    public class SimpleInterceptionTest
    {
        [Test]
        public void Test()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<Foo>().ToSelf().Intercept().With<ReturnMaxIntInterceptor>();

                // Act
                var foo = k.Get<Foo>();

                // Assert
                Assert.AreEqual(int.MaxValue, foo.Bar("Hello"));
            }
        }
    }
}