using Ninject;
using Ninject.Extensions.Conventions;
using NUnit.Framework;

namespace FunWithNinject.Conventions
{
    [TestFixture]
    public class ConventionsTests
    {
        [Test]
        public void Bind_OneClassWithMultipleInterfaces_BindsOneInstanceToAll()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                kernel.Bind(k => k.FromThisAssembly()
                                  .SelectAllClasses()
                                  .InNamespaceOf<ConventionsTests>()
                                  .BindAllInterfaces()
                                  .Configure(b => b.InSingletonScope()));

                // Act
                var face1 = kernel.Get<IFace1>();
                var face2 = kernel.Get<IFace2>();

                // Assemble
                Assert.AreSame(face1, face2);
            }
        }

        [Test]
        public void Bind_ResolveGenericType_Works()
        {
            // Assemble
            using (var kernel = new StandardKernel())
            {
                kernel.Bind(k => k.FromThisAssembly()
                                  .SelectAllClasses()
                                  .InNamespaceOf<ConventionsTests>()
                                  .BindAllInterfaces()
                                  .Configure(b => b.InSingletonScope()));

                kernel.Bind<int>().ToConstant(27);
                kernel.Bind<string>().ToConstant("twenty seven");

                // Act
                var generic = kernel.Get<IGeneric<int, string>>();

                // Assemble
                Assert.AreEqual(27, generic.FirstProp);
                Assert.AreEqual("twenty seven", generic.SecondProp);
            }
        }

        #region Helper Classes/Interfaces

        public interface IFace1 { }

        public interface IFace2 { }

        public interface IGeneric<T1, T2>
        {
            T1 FirstProp { get; set; }
            T2 SecondProp { get; set; }
        }

        public class AllFaces : IFace1, IFace2 { }

        public class Generic<T1, T2> : IGeneric<T1, T2>
        {
            public Generic(T1 first, T2 second)
            {
                FirstProp = first;
                SecondProp = second;
            }

            public T1 FirstProp { get; set; }
            public T2 SecondProp { get; set; }
        }

        #endregion Helper Classes/Interfaces
    }
}