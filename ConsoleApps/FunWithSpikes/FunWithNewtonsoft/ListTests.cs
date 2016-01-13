using NUnit.Framework;
using System.Collections.Generic;

namespace FunWithNewtonsoft
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void Deserialize_PartialList_ReturnsList()
        {
            // Assemble
            string json = @"
                {'Number':'1','Letter':'A'},
                {'Number':'2','Letter':'B'},
                {'Number':'3','Letter':'C'},";

            // Act
            List<Data> actual = null;

            // Assert
            Assert.AreEqual(1, actual[0].Number);
            Assert.AreEqual("A", actual[0].Letter);

            Assert.AreEqual(2, actual[1].Number);
            Assert.AreEqual("B", actual[1].Letter);

            Assert.AreEqual(3, actual[2].Number);
            Assert.AreEqual("C", actual[2].Letter);
        }
    }
}