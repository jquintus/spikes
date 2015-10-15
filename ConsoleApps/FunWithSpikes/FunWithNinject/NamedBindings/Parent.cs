using Ninject;

namespace FunWithNinject.NamedBindings
{
    public class Parent
    {
        public Parent(
            [Named("One")] Leaf one,
            [Named("Two")] Leaf two)
        {
            One = one;
            Two = two;
        }

        public Leaf One { get; }
        public Leaf Two { get; }
    }
}