namespace FunWithNinject.Interception.CacheInterceptor
{
    public class DataSource : IDataSource
    {
        private int _int = 10;
        public int GetInt() => _int++;
        public string GetString() => _int++.ToString();
    }
}
