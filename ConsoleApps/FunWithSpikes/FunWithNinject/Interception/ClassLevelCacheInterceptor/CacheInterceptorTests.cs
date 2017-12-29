using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;

namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
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

        [Test]
        public void GetInt_SecondCall_ReturnsCachedValueWithoutCallingRealMethod()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                var firstCall = dataSource.GetInt();
                var actual = dataSource.GetInt();

                // Assert
                Assert.AreEqual(10, actual);
                Assert.AreEqual(firstCall, actual);
                Assert.AreEqual(1, dataSource.TimesCalled);
            }
        }

        [Test]
        public void GetInt_ThirdCall_ReturnsNonCachedValue()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                var firstCall = dataSource.GetInt();
                var secondCall = dataSource.GetInt();
                var actual = dataSource.GetInt();

                // Assert
                Assert.AreEqual(11, actual);
                Assert.AreNotEqual(secondCall, actual);
                Assert.AreEqual(2, dataSource.TimesCalled);
            }
        }

        [Test]
        public void GetString_CalledTwice_ReturnsCachedValue()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                var firstCall = dataSource.GetString();
                var actual = dataSource.GetString();

                // Assert
                Assert.AreEqual("10", actual);
                Assert.AreEqual(firstCall, actual);
                Assert.AreEqual(1, dataSource.TimesCalled);
            }
        }

        [Test]
        public void GetString_CalledAfterGetInt_ReturnsNonCachedValue()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                dataSource.GetInt();
                var actual = dataSource.GetString();

                // Assert
                Assert.AreEqual("11", actual);
                Assert.AreEqual(2, dataSource.TimesCalled);
            }
        }

        [Test]
        public void GetString_CalledTwiceAfterGetInt_ReturnsCachedValue()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                var dataSource = CreateDataSource(kernel);

                // Act
                dataSource.GetInt();
                var firstCall = dataSource.GetString();
                var actual = dataSource.GetString();

                // Assert
                Assert.AreEqual("11", actual);
                Assert.AreEqual(firstCall, actual);
                Assert.AreEqual(2, dataSource.TimesCalled);
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
