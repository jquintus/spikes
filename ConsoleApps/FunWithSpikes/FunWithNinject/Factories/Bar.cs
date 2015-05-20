namespace FunWithNinject.Factories
{
    public interface IBar
    {
         int RuntimeDependency { get; }
    }

    public class Bar : IBar
    {
        public Bar(int runtimeDependency)
        {
            RuntimeDependency = runtimeDependency;
        }

        public int RuntimeDependency { get; set; }
    }
}