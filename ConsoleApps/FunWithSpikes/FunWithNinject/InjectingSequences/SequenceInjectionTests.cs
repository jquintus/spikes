using Ninject;
using NUnit.Framework;

namespace FunWithNinject.InjectingSequences
{
    [TestFixture]
    public class SequenceInjectionTests
    {
        [Test]
        public void DependsOnSequence_IEnumerableIsInjected_ConstructorsAreNotCalled()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<Foo>().To<Foo>().InTransientScope();

                // Act
                k.Get<IEnumerableOfFoo>();

                // Assert
                Assert.AreEqual(0, Foo.ConstructorCalled);
            }
        }

        [Test]
        public void DependsOnSequence_ListIsInjected_ConstructorsAreCalled()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<Foo>().To<Foo>().InTransientScope();

                // Act
                k.Get<ListOfFoo>();

                // Assert
                Assert.AreEqual(1, Foo.ConstructorCalled);
            }
        }
    }
}