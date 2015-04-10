namespace FunWithNinject
{
    using Ninject;
    using Ninject.Parameters;
    using Ninject.Syntax;

    public class MyServiceFactory : IMyServiceFactory
    {

        readonly IResolutionRoot resolutionRoot;

        public MyServiceFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public MyService Create(string name)
        {
            return resolutionRoot.Get<MyService>(
                new ConstructorArgument("name", name));
        }
    }
}