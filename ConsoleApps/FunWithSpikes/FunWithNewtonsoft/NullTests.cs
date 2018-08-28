using Newtonsoft.Json;
using NUnit.Framework;

namespace FunWithNewtonsoft
{
    [TestFixture]
    public class NullTests
    {
        [Test]
        public void DeserializeObject_NullValueInJsonString_SetsPropertyToNull()
        {
            // Assemble
            string json = @"{'Number':'1','Letter':null}";

            // Act
            var actual = JsonConvert.DeserializeObject<Data>(json);

            // Assert
            Assert.IsNull(actual.Letter);
        }
    }
}