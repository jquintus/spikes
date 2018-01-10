﻿using System.Collections.Generic;

namespace FunWithCastles.Settings.Adapters
{
    public static class MemorySettingsBuilderExt
    {
        public static SettingsBuilder AddMemoryAdapter(
            this SettingsBuilder builder,
            IDictionary<string, object> data = null)
        {
            return builder.Add(new MemoryAdapter(data));
        }

        public static SettingsBuilder AddReadOnlyMemoryAdapter(
            this SettingsBuilder builder,
            IDictionary<string, object> data = null)
        {
            return builder.AddReadOnly(new MemoryAdapter(data));
        }
    }
}