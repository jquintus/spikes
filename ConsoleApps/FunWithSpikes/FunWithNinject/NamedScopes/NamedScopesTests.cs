using Ninject;
using Ninject.Extensions.NamedScope;
using NUnit.Framework;

namespace FunWithNinject.NamedScopes
{
    [TestFixture]
    public class NamedScopesTests
    {
        [Test]
        public void Get_FuncBoundInNamedScope_ResolvedFuncIsInSameScopeAsParent()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                const string scope = "Telescope";
                k.Bind<IRoot>().To<Root>().DefinesNamedScope(scope);
                k.Bind<IHaveFunc>().To<HaveFunc>();
                k.Bind<IEventAggregator>().To<EventAggregator>().InNamedScope(scope);

                // Act
                var root1 = k.Get<IRoot>();
                var root2 = k.Get<IRoot>();

                // Assert

                Assert.AreNotEqual(root1, root2);
                Assert.AreNotEqual(root1.ChildFuncHaver, root2.ChildFuncHaver);
                Assert.AreNotEqual(root1.ChildEventAggregator, root2.ChildEventAggregator);
                Assert.AreEqual(root1.EventAggregator, root1.ChildEventAggregator);
            }
        }
    }
}