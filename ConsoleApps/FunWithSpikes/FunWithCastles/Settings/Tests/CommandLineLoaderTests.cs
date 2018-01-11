using FunWithCastles.Settings.Loaders;
using NUnit.Framework;

namespace FunWithCastles.Settings.Tests
{
    [TestFixture]
    public class CommandLineLoaderTests
    {
        [Test]
        public void Ctor_MultipleArguments_Parses()
        {
            // Act
            var loader = CreateCommandLineLoader("--make", "Ford", "--model", "Prefect");

            // Assert
            var data = loader.Load();
            Assert.AreEqual("Ford", data["Make"]);
            Assert.AreEqual("Prefect", data["Model"]);
        }

        [Test]
        public void Ctor_NumericArgument_ReturnsString()
        {
            // Act
            var loader = CreateCommandLineLoader("--age", "42");

            // Assert
            var data = loader.Load();
            Assert.AreEqual("42", data["Age"]);
        }

        [Test]
        [TestCase("/name", "Douglas", ExpectedResult = "Douglas")]
        [TestCase("--name", "Douglas", ExpectedResult = "Douglas")]
        [TestCase("/name=Douglas", ExpectedResult = "Douglas")]
        [TestCase("--name=Douglas", ExpectedResult = "Douglas")]
        public object Ctor_ValidInput(params string[] args)
        {
            // Act
            var loader = CreateCommandLineLoader(args);

            // Assert
            var data = loader.Load();
            return data["Name"];
        }

        private static CommandLineLoader CreateCommandLineLoader(params string[] args)
        {
            return new CommandLineLoader(args);
        }
    }
}