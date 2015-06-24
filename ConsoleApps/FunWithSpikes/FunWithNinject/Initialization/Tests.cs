namespace FunWithNinject.Initialization
{
    using Ninject;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void OnActivation_CanCallMethodOnImplementation()
        {
            // Assemble
            var k = new StandardKernel();
            k.Bind<IInitializable>()
                .To<Initializable>()
                .OnActivation(i => i.CallMe());

            // Act
            var initted = k.Get<IInitializable>();

            // Assert
            Assert.IsTrue(((Initializable)initted).CalledMe);
        }

        [Test]
        public void OnActivation_CanCallMethodOnInterface()
        {
            // Assemble
            var k = new StandardKernel();
            k.Bind<IInitializable>()
                .To<Initializable>()
                .OnActivation(i => i.Init());

            // Act
            var initted = k.Get<IInitializable>();

            // Assert
            Assert.IsTrue(initted.IsInit);
        }
    }
}