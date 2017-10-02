using Ninject;
using Ninject.Extensions.NamedScope;
using Ninject.Infrastructure;
using NUnit.Framework;

namespace FunWithNinject.NamedScopes
{
    [TestFixture]
    public class NamedScopesTests
    {
        [Test]
        public void Get_FuncBoundInNamedScope_ResolvedFuncIsInSameScopeAsParent()
        {
            // This test depends on Ninject.Extensions.ContextPreservation being loaded.

            // Assemble
            using (var k = new StandardKernel())
            {
                Bind(k);

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

        [Test]
        public void Get_FuncBoundInNamedScopeHeldBySingletonScopedItem_FunctionOnlyResolvedOnce()
        {
            // This test depends on Ninject.Extensions.ContextPreservation being loaded.

            // Assemble
            using (var k = new StandardKernel())
            {
                Bind(k);
                k.Rebind<IHaveFunc>().To<HaveFunc>().InSingletonScope();


                // Act
                var root1 = k.Get<IRoot>();
                var root2 = k.Get<IRoot>();

                // Assert

                Assert.AreNotEqual(root1, root2);
                Assert.AreEqual(root1.ChildFuncHaver, root2.ChildFuncHaver);
                Assert.AreEqual(root1.ChildEventAggregator, root2.ChildEventAggregator);
                Assert.AreEqual(root1.EventAggregator, root1.ChildEventAggregator);
            }
        }

        [Test]
        public void Get_KernelDefaultsToSingleton_AllFuncsReturnSameEventAggregator()
        {
            // This test depends on Ninject.Extensions.ContextPreservation being loaded.

            // Assemble
            var settings = new NinjectSettings()
            {
                DefaultScopeCallback = StandardScopeCallbacks.Singleton,
            };

            using (var k = new StandardKernel(settings))
            {
                Bind(k);

                // Act
                var root1 = k.Get<IRoot>();
                var root2 = k.Get<IRoot>();

                // Assert

                Assert.AreEqual(root1.ChildEventAggregator, root2.ChildEventAggregator);
            }
        }

        private void Bind(IKernel k)
        {
            const string scope = "Telescope";
            k.Bind<IRoot>().To<Root>().DefinesNamedScope(scope);
            k.Bind<IHaveFunc>().To<HaveFunc>();
            k.Bind<IEventAggregator>().To<EventAggregator>().InNamedScope(scope);
        }
    }
}