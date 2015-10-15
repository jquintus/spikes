using Ninject;

namespace FunWithNinject.NamedBindings
{
    public class Root
    {
        public Root(
        [Named("One")] LevelTwo one,
        [Named("Two")] LevelTwo two)
        {
            One = one;
            Two = two;
        }

        public LevelTwo One { get; }
        public LevelTwo Two { get; }
    }
}