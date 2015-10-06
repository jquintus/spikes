using NUnit.Framework;
using System;

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

        private void SetsOutAndThrows(out string msg)
        {
            msg = "Hello World";
            throw new Exception();
        }
    }
}