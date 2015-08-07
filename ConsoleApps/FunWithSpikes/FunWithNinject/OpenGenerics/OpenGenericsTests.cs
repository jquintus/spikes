using Ninject;
using NUnit.Framework;

namespace FunWithNinject.OpenGenerics
{
    [TestFixture]
    public class OpenGenericsTests
    {
        [Test]
        public void OpenGenericBinding()
        {
            using (var k = new StandardKernel())
            {
                // Assemble
                k.Bind(typeof(IAutoCache<>)).To(typeof(AutoCache<>));
                k.Bind < IProvider<int>>().To<IntProvider>();

                // Act
                var dependsOn = k.Get<DependsOnCachedInt>();

                // Assert
                Assert.AreEqual(42, dependsOn.CachedValue);
            }
        }

        #region Types

        public interface IAutoCache<T> { T CachedValue { get; } }

        public interface IProvider<T> { T Value { get; } }

        public class AutoCache<T> : IAutoCache<T>
        {
            public AutoCache(IProvider<T> provider)
            {
                CachedValue = provider.Value;
            }

            public T CachedValue { get; set; }
        }

        public class DependsOnCachedInt
        {
            public DependsOnCachedInt(IAutoCache<int> intCacher)
            {
                CachedValue = intCacher.CachedValue;
            }

            public int CachedValue { get; set; }
        }

        public class IntProvider : IProvider<int>
        {
            public int Value { get { return 42; } }
        }

        #endregion
    }
}