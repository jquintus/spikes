namespace FunWithNinject.WhenInjected
{
    public class GoogleService : ServiceBase, IService
    {
        public GoogleService(ISomeUtility utility)
            : base(utility)

        {
        }
    }
}