using Ninject;
using NUnit.Framework;

namespace FunWithNinject.Scope
{
    public class ScopeTests
    {
        #region Helper classes

        public interface IScare
        {
            void Scare();
        }

        public class Boo : IScare
        {
            public void Scare()
            {
                System.Console.WriteLine("Boo");
            }
        }

        public class RealMonster
        {
            public RealMonster(IScare scare1, IScare scare2)
            {
                Scare1 = scare1;
                Scare2 = scare2;
            }

            public IScare Scare1 { get; }
            public IScare Scare2 { get; }
        }

        #endregion Helper classes

        [Test]

        public void MultipleInstancesPassedToOneConstructor_SingletonScope_InstancesAreSame()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<IScare>().To<Boo>().InSingletonScope();

                // Act
                var monster = k.Get<RealMonster>();

                // Assert
                Assert.AreSame(monster.Scare1, monster.Scare2);
            }
        }

        [Test]
        public void MultipleInstancesPassedToOneConstructor_TransientScope_InstancesDiffer()
        {
            // Assemble
            using (var k = new StandardKernel())
            {
                k.Bind<IScare>().To<Boo>().InTransientScope();

                // Act
                var monster = k.Get<RealMonster>();

                // Assert
                Assert.AreNotSame(monster.Scare1, monster.Scare2);
            }
        }
    }
}