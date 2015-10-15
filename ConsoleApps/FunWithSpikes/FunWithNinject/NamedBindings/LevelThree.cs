namespace FunWithNinject.NamedBindings
{
    public class LevelThree
    {
        public LevelThree(Leaf leaf)
        {
            Leaf = leaf;
        }
        public Leaf Leaf { get; }
    }
}