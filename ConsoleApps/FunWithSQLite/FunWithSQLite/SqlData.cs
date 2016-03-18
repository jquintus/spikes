using System.Data.SQLite;
using static FunWithSQLite.ConnectionStringBuilder;

namespace FunWithSQLite
{
    public static class SqlData
    {
        public static string SQL_CREATE = @"CREATE TABLE IF NOT EXISTS Table1 (Name varchar(20), Value int)";
        public static string SQL_READ = @"SELECT * FROM Table1";
        public static string SQL_READ_COUNT = @"SELECT count ('x') FROM Table1";
        public static string SQL_WRITE = @"INSERT INTO Table1 (name, value) VALUES ('John', 4)";

        private static string _dstConnString = $@"Data Source=.\data\dst.db3;Version=3;Password=dst;";
        private static string _srcConnString = $@"Data Source=.\data\src.db3;Version=3;Password=src;";
        public static string Dst => GetZipConnectionString(_dstConnString);
        public static string Src => GetZipConnectionString(_srcConnString);

        public static string SrcFilePath => new SQLiteConnectionStringBuilder(_srcConnString).DataSource;
    }
}