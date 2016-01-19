using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FunWithNewtonsoft
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void DeserializeObject_JsonList_ReturnsIEnumerable()
        {
            // Assemble
            string json = @"
                [
                    {'Number':'1','Letter':'A'},
                    {'Number':'2','Letter':'B'},
                    {'Number':'3','Letter':'C'}
                ]";

            // Act
            List<Data> actual = JsonConvert.DeserializeObject<IEnumerable<Data>>(json).ToList();

            // Assert
            Assert.AreEqual(1, actual[0].Number);
            Assert.AreEqual("A", actual[0].Letter);

            Assert.AreEqual(2, actual[1].Number);
            Assert.AreEqual("B", actual[1].Letter);

            Assert.AreEqual(3, actual[2].Number);
            Assert.AreEqual("C", actual[2].Letter);
        }

        [Test]
        public void DeserializeObject_JsonList_ReturnsList()
        {
            // Assemble
            string json = @"
                [
                    {'Number':'1','Letter':'A'},
                    {'Number':'2','Letter':'B'},
                    {'Number':'3','Letter':'C'}
                ]";

            // Act
            List<Data> actual = JsonConvert.DeserializeObject<List<Data>>(json);

            // Assert
            Assert.AreEqual(1, actual[0].Number);
            Assert.AreEqual("A", actual[0].Letter);

            Assert.AreEqual(2, actual[1].Number);
            Assert.AreEqual("B", actual[1].Letter);

            Assert.AreEqual(3, actual[2].Number);
            Assert.AreEqual("C", actual[2].Letter);
        }

        [Test]
        public void DeserializeObject_MissingSquareBracesAroundJsonList_Throws()
        {
            // Assemble
            string json = @"
                    {'Number':'1','Letter':'A'},
                    {'Number':'2','Letter':'B'},
                    {'Number':'3','Letter':'C'}";

            // Act
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<List<Data>>(json));
        }

        [Test]
        public void DeserializeObject_TrailingCommaAtEndOfJsonList_ReturnsList()
        {
            // Assemble
            string json = @"
                [
                    {'Number':'1','Letter':'A'},
                    {'Number':'2','Letter':'B'},
                    {'Number':'3','Letter':'C'},
                ]";

            // Act
            List<Data> actual = JsonConvert.DeserializeObject<List<Data>>(json);

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