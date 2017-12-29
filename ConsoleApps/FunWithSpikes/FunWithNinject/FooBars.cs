namespace FunWithNinject
{
    /*
     * So I don't have to create a whole bunch of dependencies
     * each time I want to create a new test, this file
     * contains a few simple interfaces with some dependencies.
     *
     * If anything more complicated is needed, it will be a good
     * idea to create new classes/dependencies specifically for
     * the tests that require them.
     */

    public interface IBar { }

    public interface IBaz { }

    public interface IFoo { }

    public interface IQux { }

    public class Bar : IBar { }

    public class Bar2 : IBar { }

    public class Baz : IBaz { }

    public class Foo : IFoo { }

    public class Foo1 : IFoo { }

    public class Foo2 : IFoo { }

    public class FooDependingOnBar : IFoo
    {
        public FooDependingOnBar(IBar bar)
        {
            Bar = bar;
        }

        public IBar Bar { get; set; }
    }

    public class FooDependingOnMultipleBars : IFoo
    {
        public FooDependingOnMultipleBars(IBar bar1, IBar bar2)
        {
            Bar1 = bar1;
            Bar2 = bar2;
        }

        public IBar Bar1 { get; set; }
        public IBar Bar2 { get; set; }
    }

    public class Qux : IQux { }
}