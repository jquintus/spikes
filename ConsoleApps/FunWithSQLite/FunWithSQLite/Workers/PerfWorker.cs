using FunWithSQLite.Db;
using MasterDevs.Core;
using MasterDevs.Core.Utils;
using System;

namespace FunWithSQLite.Workers
{
    public class PerfOptions
    {
        public const string VERB = "perf";

        [CommandLine.Option("loopCount", DefaultValue = 100)]
        public int LoopCount { get; set; }
    }

    public class PerfWorker
    {
        private readonly PerfOptions _options;

        public PerfWorker(PerfOptions options)
        {
            _options = options.RequireNotNull(nameof(options));
        }

        public void Work()
        {
            var db = new Database(SqlData.SrcFilePath, SqlData.SimpleSrc);
            db.CreateDb();

            Console.Write($"Counting {_options.LoopCount} inserts");
            using (DisposeWatch.Start(span => Console.WriteLine($":  {span.TotalSeconds} seconds")))
            {
                for (int i = 0; i < _options.LoopCount; i++)
                {
                    db.ExecuteNonQuery();
                }
            }
        }
    }
}