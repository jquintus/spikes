using FunWithCastles.Settings.Adapters;
using FunWithCastles.Settings.Utils;
using NUnit.Framework;

namespace FunWithCastles.Settings.Tests
{
    [TestFixture]
    public class EnvironmentVariableAdapterTests
    {
        [Test]
        public void Get_ValueIsInt_ReturnsInt()
        {
            // Assemble
            using (Env.SetVariable(nameof(IAppSettings.MaxItems), "42"))
            {
                var settings = SettingsBuilder.Create()
                                              .AddEnvironmentVariableAdapter()
                                              .Create<IAppSettings>();

                // Act
                int maxItems = settings.MaxItems;

                // Assert
                Assert.AreEqual(42, maxItems);
            }
        }
    }
}