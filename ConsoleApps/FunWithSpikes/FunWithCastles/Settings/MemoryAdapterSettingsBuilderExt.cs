using System.Collections;

namespace FunWithCastles.Settings
{
    public static class SettingsBuilderExt
    {
        public static SettingsBuilder AddEnvironmentVariableAdapter(this SettingsBuilder builder, string prefix = null)
        {
            return builder.Add(new EnvironmentVariableAdapter(prefix));
        }

        public static SettingsBuilder AddMemoryAdapter(this SettingsBuilder builder, Hashtable data = null)
        {
            return builder.Add(new MemoryAdapter(data));
        }
    }
}