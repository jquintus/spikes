namespace FunWithNinject.Web.Services
{
    /// <summary>
    /// Binding registered in <see cref="NinjectWebCommon"/>
    /// </summary>
    public interface IService
    {
        string AboutMessage { get; }

        string Title { get; }
    }
}