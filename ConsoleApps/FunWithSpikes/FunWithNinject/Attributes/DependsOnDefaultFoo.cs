namespace FunWithNinject.Attributes
{
    public class DependsOnDefaultFoo
    {
        public DependsOnDefaultFoo(IFoo foo)
        {
            Foo = foo;
        }

        public IFoo Foo { get; }
    }
}