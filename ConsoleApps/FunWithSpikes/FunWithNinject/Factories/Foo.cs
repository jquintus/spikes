namespace FunWithNinject.Factories
{
    public interface IFoo
    {
        int InternalRuntimeDependency { get; }
    }

    public class Foo : IFoo
    {
        private readonly IBar _bar;

        public Foo(IBar bar)
        {
            _bar = bar;
        }

        public int InternalRuntimeDependency { get { return _bar.RuntimeDependency; } }
    }
}