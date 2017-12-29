namespace FunWithNinject.Attributes
{
    public class DependsOnSpecialFoo
    {
        public DependsOnSpecialFoo([SpecialFoo]IFoo foo)
        {
            Foo = foo;
        }

        public IFoo Foo { get; }
    }
}