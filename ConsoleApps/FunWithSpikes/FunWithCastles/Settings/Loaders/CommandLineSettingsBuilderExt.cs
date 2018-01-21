using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public static class CommandLineSettingsBuilderExt
    {
        public static ISettingsBuilder LoadFromCommandLine(
            this ISettingsBuilder builder,
            IEnumerable<string> args,
            IDictionary<string, string> switchMappings = null,
            ISettingConverter converter = null)
        {
            return builder.Load(new CommandLineLoader(args, switchMappings), converter);
        }
    }
}