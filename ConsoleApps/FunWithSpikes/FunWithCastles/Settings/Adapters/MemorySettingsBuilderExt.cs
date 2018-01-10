﻿using System.Collections.Generic;

namespace FunWithCastles.Settings.Adapters
{
    public static class MemorySettingsBuilderExt
    {
        public static ISettingsBuilder AddMemoryAdapter(
            this ISettingsBuilder builder,
            IDictionary<string, object> data = null)
        {
            return builder.Add(new MemoryAdapter(data));
        }

        public static ISettingsBuilder AddReadOnlyMemoryAdapter(
            this ISettingsBuilder builder,
            IDictionary<string, object> data = null)
        {
            return builder.AddReadOnly(new MemoryAdapter(data));
        }
    }
}