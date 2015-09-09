using Ninject;
using NUnit.Framework;

namespace FunWithNinject
{
    [TestFixture]
    public class InjectionTests
    {
        [Test]
        public void Get_ClassHasMultipleDependenciesOnTheSameType_DependencyIsSingleton_OneInstanceOfDependencyIsInjectedTwice()
        {
            // Assemble
            var k = new StandardKernel();
            k.Bind<IBar>().To<Bar>().InSingletonScope();

            // Act
            var foo = k.Get<FooDependingOnMultipleBars>();

            // Assert
            Assert.AreSame(foo.Bar1, foo.Bar2);
        }

        [Test]
        public void Get_ClassHasMultipleDependenciesOnTheSameType_DependencyIsTransient_TwoInstancesOfDependencyAreInjected()
        {
            // Assemble
            var k = new StandardKernel();
            k.Bind<IBar>().To<Bar>().InTransientScope();

            // Act
            var foo = k.Get<FooDependingOnMultipleBars>();

            // Assert
            Assert.AreNotSame(foo.Bar1, foo.Bar2);
        }
    }
}