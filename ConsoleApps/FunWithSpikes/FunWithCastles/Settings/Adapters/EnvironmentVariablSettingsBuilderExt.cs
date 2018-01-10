namespace FunWithCastles.Settings.Adapters
{
    public static class EnvironmentVariablSettingsBuilderExt
    {
        public static SettingsBuilder AddEnvironmentVariableAdapter(
            this SettingsBuilder builder,
            string prefix = null)
        {
            return builder.Add(new EnvironmentVariableAdapter(prefix));
        }

        public static SettingsBuilder AddReadOnlyEnvironmentVariableAdapter(
            this SettingsBuilder builder,
            string prefix = null)
        {
            return builder.AddReadOnly(new EnvironmentVariableAdapter(prefix));
        }
    }
}