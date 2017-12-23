namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
{
    public class DataSource : IDataSource
    {
        private int _int = 10;
        public int TimesCalled { get; set; }

        public int GetInt()
        {
            TimesCalled++;
            return _int++;
        }
        public string GetString()
        {
            TimesCalled++;
            return _int++.ToString();
        }

    }
}
