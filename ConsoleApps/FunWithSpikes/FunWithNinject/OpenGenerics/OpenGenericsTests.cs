using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithNinject.OpenGenerics
{
    [TestFixture]
    public class OpenGenericsTests
    {

        public interface ILogger<T>
        {
            Type GenericParam { get; }
        }
        public class Logger<T> : ILogger<T>
        {
            public Type GenericParam { get { return typeof(T); } }

        }

        public class DependsOnLogger
        {
            public DependsOnLogger(ILogger<int> intLogger)
            {
                GenericParam = intLogger.GenericParam;
            }

            public Type GenericParam { get; set; }

        }

        [Test]
        public void OpenGenericBinding()
        {
            using (var k = new StandardKernel())
            {
                // Assemble
                k.Bind(typeof(ILogger<>)).To(typeof(Logger<>));

                // Act
                var dependsOn = k.Get<DependsOnLogger>();

                // Assert
                Assert.AreEqual(typeof(int), dependsOn.GenericParam);
            }
        }
    }
}
