using FunWithCastles.Settings.Loaders;
using NUnit.Framework;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Tests
{
    [TestFixture]
    public class CommandLineLoaderTests
    {
        [Test]
        public void Ctor_MultipleArguments_Parses()
        {
            // Act
            var loader = new CommandLineLoader(new[]
            {
                "--make", "Ford",
                "--model", "Prefect",
            });

            // Assert
            var data = loader.Load();
            Assert.AreEqual("Ford", data["Make"]);
            Assert.AreEqual("Prefect", data["Model"]);
        }

        [Test]
        public void Ctor_NumericArgument_ReturnsString()
        {
            // Act
            var loader = new CommandLineLoader(new[] { "--age", "42" });

            // Assert
            var data = loader.Load();
            Assert.AreEqual("42", data["Age"]);
        }

        [Test]
        [TestCase("-n", "Douglas", ExpectedResult = "Douglas")]
        [TestCase("-n=Douglas", ExpectedResult = "Douglas")]
        public object Ctor_SwitchMappings_CanParseWithShortSwitch(params string[] args)
        {
            // Assemble
            var switches = new Dictionary<string, string> { ["-n"] = "Name", };

            // Act
            var loader = new CommandLineLoader(args, switches);

            // Assert
            var data = loader.Load();
            return data["Name"];
        }

        [Test]
        [TestCase("/name", "Douglas", "/name", "Adams", ExpectedResult = "Adams")]
        [TestCase("--name", "Douglas", ExpectedResult = "Douglas")]
        [TestCase("/name=Douglas", ExpectedResult = "Douglas")]
        [TestCase("--name=Douglas", ExpectedResult = "Douglas")]
        [TestCase("--name=Douglas", ExpectedResult = "Douglas")]
        public object Ctor_ValidInput(params string[] args)
        {
            // Act
            var loader = new CommandLineLoader(args);

            // Assert
            var data = loader.Load();
            return data["Name"];
        }
    }
}