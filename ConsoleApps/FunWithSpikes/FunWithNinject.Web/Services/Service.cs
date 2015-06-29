namespace FunWithNinject.Web.Services
{
    /// <summary>
    /// Binding registered in <see cref="NinjectWebCommon"/>
    /// </summary>
    public class Service : IService
    {
        public string AboutMessage { get { return "I'm a real service"; } }

        public string Title { get { return "Ninject in MVC5 is Easy"; } }
    }
}