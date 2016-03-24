using System.Data.SQLite;
using System.IO;

namespace FunWithSQLite.Db
{
    public class Database
    {
        public const string CREATE_TABLE_SQL = @"
CREATE TABLE MyTable (
        Id integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        Created varchar(28),
        LastModified varchar(28),
        MyColumn varchar(256) NOT NULL
);
";

        public const string INSERT_SQL = @"insert into MyTable (Created, LastModified, MyColumn) values ('2015-05-05-12:12:12', '2015-05-05-12:12:12', 'My value')";
        public const string READ_SQL = @"select count('x') from  MyTable";

        public Database(string fullPath, string connectionString) : this(fullPath, connectionString, "Mr. Database")
        {
        }

        public Database(string fullPath, string connectionString, string name)
        {
            Name = name;
            FullPath = fullPath;
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public string FullPath { get; }
        public string Name { get; }

        public void BackupTo(Database dstDb)
        {
            using (var src = new SQLiteConnection(this.ConnectionString))
            using (var dst = new SQLiteConnection(dstDb.ConnectionString))
            {
                src.Open();
                dst.Open();

                src.BackupDatabase(dst, "main", "main", -1, null, 0);
            }
        }

        public void CreateDb(string tableCreate = CREATE_TABLE_SQL)
        {
            if (File.Exists(FullPath)) File.Delete(FullPath);
            Directory.CreateDirectory(new FileInfo(FullPath).Directory.FullName);

            SQLiteConnection.CreateFile(FullPath);

            using (var con = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(tableCreate, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteNonQuery(string sql = INSERT_SQL)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public T ExecuteScalarQuery<T>(string sql = READ_SQL)
        {
            using (var con = new SQLiteConnection(ConnectionString))
            using (var cmd = new SQLiteCommand(sql, con))
            {
                con.Open();
                var result = cmd.ExecuteScalar();

                return (T)result;
            }
        }
    }
}