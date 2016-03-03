using NUnit.Framework;
using System;

namespace FunWithCommandLine
{
    [TestFixture]
    public class OptionsTests
    {
        [Test]
        public void OptionsWithDefaultEnum_EmptyArgsPassed_ReturnsDefaultValue()
        {
            // Assemble
            var args = new string[0];

            // Act
            var options = CreateOptions<OptionsWithDefaultEnum>(args);

            // Assert
            Assert.AreEqual(Letter.B, options.DefaultedLetter);
        }

        [Test]
        public void OptionsWithEnums_EmptyArgsPassed_ReturnsDefaultValue()
        {
            // Assemble
            var args = new string[0];

            // Act
            var options = CreateOptions<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.A, options.DefaultedLetter);
        }

        [Test]
        public void OptionsWithEnums_EnumStringValueInArgs_ReturnsEnumValue()
        {
            // Assemble
            var args = new string[] { "--letter", "C" };

            // Act
            var options = CreateOptions<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.C, options.DefaultedLetter);
        }


        [Test]
        public void OptionsWithEnums_EnumStringValueWithIncorrectCasingInArgs_ReturnsEnumValue()
        {
            // Assemble
            var args = new string[] { "--letter", "c" };

            // Act
            var options = CreateOptions<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.C, options.DefaultedLetter);
        }



        private T CreateOptions<T>(string[] args) where T : new()
        {
            var options = new T();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                return options;
            }
            else
            {
                Assert.Fail("could not parse args");
                throw new Exception("this will never be hit since Assert.Fail throws internally");
            }
        }
    }
}