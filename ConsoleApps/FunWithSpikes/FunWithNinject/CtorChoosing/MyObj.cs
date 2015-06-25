namespace FunWithNinject.CtorChoosing
{
    public class MyObj
    {
        public MyObj(IFoo foo)
        {
        }

        public MyObj(IFoo foo, IBar bar)
        {
            this.Foo = foo;
            this.Bar= bar;
        }

        public IFoo Foo { get; set; }

        public IBar Bar { get; set; }
    }
}