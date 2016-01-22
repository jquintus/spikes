namespace FunWithNinject.Provider
{
    public class DirectDependency
    {
        public DirectDependency(IFoo foo)
        {
            Foo = foo;
        }

        public IFoo Foo { get; private set; }
    }
}