namespace FunWithNinject.AncestorBindings
{
    public class SingleLevel
    {
        public SingleLevel(Leaf leaf)
        {
            Leaf = leaf;
        }

        public Leaf Leaf { get; }
    }
}