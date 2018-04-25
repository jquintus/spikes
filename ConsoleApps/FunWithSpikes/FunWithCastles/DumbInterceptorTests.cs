using Castle.DynamicProxy;
using NUnit.Framework;
using System;

namespace FunWithCastles
{
    [TestFixture]
    public class DumbInterceptorTests
    {
        [Test]
        public void Get_ReferenceTypeDoesNotExistInInterceptor_ReturnsNull()
        {
            // Assemble
            var proxy = CreateSettingsProxy();

            // Act/Assert
            Assert.IsNull(proxy.Name);
        }

        [Test]
        public void Get_ValueExistsInInterceptor_ReturnsValue()
        {
            // Assemble
            var proxy = CreateSettingsProxy(maxItems: 42);

            // Act/Assert
            Assert.AreEqual(42, proxy.MaxItems);
        }

        [Test]
        public void Get_ValueTypeDoesNotExistInInterceptor_ReturnsDefault()
        {
            // Assemble
            var proxy = CreateSettingsProxy();

            // Act/Assert
            Assert.AreEqual(0, proxy.MaxItems);
        }

        [Test]
        public void Set_ValueDoesNotExistInInterceptor_AddsValue()
        {
            // Assemble
            var proxy = CreateSettingsProxy();

            // Act
            proxy.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", proxy.Name);
        }

        [Test]
        public void Set_ValueExistInInterceptor_OverwritesValue()
        {
            // Assemble
            var proxy = CreateSettingsProxy(maxItems: 42);

            // Act
            proxy.MaxItems = 55;

            // Assert
            Assert.AreEqual(55, proxy.MaxItems);
        }

        private static IAppSettings CreateSettingsProxy(
            int maxItems = 0,
            string name = null,
            DateTime lastModified = default(DateTime))
        {
            var interceptor = new DumbInterceptor(maxItems, name, lastModified);
            var generator = new ProxyGenerator();
            var proxy = generator.CreateInterfaceProxyWithoutTarget<IAppSettings>(interceptor);
            return proxy;
        }
    }
}