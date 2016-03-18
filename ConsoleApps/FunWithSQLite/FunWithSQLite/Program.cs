using MasterDevs.Core.Utils;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static FunWithSQLite.SqlData;

namespace FunWithSQLite
{
    public class Program
    {
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
            try
            {
                using (var src = new SQLiteConnection(Src))
                using (var dst = new SQLiteConnection(Dst))
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
            var srcCount = ReadCount(Src);
            var dstCount = ReadCount(Dst);

            Console.WriteLine($"Source:  {srcCount}");
            Console.WriteLine($"dest:    {dstCount}");
        }

        private static void CreateSourceDb()
        {
            var file = new FileInfo(SrcFilePath);

            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            if (!file.Exists)
            {
                SQLiteConnection.CreateFile(file.FullName);
                Console.WriteLine("Created database with one table");
            }

            using (var con = new SQLiteConnection(Src))
            using (var cmd = new SQLiteCommand(SQL_CREATE, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void LotsOfSql(Signal s, string sql)
        {
            using (var con = new SQLiteConnection(Src))
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
            Thread.Sleep(TimeSpan.FromSeconds(30.5));
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