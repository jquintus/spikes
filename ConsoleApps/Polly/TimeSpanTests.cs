namespace PollySpike
{
    using NUnit.Framework;
    using Polly;
    using System;

    [TestFixture]
    public class TimeSpanTests
    {
        [Test]
        public void TimeSpan_RetriesAndThrows()
        {
            // Assemble
            bool rethrown = false;
            int retryCount = 0;

            try
            {
                int zero = 1 - 1;
                Policy.Handle<DivideByZeroException>()
                      .WaitAndRetry(new TimeSpan[]
                      {
                         TimeSpan.FromMilliseconds(1),
                         TimeSpan.FromMilliseconds(1),
                         TimeSpan.FromMilliseconds(1),
                      }, (ex, ts) =>
                          {
                              retryCount++;
                              Console.WriteLine("Retry attempt #{0}", retryCount);
                          })
                      .Execute(() => 5 / zero);
            }
            catch (DivideByZeroException)
            {
                Assert.AreEqual(3, retryCount);
                rethrown = true;
            }

            Assert.IsTrue(rethrown);
        }
    }
}