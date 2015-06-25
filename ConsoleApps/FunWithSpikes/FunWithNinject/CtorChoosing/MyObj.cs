namespace FunWithNinject.CtorChoosing
{
    public class MyObj
    {
        public MyObj(IFoo foo)
        {
            ShortCtorCalled = true;
            Foo = foo;
        }

        public MyObj(IFoo foo, IBar bar)
        {
            LongCtorCalled = true;
            this.Foo = foo;
            this.Bar= bar;
        }

        public IFoo Foo { get; set; }

        public IBar Bar { get; set; }

        public bool ShortCtorCalled { get; set; }

        public bool LongCtorCalled { get; set; }
    }
}