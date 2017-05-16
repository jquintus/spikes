using NUnit.Framework;

namespace FunWithCommandLine.SubclassedOptions
{
    [TestFixture]
    public class SubclassedOptionsTests
    {
        [Test]
        public void NonVirtualOverrides_ValueSetInCtorIsOverwritten()
        {
            // Assemble
            var child = new ChildOptions();
            var expected = child.SealedOption;

            // Act
            child = OptionsHelpers.Parse(child);

            // Assert
            Assert.AreNotEqual(expected, child.SealedOption);
        }

        [Test]
        public void VirtualOverrides_OverridenDefaultIsUsed()
        {
            // Act
            var child = OptionsHelpers.Parse<ChildOptions>();

            // Assert
            Assert.AreEqual("child - virtual option", child.VirtualOption);
        }
    }
}