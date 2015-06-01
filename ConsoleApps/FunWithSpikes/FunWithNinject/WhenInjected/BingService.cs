namespace FunWithNinject.WhenInjected
{
    public class BingService : ServiceBase, IService
    {
        public BingService(ISomeUtility utility)
            : base(utility)
        {
        }
    }
}