namespace FunWithNinject.Interception.CacheInterceptor
{
    public interface IDataSource
    {
        int TimesCalled { get; }

        int GetInt();
        string GetString();
    }
}
