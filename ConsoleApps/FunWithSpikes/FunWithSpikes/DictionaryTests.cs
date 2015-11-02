using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FunWithSpikes
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_EntryExists_Throws()
        {
            // Assemble
            Dictionary<string, int> x = new Dictionary<string, int>();

            x.Add("one", 1);

            // Act
            x.Add("one", 2);
        }

        [Test]
        public void IndexerGet_EntryDoesNotExist_DoesNotThrow()
        {
            // Assemble
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Act
            dictionary["hello"] = 3;

            // Assert
            Assert.AreEqual(3, dictionary["hello"]);
        }
    }
}