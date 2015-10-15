using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FunWithSpikes
{
    [TestFixture]
    public class SeeSharp
    {
        [Test]
        public void CallAMethodWithAnOutParam_OutParamIsSetAndExceptionThrown_CanAccessOutParamsValueFromCaller()
        {
            // Assemble
            string msg = "Not set";
            bool caught = false;

            // Act
            try
            {
                SetsOutAndThrows(out msg);
            }
            catch
            {
                caught = true;
            }

            // Assert
            Assert.AreEqual("Hello World", msg);
            Assert.IsTrue(caught);
        }


        [Test]
        public void Values_EmptyDictionary_ReturnsEmptyList()
        {
            // Assemble
            var dict = new Dictionary<int, int>();

            // Act
            var values = dict.Values;

            // Assert
            CollectionAssert.IsEmpty(values);
        }

        private void SetsOutAndThrows(out string msg)
        {
            msg = "Hello World";
            throw new Exception();
        }
    }
}