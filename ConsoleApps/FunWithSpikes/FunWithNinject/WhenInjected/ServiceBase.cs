namespace FunWithNinject.WhenInjected
{
    public class ServiceBase : IService
    {
        public ServiceBase(ISomeUtility utility)
        {
            Utility = utility;
        }

        public ISomeUtility Utility { get; set; }
    }
}