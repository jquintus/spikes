using CommandLine;
using FunWithSQLite.Workers;

namespace FunWithSQLite
{
    public class ProgramOptions
    {
        [VerbOption(BackupOptions.VERB)]
        public BackupOptions Backup { get; set; }

        [VerbOption(PerfOptions.VERB)]
        public PerfOptions Perf { get; set; }
    }
}