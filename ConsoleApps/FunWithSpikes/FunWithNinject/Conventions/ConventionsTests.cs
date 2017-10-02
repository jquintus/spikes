using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;

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
    }

    public interface IFace1 { }
    public interface IFace2 { }
    public class AllFaces : IFace1, IFace2 { }
}
