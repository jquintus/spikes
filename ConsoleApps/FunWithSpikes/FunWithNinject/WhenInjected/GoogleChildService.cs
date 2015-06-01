namespace FunWithNinject.WhenInjected
{
    public class GoogleChildService : GoogleService
    {
        public GoogleChildService(ISomeUtility utility)
            : base(utility)
        {
        }
    }
}