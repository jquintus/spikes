namespace FunWithSpikes
{
    using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
    public class FunWithTasks
    {
        [Test]
        public void WaitAll_CalledWithCompletedTask_DoesNotExplode()
        {
            // Assemble
            int ray = 0;
            int egon = 0;
            Task t1 =  Task.Factory.StartNew (() => ray++);
            Task t2 =  Task.Factory.StartNew (() => egon++);

            // Act
            Task.WaitAll(t1);
            Task.WaitAll(t1, t2);

            // Assert
            Assert.AreEqual(1, ray);
            Assert.AreEqual(1, egon);

        }
    }
}