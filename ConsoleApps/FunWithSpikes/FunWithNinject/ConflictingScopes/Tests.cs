using Ninject;
using NUnit.Framework;

namespace FunWithNinject.ConflictingScopes
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void OutterDependsOnInner_AllAreTransient_TwoOfEverything()
        {
            using (var k = new StandardKernel())
            {
                // Assemble
                k.Bind<Outer>().ToSelf().InTransientScope();
                k.Bind<Middle>().ToSelf().InTransientScope();
                k.Bind<Inner>().ToSelf().InTransientScope();

                // Act
                var first = k.Get<Outer>();
                var second = k.Get<Outer>();

                // Assert
                Assert.AreNotSame(first, second);
                Assert.AreNotSame(first.Middle, second.Middle);
                Assert.AreNotSame(first.Middle.Inner, second.Middle.Inner);
            }
        }

        [Test]
        public void OutterDependsOnInner_MiddleIsSingleton_OnlyOneMiddle()
        {
            using (var k = new StandardKernel())
            {
                // Assemble
                k.Bind<Outer>().ToSelf().InTransientScope();
                k.Bind<Middle>().ToSelf().InSingletonScope();
                k.Bind<Inner>().ToSelf().InTransientScope();

                // Act
                var first = k.Get<Outer>();
                var second = k.Get<Outer>();

                // Assert
                Assert.AreNotSame(first, second);
                Assert.AreSame(first.Middle, second.Middle);
                Assert.AreSame(first.Middle.Inner, second.Middle.Inner);
            }
        }

        [Test]
        public void OutterDependsOnInner_OutterIsSinglton_InnerIsTransient_OnlyOneInnerIsCreated()
        {
            using (var k = new StandardKernel())
            {
                // Assemble
                k.Bind<Outer>().ToSelf().InSingletonScope();
                k.Bind<Middle>().ToSelf().InTransientScope();
                k.Bind<Inner>().ToSelf().InTransientScope();

                // Act
                var first = k.Get<Outer>();
                var second = k.Get<Outer>();

                // Assert
                Assert.AreSame(first, second);
                Assert.AreSame(first.Middle, second.Middle);
                Assert.AreSame(first.Middle.Inner, second.Middle.Inner);
            }
        }
    }
}