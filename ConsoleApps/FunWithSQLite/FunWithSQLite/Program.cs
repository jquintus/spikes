using CommandLine;
using FunWithSQLite.Workers;
using System;
using System.Diagnostics;

namespace FunWithSQLite
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var parser = new Parser(settings => { new ParserSettings(Console.Error) { CaseSensitive = false }; });

            string invokedVerb = null;
            object invokedVerbInstance = null;

            var options = new ProgramOptions();
            if (!Parser.Default.ParseArguments(args, options,
              (verb, subOptions) =>
              {
                  invokedVerb = verb;
                  invokedVerbInstance = subOptions;
              }))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            switch (invokedVerb.ToLower())
            {
                case BackupOptions.VERB:
                    new BackupWorker((BackupOptions)invokedVerbInstance).Work();
                    break;

                case PerfOptions.VERB:
                    new PerfWorker((PerfOptions)invokedVerbInstance).Work();
                    break;

                default:
                    break;
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
            }
        }
    }
}