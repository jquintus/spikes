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

    public class Qux : IQux { }
}