﻿using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public static class CommandLineSettingsBuilderExt
    {
        public static SettingsBuilder LoadFromCommandLine(
            this SettingsBuilder builder,
            IEnumerable<string> args,
            IDictionary<string, string> switchMappings = null)
        {
            return builder.Load(new CommandLineLoader(args, switchMappings));
        }
    }
}