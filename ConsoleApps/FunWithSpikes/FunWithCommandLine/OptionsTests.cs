using NUnit.Framework;

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
            var options = OptionsHelpers.Parse<OptionsWithDefaultEnum>(args);

            // Assert
            Assert.AreEqual(Letter.B, options.DefaultedLetter);
        }

        [Test]
        public void OptionsWithEnums_EmptyArgsPassed_ReturnsDefaultValue()
        {
            // Assemble
            var args = new string[0];

            // Act
            var options = OptionsHelpers.Parse<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.A, options.DefaultedLetter);
        }

        [Test]
        public void OptionsWithEnums_EnumStringValueInArgs_ReturnsEnumValue()
        {
            // Assemble
            var args = new string[] { "--letter", "C" };

            // Act
            var options = OptionsHelpers.Parse<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.C, options.DefaultedLetter);
        }

        [Test]
        public void OptionsWithEnums_EnumStringValueWithIncorrectCasingInArgs_ReturnsEnumValue()
        {
            // Assemble
            var args = new string[] { "--letter", "c" };

            // Act
            var options = OptionsHelpers.Parse<OptionsWithEnums>(args);

            // Assert
            Assert.AreEqual(Letter.C, options.DefaultedLetter);
        }
    }
}