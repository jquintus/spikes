using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithSpikes
{
    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void OrderBy_MultipleOrderBys()
        {
            // Assemble
            var values = new[]
            {
                new { A = 1, B = 1, C = 1 },
                new { A = 2, B = 1, C = 2 },
                new { A = 2, B = 2, C = 3 },
                new { A = 3, B = 1, C = 4 },
                new { A = 3, B = 0, C = 5 },  // Highest A, lowest B
                new { A = 3, B = 2, C = 6 },
            };

            // Act
            var highestALowestB = from v in values
                                  orderby v.C ascending
                                  orderby v.B ascending
                                  orderby v.A descending
                                  select v;

            // Assert
            var first = highestALowestB.First();
            Assert.AreEqual(3, first.A);
            Assert.AreEqual(0, first.B);
            Assert.AreEqual(5, first.C);
        }

        [Test]
        public void OrderBy_OrderByBool_FalseIsFirst()
        {
            // Assemble
            var values = new[]
            {
                new { A = true, B = 1 },
                new { A = true, B = 2 },
                new { A = true, B = 3 },
                new { A = false, B = 4 },
                new { A = false, B = 5 },
                new { A = false, B = 6 },
            };

            // Act
            var ordered = from v in values
                          orderby v.B
                          orderby v.A
                          select v;

            // Assert
            Assert.AreEqual(4, ordered.First().B);
        }

        /// <summary>
        /// Sort a list of numbers as if I'm Bob Barker.
        /// The numbers should be ordered with the
        /// * Target
        /// * Numbers less than the target (with preference for the ones closest to Target)
        /// * Numbers greater than the target (with preference for the ones closest to Target)
        /// </summary>
        [Test]
        public void OrderBy_PricesRightRules()
        {
            // Assemble
            var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            var expected = new List<int> { 7, 6, 5, 4, 3, 2, 1, 8, 9, };
            var target = 7;

            // Act
            var ordered = from i in input
                          orderby Math.Abs(target - i) ascending
                          orderby i <= target descending
                          select i;
            // Assert
            CollectionAssert.AreEqual(expected, ordered);
        }

        [Test]
        public void ToList_AddingToList_DoesNotUpdateOriginalList()
        {
            // Assemble
            List<int> numbers = new List<int> { 1, 2, 4 };
            List<int> expected = new List<int> { 1, 2, 4 };

            // Act
            numbers.ToList().Add(5);

            // Assert
            CollectionAssert.AreEquivalent(expected, numbers);
        }

        [Test]
        public void ToList_ReturnsNewInstance()
        {
            // Assemble
            List<int> original = new List<int>();

            // Act
            var actual = original.ToList();

            // Assert
            actual.Should().NotBeSameAs(original);
        }
    }
}
