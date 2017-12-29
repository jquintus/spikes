using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;
using System.Linq;

namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
{
    [TestFixture]
    public class InterceptionConfigurtionTests
    {
        [Test]
        public void Intercept_UsingServiceAttribute_InterceptorIsApplied()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var interceptor = new PassThroughInterceptor();
                kernel.Bind<IDataSource>().To<DataSource>();

                // Act
                kernel.Intercept(ctx => ServiceHasAttribute<CacheInterfaceAttribute>(ctx))
                      .With(interceptor);

                // Assert
                var service = kernel.Get<IDataSource>();
                service.GetInt();

                Assert.IsTrue(interceptor.Called);
            }
        }

        [Test]
        public void Intercept_ServiceAttributeIsNotFound_InterceptorIsNotApplied()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var interceptor = new PassThroughInterceptor();
                kernel.Bind<IDataSource>().To<DataSource>();

                // Act
                kernel.Intercept(ctx => ServiceHasAttribute<CacheInterface_NotAppliedAttribute>(ctx))
                      .With(interceptor);

                // Assert
                var service = kernel.Get<IDataSource>();
                service.GetInt();

                Assert.IsFalse(interceptor.Called);
            }
        }

        private static bool ServiceHasAttribute<TAttribute>(IContext ctx)
        {
            var svc = ctx.Binding.Service;
            var attributes = svc.GetCustomAttributes(true);
            var has = attributes.Any(a => a is TAttribute);
            return has;
        }
    }
}
