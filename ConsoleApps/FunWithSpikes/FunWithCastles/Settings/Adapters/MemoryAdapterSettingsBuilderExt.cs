using System.Collections;

namespace FunWithCastles.Settings.Adapters
{
    public static class SettingsBuilderExt
    {
        public static SettingsBuilder AddEnvironmentVariableAdapter(
            this SettingsBuilder builder,
            string prefix = null)
        {
            return builder.Add(new EnvironmentVariableAdapter(prefix));
        }

        public static SettingsBuilder AddMemoryAdapter(
            this SettingsBuilder builder,
            Hashtable data = null)
        {
            return builder.Add(new MemoryAdapter(data));
        }

        public static SettingsBuilder AddRegistryAdapter(
            this SettingsBuilder builder,
            string root)
        {
            return builder.Add(new RegistryAdapter(root));
        }
    }
}