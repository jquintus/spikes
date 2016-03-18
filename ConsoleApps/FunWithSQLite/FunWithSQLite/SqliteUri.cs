using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace FunWithSQLite
{
    /// <summary>
    /// Sqlite FullUri= connection string syntax wants a string in the format file:///c:/temp/test.db3?password=pwd123
    /// However, .NET Uri does not support file uri with "?" query string.
    /// </summary>
    public class SqliteUri
    {
        public SqliteUri(FileInfo fileInfo, NameValueCollection queryParams)
        {
            FileInfo = fileInfo;
            QueryParams = queryParams;
        }

        public FileInfo FileInfo { get; }

        public string FormattedValue
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"file:///{FileInfo.FullName}".Replace("\\", "/"));

                if (QueryParams != null && QueryParams.Count > 0)
                {
                    sb.Append("?");

                    bool didOne = false;

                    var keys = QueryParams.AllKeys;
                    foreach (var key in keys)
                    {
                        if (didOne)
                        {
                            sb.Append("&");
                        }

                        sb.Append($"{key}={QueryParams[key]}");

                        didOne = true;
                    }
                }

                return sb.ToString();
            }
        }

        public NameValueCollection QueryParams { get; }

        public override string ToString() => FormattedValue;
    }
}