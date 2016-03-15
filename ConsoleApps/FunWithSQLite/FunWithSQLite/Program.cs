using System;
using System.Data.SQLite;
using System.IO;

namespace FunWithSQLite
{
    public class Program
    {

        private static string _sourceDbFile = @"data\source.db";
        private static string _destDbFile = @"data\dest.db";
        private static string _sourceConnString = $@"Data Source=.\{_sourceDbFile};Version=3;";
        private static string _destConnString = $@"Data Source=.\{_destDbFile  };Version=3;";

        public static void Main(string[] args)
        {
            Work();
        }
        private static void Work()
        {
            CreateSourceDb();

            Backup();
        }

        private static void Backup()
        {
            using (var source = new SQLiteConnection(_sourceConnString))
            using (var destination = new SQLiteConnection(_destConnString))
            {
                source.Open();
                destination.Open();

                Console.WriteLine("Start Copy");
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
                Console.WriteLine("End  Copy");
            }
        }

        private static void CreateSourceDb()
        {
            if (!File.Exists(_sourceDbFile))
            {
                Directory.CreateDirectory("data");

                SQLiteConnection.CreateFile(_sourceDbFile);
                var sql = "create table Table1 (Name varchar(20), Value int)";
                using (var con = new SQLiteConnection(_sourceConnString))
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Created database with one table");
            }
        }
    }
}