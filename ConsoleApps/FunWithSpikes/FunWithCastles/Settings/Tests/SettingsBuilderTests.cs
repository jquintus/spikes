using FunWithCastles.Settings.Adapters;
using FunWithCastles.Settings.Loaders;
using FunWithCastles.Settings.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Tests
{
    [TestFixture]
    public class SettingsBuilderTests
    {
        [Test]
        public void AddDefault_InstanceSuppliedForDefault_CanReadDefault()
        {
            // Assemble
            var defaultValues = new DefaultTestSettings
            {
                Name = "Adams",
            };

            var settings = SettingsBuilder.Create()
                                          .LoadFromObject(defaultValues)
                                          .Build<ITestSettings>();
            // Act
            var name = settings.Name;
            var answer = settings.TheAnswer;

            // Assert
            Assert.AreEqual("Adams", name);
            Assert.AreEqual(42, answer);
        }

        [Test]
        public void AddDefault_NonDefaultDoesNotHaveAValue_ReturnsValueFromDefault()
        {
            // Assemble
            var settings = SettingsBuilder.Create()
                                          .StartMapping<IAppSettings>()
                                          .Map(s => s.Name, "Adams")
                                          .Build<IAppSettings>();
            // Act
            var name = settings.Name;

            // Assert
            Assert.AreEqual("Adams", name);
        }

        [Test]
        public void Build_OneAdapter_CreatesSettingsObject()
        {
            // Assemble
            var builder = SettingsBuilder.Create()
                                         .AddMemoryAdapter();

            // Act
            var settings = builder.Build<IAppSettings>();

            // Assert
            settings.Name = "Douglas";
            Assert.AreEqual("Douglas", settings.Name);
        }

        [Test]
        public void Load_DefaultConverter_ConvertsDateTime()
        {
            // Assemble
            var args = new[] { "--TotalTime", "7:1:20:33.4" };
            var settings = SettingsBuilder.Create()
                                          .LoadFromCommandLine(args)
                                          .Build<ITestSettings>();
            var expected = new TimeSpan(
                days: 7,
                hours: 1,
                minutes: 20,
                seconds: 33,
                milliseconds: 400);

            // Act
            var date = settings.TotalTime;

            // Assert
            Assert.AreEqual(expected, date);
        }

        [Test]
        public void Load_DefaultConverter_ConvertsInts()
        {
            // Assemble
            var args = new[] { "--TheAnswer", "42" };
            var settings = SettingsBuilder.Create()
                                          .LoadFromCommandLine(args)
                                          .Build<ITestSettings>();
            // Act
            var answer = settings.TheAnswer;

            // Assert
            Assert.AreEqual(42, answer);
        }

        [Test]
        public void Load_DefaultConverter_ConvertsTimeSpan()
        {
            // Assemble
            var args = new[] { "--Date", "2012-3-4" };
            var settings = SettingsBuilder.Create()
                                          .LoadFromCommandLine(args)
                                          .Build<ITestSettings>();
            // Act
            var date = settings.Date;

            // Assert
            Assert.AreEqual(new DateTime(2012, 3, 4), date);
        }

        [Test]
        public void Read_EnvAndMemoryAdapters_ReadsFromEnv()
        {
            var memData = new Dictionary<string, object>
            {
                ["Name"] = "Adams",
            };
            using (Env.SetVariable("Test.Name", "Douglas"))
            {
                var settings = SettingsBuilder.Create()
                                              .AddMemoryAdapter(memData)
                                              .AddEnvironmentVariableAdapter("Test.")
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
                var memData = new Dictionary<string, object>
                {
                    ["Name"] = "Adams",
                };
                var settings = SettingsBuilder.Create()
                                              .AddMemoryAdapter(memData)
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

            var settings = SettingsBuilder.Create()
                                          .Add(mem1)
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

            var builder = SettingsBuilder.Create()
                                         .Add(mem1)
                                         .Add(mem2);

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

            var settings = SettingsBuilder.Create()
                                          .AddReadOnly(mem1)
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

            var builder = SettingsBuilder.Create()
                                         .Add(mem1)
                                         .Add(mem2);

            var settings = builder.Build<IAppSettings>();

            // Act
            settings.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", mem1["Name"]);
            Assert.IsFalse(mem2.CanRead("Name"));
        }

        [Test]
        public void Write_MultipleAdaptersAddedAtOnce_WritesToFirstAdapter()
        {
            // Assemble
            var mem1 = new MemoryAdapter();
            var mem2 = new MemoryAdapter();

            var builder = SettingsBuilder.Create()
                                         .Add(mem1)
                                         .Add(mem2);
            var settings = builder.Build<IAppSettings>();

            // Act
            settings.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", mem1["Name"]);
            Assert.IsFalse(mem2.CanRead("Name"));
        }
    }
}