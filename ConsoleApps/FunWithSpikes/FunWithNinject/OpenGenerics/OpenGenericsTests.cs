using Ninject;
using NUnit.Framework;
using System;

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

                // Act
                var dependsOn = k.Get<DependsOnLogger>();

                // Assert
                Assert.AreEqual(typeof(int), dependsOn.CacheType);
            }
        }

        #region Types

        public interface IAutoCache<T>
        {
            Type CacheType { get; }
        }

        public class AutoCache<T> : IAutoCache<T>
        {
            public Type CacheType { get { return typeof(T); } }
        }

        public class DependsOnLogger
        {
            public DependsOnLogger(IAutoCache<int> intCacher)
            {
                CacheType = intCacher.CacheType;
            }

            public Type CacheType { get; set; }
        }

        #endregion
    }
}