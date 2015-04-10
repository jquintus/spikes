namespace FunWithNinject
{
    public class Dependency : IDependency
    {
        public string Prop
        {
            get { return "I'm a dependency."; }
        }
    }
}