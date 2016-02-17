using Moq;
using NUnit.Framework;

namespace FunWithMoq
{
    [TestFixture]
    public class AbstractMoqTests
    {
        [Test]
        public void MockOf_MockOutMethod_MockWorks()
        {
            // Assemble
            var mock = Mock.Of<MyClass>(c => c.MyMethod(5) == "Hello" && c.MyMethod(9) == "World");

            // Act/Assert
            Assert.AreEqual("Hello", mock.MyMethod(5));
            Assert.AreEqual("World", mock.MyMethod(9));
        }

        [Test]
        public void SetupGet_AbstractProperty_ValueIsReturnedWhenCalledByAnotherMember()
        {
            // Assemble
            var mock = Mock.Of<MyClass>(c => c.MyString == "Hello");

            // Act
            var actual = mock.GetMyString();

            // Assert
            Assert.AreEqual("Hello", actual);
        }

        public abstract class MyClass
        {
            public abstract string MyString { get; }

            public string GetMyString()
            {
                return MyString;
            }

            public abstract string MyMethod(int input);
        }
    }
}