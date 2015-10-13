using NUnit.Framework;

namespace FunWithSpikes
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void StringInterpolation_PassInAnObject_ImplicitlyCallsToString()
        {
            // Assemble
            var mc = new MyClass();

            // Act
            var actual = $"{mc} world";

            // Assert
            Assert.AreEqual("hello world", actual);
        }

        private class MyClass
        {
            public override string ToString()
            {
                return "hello";
            }
        }
    }
}