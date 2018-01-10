using FunWithCastles.Settings.Adapters;
using NUnit.Framework;
using System.Collections;

namespace FunWithCastles.Settings
{
    [TestFixture]
    public class SettingsBuilderTests
    {
        [Test]
        public void Build_OneAdapter_CreatesSettingsObject()
        {
            // Assemble
            var builder = new SettingsBuilder().AddMemoryAdapter();

            // Act
            var settings = builder.Build<IAppSettings>();

            // Assert
            settings.Name = "Douglas";
            Assert.AreEqual("Douglas", settings.Name);
        }

        [Test]
        public void Read_EnvAndMemoryAdapters_ReadsFromEnv()
        {
            var memData = new Hashtable()
            {
                ["Name"] = "Adams",
            };
            using (Env.SetVariable("Test.Name", "Douglas"))
            {
                var settings = new SettingsBuilder().AddEnvironmentVariableAdapter("Test.")
                                                    .AddMemoryAdapter(memData)
                                                    .Build<IAppSettings>();
                // Act
                var name = settings.Name;

                // Assert
                Assert.AreEqual("Adams", name);
            }
        }

        [Test]
        public void Read_MemoryAndEnvAdapters_ReadsFromMemory()
        {
            using (Env.SetVariable("Test.Name", "Douglas"))
            {
                var memData = new Hashtable()
                {
                    ["Name"] = "Adams",
                };
                var settings = new SettingsBuilder().AddMemoryAdapter(memData)
                                                    .AddEnvironmentVariableAdapter("Test.")
                                                    .Build<IAppSettings>();
                // Act
                var name = settings.Name;

                // Assert
                Assert.AreEqual("Adams", name);
            }
        }

        [Test]
        public void Read_ValueInFirstAndSecondAdapters_ReadsValueFromFirstAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var settings = new SettingsBuilder().Add(mem1)
                                                .Add(mem2)
                                                .Build<IAppSettings>();
            mem1["Name"] = "Douglas";
            mem2["Name"] = "Adams";

            // Act
            var name = settings.Name;

            // Assert
            Assert.AreEqual("Douglas", name);
        }

        [Test]
        public void Read_ValueOnlyInSecondAdapter_ReadsValueFromSecondAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var builder = new SettingsBuilder().Add(mem1, mem2);

            var settings = builder.Build<IAppSettings>();

            mem2["Name"] = "Adams";

            // Act
            var name = settings.Name;

            // Assert
            Assert.AreEqual("Adams", name);
        }

        [Test]
        public void Write_FirstAdapterIsReadOnly_WritesToSecondAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var settings = new SettingsBuilder().AddReadOnly(mem1)
                                                .Add(mem2)
                                                .Build<IAppSettings>();
            mem1["Name"] = "Unset";
            mem2["Name"] = "Unset";

            // Act
            settings.Name = "Adams";

            // Assert
            Assert.AreEqual("Unset", mem1["Name"]);
            Assert.AreEqual("Adams", mem2["Name"]);
        }

        [Test]
        public void Write_MultipleAdapters_WritesToFirstAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var builder = new SettingsBuilder().Add(mem1).Add(mem2);

            var settings = builder.Build<IAppSettings>();

            // Act
            settings.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", mem1["Name"]);
            Assert.IsNull(mem2["Name"]);
        }

        [Test]
        public void Write_MultipleAdaptersAddedAtOnce_WritesToFirstAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var builder = new SettingsBuilder().Add(mem1, mem2);
            var settings = builder.Build<IAppSettings>();

            // Act
            settings.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", mem1["Name"]);
            Assert.IsNull(mem2["Name"]);
        }
    }
}