using Ninject;

namespace FunWithNinject.Provider
{
    public class IndirectDependencyOnFoo1
    {
        public IndirectDependencyOnFoo1([Named(NamedFooProvider.Foo1)]DirectDependency dependency)
        {
            DirectDependency = dependency;
        }

        public DirectDependency DirectDependency { get; private set; }
    }
}