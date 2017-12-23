namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
{
    public interface IDataSource
    {
        int TimesCalled { get; }

        int GetInt();
        string GetString();
    }
}
