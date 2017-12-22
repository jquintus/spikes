using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithNinject.Interception.CacheInterceptor
{
    [TestFixture]
    public class CacheInterceptorTests
    {
        [Test]
        public void GetInt_FirstCall_ReturnsNonCachedValue()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                var actual = dataSource.GetInt();

                // Assert
                Assert.AreEqual(10, actual);
            }
        }
        
        private static IDataSource CreateDataSource(IKernel kernel)
        {
            kernel.Bind<IDataSource>()
                  .To<DataSource>()
                  .Intercept()
                  .With<SimpleCache>();

            return kernel.Get<IDataSource>();
        }
    }
}
