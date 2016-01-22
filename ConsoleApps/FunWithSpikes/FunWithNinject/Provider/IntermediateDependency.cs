namespace FunWithNinject.Provider
{
    public class IntermediateDependency
    {
        public IntermediateDependency(DirectDependency dependency)
        {
            DirectDependency = dependency;
        }

        public DirectDependency DirectDependency { get; private set; }
    }
}