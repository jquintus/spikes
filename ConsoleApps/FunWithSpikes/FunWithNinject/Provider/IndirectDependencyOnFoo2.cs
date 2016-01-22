using Ninject;

namespace FunWithNinject.Provider
{
    public class IndirectDependencyOnFoo2
    {
        public IndirectDependencyOnFoo2([Named(NamedFooProvider.Foo2)]DirectDependency dependency)
        {
            DirectDependency = dependency;
        }

        public DirectDependency DirectDependency { get; private set; }
    }
}