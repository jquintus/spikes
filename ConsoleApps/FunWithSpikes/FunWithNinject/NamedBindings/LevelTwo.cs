namespace FunWithNinject.NamedBindings
{
    public class LevelTwo
    {
        public LevelTwo(LevelThree three)
        {
            Three = three;
        }

        public LevelThree Three { get; }
    }
}