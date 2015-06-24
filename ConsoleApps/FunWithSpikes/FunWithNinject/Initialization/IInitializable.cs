namespace FunWithNinject.Initialization
{
    public interface IInitializable
    {
        bool IsInit { get; }

        void Init();
    }

    public class Initializable : IInitializable
    {
        public bool CalledMe { get; set; }

        public bool IsInit { get; set; }

        public void CallMe()
        {
            CalledMe = true;
        }

        public void Init()
        {
            IsInit = true;
        }
    }
}