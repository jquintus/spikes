namespace FunWithNinject.AncestorBindings
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