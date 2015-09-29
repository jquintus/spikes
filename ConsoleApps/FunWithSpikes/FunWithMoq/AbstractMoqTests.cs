using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMoq
{
    [TestFixture]
    public class AbstractMoqTests
    {
        public abstract class MyClass
        {
            public abstract string MyString { get; }

            public string GetMyString()
            {
                return MyString;
            }
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
    }
}
