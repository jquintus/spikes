using Ninject;
using NUnit.Framework;
using System.Threading;

namespace FunWithNinject.Initialization
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BindWithConstructorArgument_PassedInAsAdditionalArgument()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                const string extra1 = "Extra Data For Foo1";
                const string extra2 = "Extra Data For Foo2:  I pity the FOO1";

                k.Bind<FooBars.IBar>().To<FooBars.Bar>();
                k.Bind<FooBars.IFoo1>().To<FooBars.Foo>().WithConstructorArgument(extra1);
                k.Bind<FooBars.IFoo2>().To<FooBars.Foo>().WithConstructorArgument(extra2);

                // Act
                var foo1 = k.Get<FooBars.IFoo1>();
                var foo2 = k.Get<FooBars.IFoo2>();

                // Assert
                Assert.AreEqual(extra1, foo1.ExtraInfo);
                Assert.AreEqual(extra2, foo2.ExtraInfo);
            }
        }

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

        [Test]
        public void OnActivation_RunsSyncrhonously()
        {
            var currentId = Thread.CurrentThread.ManagedThreadId;
            var k = new StandardKernel();
            k.Bind<IFoo>()
                .To<Foo>()
                .OnActivation(i =>
                {
                    Assert.AreEqual(currentId, Thread.CurrentThread.ManagedThreadId);
                });
        }
    }
}