namespace FunWithNinject
{
    public class MyService : IService
    {
        private readonly Dependency _d;
        private readonly string _name;

        public MyService(Dependency d, string name)
        {
            _d = d;
            _name = name;
        }

        public string Do()
        {
            return string.Format("{0}  {1}", _d.Prop, _name);
        }
    }
}