using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static FunWithCastles.FieldNames;

namespace FunWithCastles
{
    [TestFixture]
    public class DictionaryAdapterTests
    {
        [Test]
        public void Get_ReferenceTypeDoesNotExistsInDictionary_ReturnsNull()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>();
            var adapter = CreateSettings(dictionary);

            // Act
            var name = adapter.Name;

            // Assert
            Assert.IsNull(name);
        }

        [Test]
        public void Get_ValueExistsInDictionary_ReturnsCorrectValue()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>
            {
                [MAX] = "42",
                [NAME] = "Douglas",
            };

            var adapter = CreateSettings(dictionary);

            // Act
            var max = adapter.MaxItems;
            var name = adapter.Name;

            // Assert
            Assert.AreEqual(42, max);
            Assert.AreEqual("Douglas", name);
        }

        [Test]
        public void Get_ValueTypeDoesNotExistsInDictionary_ReturnsDefault()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>();
            var adapter = CreateSettings(dictionary);

            // Act
            var max = adapter.MaxItems;

            // Assert
            Assert.AreEqual(0, max);
        }

        [Test]
        public void Set_ValueDoesNotExistInDictionary_AddsValue()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>();
            var adapter = CreateSettings(dictionary);

            // Act
            adapter.Name = "Douglas";

            // Assert
            Assert.AreEqual("Douglas", dictionary[NAME]);
        }

        [Test]
        public void Set_ValueExistsInDictionary_OverWritesValue()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>
            {
                [NAME] = "Douglas",
            };
            var adapter = CreateSettings(dictionary);

            // Act
            adapter.Name = "Adams";

            // Assert
            Assert.AreEqual("Adams", dictionary[NAME]);
        }

        [Test]
        public void Set_ValueIsDate_SavesDate()
        {
            // Assemble
            var dictionary = new System.Collections.Hashtable();
            var adapter = CreateSettings(dictionary);

            var actualDate = new DateTime(1979, 10, 12);

            // Act
            adapter.LastModified = actualDate;

            // Assert
            Assert.AreEqual(actualDate, dictionary[DATE]);
        }

        [Test]
        public void Set_ValueIsNotAStringAndDictionaryIsNotTyped_SavesValue()
        {
            // Assemble
            var dictionary = new System.Collections.Hashtable();
            var adapter = CreateSettings(dictionary);

            // Act
            adapter.MaxItems = 42;

            // Assert
            Assert.AreEqual(42, dictionary[MAX]);
        }

        [Test]
        public void Set_ValueIsNotAStringAndDictionaryIsTyped_ThrowsArgumentException()
        {
            // Assemble
            var dictionary = new Dictionary<string, string>();
            var adapter = CreateSettings(dictionary);

            // Act
            Assert.Throws<ArgumentException>(() => adapter.MaxItems = 42);
        }

        private static ISettings CreateSettings(System.Collections.IDictionary dictionary)
        {
            var factory = new DictionaryAdapterFactory();
            var adapter = factory.GetAdapter<ISettings>(dictionary);
            return adapter;
        }
    }
}