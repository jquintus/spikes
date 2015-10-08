using NUnit.Framework;
using System;

namespace FunWithSpikes
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void MinusEquals_AfterFewerPlusEquals_RemovesAllLambdas()
        {
            // Assemble
            int lambdaCount = 0;
            int actionCount = 0;

            var lambda1 = new Action(() => lambdaCount++);
            Action jackson = new Action(() => actionCount++);

            // Act
            jackson += lambda1;
            jackson -= lambda1;
            jackson -= lambda1;
            jackson();

            // Assert
            Assert.AreEqual(0, lambdaCount);
            Assert.AreEqual(1, actionCount);
        }

        [Test]
        public void MinusEquals_AfterMorePlusEquals_RemovesAddedLambdas()
        {
            // Assemble
            int lambdaCount = 0;
            int actionCount = 0;
            var lambda1 = new Action(() => lambdaCount++);

            Action jackson = new Action(() => actionCount++);

            jackson();

            // Act
            jackson += lambda1;
            jackson += lambda1;
            jackson -= lambda1;
            jackson();

            // Assert
            Assert.AreEqual(1, lambdaCount);
            Assert.AreEqual(2, actionCount);
        }

        [Test]
        public void PlusEquals_RunsMultipleLambdas()
        {
            // Assemble
            int lambdaCount = 0;
            int actionCount = 0;
            var lambda1 = new Action(() => lambdaCount++);

            // Act
            Action jackson = new Action(() => actionCount++);
            jackson += lambda1;
            jackson += lambda1;

            jackson();

            // Assert
            Assert.AreEqual(2, lambdaCount);
            Assert.AreEqual(1, actionCount);
        }
    }
}