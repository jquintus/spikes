using System.Collections;

namespace FunWithCastles.Settings.Adapters
{
    public static class MemorySettingsBuilderExt
    {
        public static SettingsBuilder AddMemoryAdapter(
            this SettingsBuilder builder,
            Hashtable data = null)
        {
            return builder.Add(new MemoryAdapter(data));
        }

        public static SettingsBuilder AddReadOnlyMemoryAdapter(
            this SettingsBuilder builder,
            Hashtable data = null)
        {
            return builder.AddReadOnly(new MemoryAdapter(data));
        }
    }
}