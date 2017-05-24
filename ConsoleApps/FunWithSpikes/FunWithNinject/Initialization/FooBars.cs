namespace FunWithNinject.Initialization
{
    public class FooBars
    {
        public interface IFoo
        {
            string ExtraInfo { get; }
        }
        public interface IFoo1 : IFoo { }
        public interface IFoo2 : IFoo { }
        public interface IBar { }
        public class Bar : IBar { }
        public class Foo : IFoo1, IFoo2
        {
            public Foo(IBar bar, string extraInfo)
            {
                ExtraInfo = extraInfo;
            }

            public string ExtraInfo { get; }
        }
    }
}