using Ninject;

namespace FunWithNinject.Provider
{
    public class DirectDualDependency
    {
        public DirectDualDependency(
        [Named(NamedFooProvider.Foo1)]IFoo firstFoo,
        [Named(NamedFooProvider.Foo2)]IFoo secondFoo
        )
        {
            FirstFoo = firstFoo;
            SecondFoo = secondFoo;
        }

        public IFoo FirstFoo { get; }
        public IFoo SecondFoo { get; }
    }
}