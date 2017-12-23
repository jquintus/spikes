namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
{
    [CacheInterface]
    public interface IDataSource
    {
        int TimesCalled { get; }

        int GetInt();
        string GetString();
    }
}
