using NUnit.Framework;
using System;

namespace FunWithSpikes
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void IsDelegate()
        {
            Assert.IsFalse(IsFunc<string>());
            Assert.IsTrue(IsFunc<Func<int>>());
            Assert.IsTrue(IsFunc<Func<int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int>>());
            Assert.IsTrue(IsFunc<Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>>());
        }

        private bool IsFunc<T1>()
        {
            var boo = typeof(MulticastDelegate).IsAssignableFrom(typeof(T1));

            return boo;
        }
    }
}