using MasterDevs.Core.Utils;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithSQLite
{
    public class Program
    {
        private static string _destConnString = $@"Data Source=.\data\dest.db3;Version=3;";
        private static string _sourceConnString = $@"Data Source=.\data\source.db3;Version=3;";

        private static string SQL_CREATE = @"CREATE TABLE IF NOT EXISTS Table1 (Name varchar(20), Value int)";
        private static string SQL_READ = @"SELECT * FROM Table1";
        private static string SQL_READ_COUNT = @"SELECT count ('x') FROM Table1";
        private static string SQL_WRITE = @"INSERT INTO Table1 (name, value) VALUES ('John', 4)";

        public static void Main(string[] args)
        {
            Work();

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
            }
        }

        private static void Backup()
        {
            using (var source = new SQLiteConnection(_sourceConnString))
            using (var destination = new SQLiteConnection(_destConnString))
            using (DisposeWatch.Start(e => Console.WriteLine($"Backup Completed in {e.TotalMilliseconds} ms")))
            {
                source.Open();
                destination.Open();

                Console.WriteLine("Start Copy");
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
                Console.WriteLine("End  Copy");
            }
        }

        private static void CompareCounts()
        {
            var sourceCount = ReadCount(_sourceConnString);
            var destCount = ReadCount(_destConnString);

            Console.WriteLine($"Source:  {sourceCount}");
            Console.WriteLine($"dest:    {destCount}");
        }

        private static void CreateSourceDb()
        {
            var connectionString = new SQLiteConnectionStringBuilder(_sourceConnString);
            var file = new FileInfo(connectionString.DataSource);

            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            if (!file.Exists)
            {
                SQLiteConnection.CreateFile(file.FullName);
                Console.WriteLine("Created database with one table");
            }

            using (var con = new SQLiteConnection(_sourceConnString))
            using (var cmd = new SQLiteCommand(SQL_CREATE, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void LotsOfSql(Signal s, string sql)
        {
            using (var con = new SQLiteConnection(_sourceConnString))
            using (var cmd = new SQLiteCommand(sql, con))
            {
                con.Open();
                while (s.KeepGoing)
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static long ReadCount(string connString)
        {
            var sql = SQL_READ_COUNT;
            using (var con = new SQLiteConnection(connString))
            using (var cmd = new SQLiteCommand(sql, con))
            {
                con.Open();
                var value = cmd.ExecuteScalar();
                return (long)value;
            }
        }

        private static void Work()
        {
            CreateSourceDb();

            var s = new Signal { KeepGoing = true };
            var t1 = Task.Factory.StartNew(() => LotsOfSql(s, SQL_WRITE));
            var t2 = Task.Factory.StartNew(() => LotsOfSql(s, SQL_READ));

            Console.WriteLine("Wait for some reads and writes to start");
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Backup();

            using (DisposeWatch.Start(e => Console.WriteLine($"Waited {e.TotalMilliseconds} ms")))
            {
                s.KeepGoing = false;

                Task.WaitAll(t1, t2);
            }

            CompareCounts();
        }

        private class Signal
        {
            public bool KeepGoing { get; set; }
        }
    }
}