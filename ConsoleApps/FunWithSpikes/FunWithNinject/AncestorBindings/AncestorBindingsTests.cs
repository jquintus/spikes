using Ninject;
using NUnit.Framework;

namespace FunWithNinject.AncestorBindings
{
    [TestFixture]
    public class AncestorBindingsTests
    {
        [Test]
        public void Named_NamedAndUnnamedInstanceRegisters_Throws()
        {
            using (var k = new StandardKernel())
            {
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "One" }).Named("One");
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "Not named" });

                // Act
                Assert.Throws<ActivationException>(() => k.Get<SingleLevel>());
            }
        }

        [Test]
        public void NamedParameters_MultiLeveled_Resolves()
        {
            using (var k = new StandardKernel())
            {
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "One" }).WhenAnyAncestorNamed("One");
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "Two" }).WhenAnyAncestorNamed("Two");
                k.Bind<LevelTwo>().ToSelf().Named("One");
                k.Bind<LevelTwo>().ToSelf().Named("Two");

                // Act
                var root = k.Get<Root>();

                // Assert
                Assert.AreEqual("One", root.One.Three.Leaf.Name);
                Assert.AreEqual("Two", root.Two.Three.Leaf.Name);
            }
        }

        [Test]
        public void WhenAnyAncestorNamed_OneLevel_Throws()
        {
            using (var k = new StandardKernel())
            {
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "One" }).WhenAnyAncestorNamed("One");
                k.Bind<Leaf>().ToConstant(new Leaf { Name = "Two" }).WhenAnyAncestorNamed("Two");

                // Act
                Assert.Throws<ActivationException>(() => k.Get<Parent>());
            }
        }
    }
}