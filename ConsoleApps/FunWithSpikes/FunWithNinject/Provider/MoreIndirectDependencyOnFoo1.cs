using Ninject;

namespace FunWithNinject.Provider
{
    public class MoreIndirectDependencyOnFoo1
    {
        public MoreIndirectDependencyOnFoo1([Named(NamedFooProvider.Foo1)]IntermediateDependency dependency)
        {
            IntermediateDependency = dependency;
        }

        public IntermediateDependency IntermediateDependency { get; private set; }
    }
}