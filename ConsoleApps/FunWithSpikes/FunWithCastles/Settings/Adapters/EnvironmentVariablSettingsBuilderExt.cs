namespace FunWithCastles.Settings.Adapters
{
    public static class EnvironmentVariablSettingsBuilderExt
    {
        public static ISettingsBuilder AddEnvironmentVariableAdapter(
            this ISettingsBuilder builder,
            string prefix = null)
        {
            return builder.Add(new EnvironmentVariableAdapter(prefix));
        }

        public static ISettingsBuilder AddReadOnlyEnvironmentVariableAdapter(
            this ISettingsBuilder builder,
            string prefix = null)
        {
            return builder.AddReadOnly(new EnvironmentVariableAdapter(prefix));
        }
    }
}