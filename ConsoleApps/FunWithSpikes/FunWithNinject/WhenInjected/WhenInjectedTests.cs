using Ninject;
using NUnit.Framework;

namespace FunWithNinject.WhenInjected
{
    [TestFixture]
    public class WhenInjectedTests
    {
        [Test]
        public void WhenInjectedExactlyInto()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<ISomeUtility>().To<GoogleUtility>().WhenInjectedExactlyInto<GoogleService>();
                k.Bind<ISomeUtility>().To<BingUtility>().WhenInjectedExactlyInto<BingService>();

                // Act
                var goog = k.Get<GoogleService>();
                var bing = k.Get<BingService>();

                // Assert
                Assert.IsInstanceOf<GoogleUtility>(goog.Utility);
                Assert.IsInstanceOf<BingUtility>(bing.Utility);
            }
        }

        [Test]
        public void WhenInjectedInto_InjectedExactlyIntoSpecifiedType()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<ISomeUtility>().To<GoogleUtility>().WhenInjectedInto<GoogleService>();
                k.Bind<ISomeUtility>().To<BingUtility>().WhenInjectedInto<BingService>();

                // Act
                var goog = k.Get<GoogleService>();
                var bing = k.Get<BingService>();

                // Assert
                Assert.IsInstanceOf<GoogleUtility>(goog.Utility);
                Assert.IsInstanceOf<BingUtility>(bing.Utility);
            }
        }

        [Test]
        public void WhenInjectedInto_InjectedSubClass()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<ISomeUtility>().To<GoogleUtility>().WhenInjectedInto<GoogleService>();

                // Act
                var goog = k.Get<GoogleChildService>();

                // Assert
                Assert.IsInstanceOf<GoogleUtility>(goog.Utility);
            }
        }
    }
}