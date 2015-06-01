namespace FunWithNinject.WhenInjected
{
    public class BingChildService : BingService
    {
        public BingChildService(ISomeUtility utility)
            : base(utility)
        {
        }
    }
}