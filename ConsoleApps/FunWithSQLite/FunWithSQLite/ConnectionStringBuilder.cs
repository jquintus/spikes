using System;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace FunWithSQLite
{
    public static class ConnectionStringBuilder
    {
        public static string GetSimpleConnString(string input)
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

        public static string GetZipConnectionString(string input)
        {
            var builder = new SQLiteConnectionStringBuilder(input);

            var fileInfo = new FileInfo(builder.DataSource);
            var pass = builder.Password;

            var uri = BuildUri(fileInfo, pass, true, false);
            var output = GetDotNetConnStr(uri, true, true);

            return output;
        }

        private static SqliteUri BuildUri(FileInfo fileInfo,
           string password,
           bool zipVfs,
           bool foreignKeysOn,
           SQLiteJournalModeEnum journalMode = SQLiteJournalModeEnum.Wal,
           SynchronizationModes synchronousity = SynchronizationModes.Full,
           int pageSize = 4096,
           int cacheSize = 2000,
           bool binaryGuid = false,
           bool failIfMissing = true)
        {
            CheckPageSize(pageSize);
            var nvc = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(password))
            {
                nvc.Add("password", password);
            }

            if (zipVfs && !string.IsNullOrWhiteSpace(password))
            {
                nvc.Add("vfs", "zipvfs");
                nvc.Add("zv", "zlib");
                nvc.Add("zipvfs_journal mode", journalMode.ToString());
            }
            else
            {
                nvc.Add("journal mode", journalMode.ToString());
            }

            nvc.Add("foreign keys", foreignKeysOn.ToString());
            nvc.Add("synchronous", synchronousity.ToString());
            nvc.Add("page size", pageSize.ToString());
            nvc.Add("cache size", cacheSize.ToString());
            nvc.Add("BinaryGuid", binaryGuid.ToString());
            nvc.Add("FailIfMissing", failIfMissing.ToString());

            return new SqliteUri(fileInfo, nvc);
        }

        /// <summary>
        /// Valid values are 2^n where result b/w 512 and 65536 (or 2^8 through 2^16th)
        /// </summary>
        /// <param name="pageSize"></param>
        private static void CheckPageSize(int pageSize)
        {
            if (pageSize < 512 || pageSize > 65536)
            {
                throw new ArgumentException($"pageSize {pageSize }");
            }

            var exp = Math.Log(pageSize) / Math.Log(2);
            var fractionalExp = Math.Truncate(exp) - exp;

            if (fractionalExp > 0.000001 || fractionalExp < -.000001)
            {
                throw new ArgumentException($"pageSize {pageSize }");
            }
        }

        private static string GetDotNetConnStr(SqliteUri dbUri, bool hasPassword, bool isZipVfs)
        {
            var sb = new StringBuilder();

            sb.Append($"FullUri={dbUri.FormattedValue};");

            if (isZipVfs && hasPassword)
            {
                sb.Append("ZipVfsVersion=v3;");
            }

            return sb.ToString();
        }
    }
}