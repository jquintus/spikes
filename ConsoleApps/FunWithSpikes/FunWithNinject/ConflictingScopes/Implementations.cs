namespace FunWithNinject.ConflictingScopes
{
    public class Inner
    {
    }

    public class Middle
    {
        public Middle(Inner inner)
        {
            Inner = inner;
        }

        public Inner Inner { get; }
    }

    public class Outer
    {
        public Outer(Middle middle)
        {
            Middle = middle;
        }

        public Middle Middle { get; }
    }
}