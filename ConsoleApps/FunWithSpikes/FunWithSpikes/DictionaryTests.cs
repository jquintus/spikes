namespace FunWithSpikes
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

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
    }
}