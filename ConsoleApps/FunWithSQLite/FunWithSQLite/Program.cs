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
        private static string _dstConnString = $@"Data Source=.\data\dst.db3;Version=3;Password=src;";
        private static string _srcConnString = $@"Data Source=.\data\src.db3;Version=3;Password=dst;";

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

        private static string GetConnString(string input)
        {
            var cb = new SQLiteConnectionStringBuilder(input)
            {
                ReadOnly = false,
                ForeignKeys = false,
                SyncMode = SynchronizationModes.Full,
                //JournalMode = SQLiteJournalModeEnum.Wal,
                FailIfMissing = false,
                BinaryGUID = false,
            };


            return cb.ToString();
        }
        private static void Backup()
        {
            try
            {
                string srcC = GetConnString(_srcConnString);
                string dstC = GetConnString(_dstConnString);

                using (var src = new SQLiteConnection(srcC))
                using (var dst = new SQLiteConnection(dstC))
                using (DisposeWatch.Start(e => Console.WriteLine($"Backup Completed in {e.TotalMilliseconds} ms")))
                {
                    src.Open();
                    dst.Open();

                    Console.WriteLine("Start Copy");
                    src.BackupDatabase(dst, "main", "main", -1, null, 0);
                    Console.WriteLine("End  Copy");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Couldn't copy");
                Console.WriteLine(ex.Message);
            }
        }

        private static void CompareCounts()
        {
            var srcCount = ReadCount(_srcConnString);
            var dstCount = ReadCount(_dstConnString);

            Console.WriteLine($"Source:  {srcCount}");
            Console.WriteLine($"dest:    {dstCount}");
        }

        private static void CreateSourceDb()
        {
            var connectionString = new SQLiteConnectionStringBuilder(_srcConnString);
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

            using (var con = new SQLiteConnection(_srcConnString))
            using (var cmd = new SQLiteCommand(SQL_CREATE, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void LotsOfSql(Signal s, string sql)
        {
            using (var con = new SQLiteConnection(_srcConnString))
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Couldn't read count from {connString}");
                Console.WriteLine(ex.Message);
                return -1;
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
