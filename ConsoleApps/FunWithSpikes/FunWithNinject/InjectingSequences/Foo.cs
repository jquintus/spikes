namespace FunWithNinject.InjectingSequences
{
    public class Foo
    {
        public Foo()
        {
            ConstructorCalled++;
        }

        public static int ConstructorCalled { get; private set; }
    }
}