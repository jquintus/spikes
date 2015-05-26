namespace PollySpike
{
    using NUnit.Framework;
    using Polly;
    using Polly.CircuitBreaker;
    using System;

    [TestFixture]
    public class CircutBreakerTests
    {
        [Test]
        public void CircuitBreaker()
        {
            // Assemble
            bool rethrown = false;
            bool circuitBroken = false;

            var policy = Policy.Handle<DivideByZeroException>()
                               .CircuitBreaker(2, TimeSpan.FromSeconds(5));

            // Act
            // ONE
            var result = TryExcute(1, policy);
            rethrown = rethrown || result.Item1;
            circuitBroken = circuitBroken || result.Item2;

            // TWO
            result = TryExcute(2, policy);
            rethrown = rethrown || result.Item1;
            circuitBroken = circuitBroken || result.Item2;

            // THREE
            result = TryExcute(3, policy);
            rethrown = rethrown || result.Item1;
            circuitBroken = circuitBroken || result.Item2;

            // Assert
            Assert.IsTrue(rethrown);
            Assert.IsTrue(circuitBroken);
        }

        private static Tuple<bool, bool> TryExcute(int retryCount, Policy policy)
        {
            int zero = 1 - 1;
            try
            {
                policy.Execute(() =>
                {
                    retryCount++;
                    Console.WriteLine("{0:H:mm:ss} attempt #{1}", DateTime.Now, retryCount);

                    var undefined = 5 / zero;
                });
            }
            catch (DivideByZeroException)
            {
                return new Tuple<bool, bool>(true, false);
            }
            catch (BrokenCircuitException)
            {
                return new Tuple<bool, bool>(false, true);
            }

            return new Tuple<bool, bool>(false, false);
        }
    }
}