namespace FunWithCastles.Settings.Adapters
{
    public static class RegistrySettingsBuilderExt
    {
        public static ISettingsBuilder AddReadOnlyRegistryAdapter(
            this ISettingsBuilder builder,
            string root)
        {
            return builder.AddReadOnly(new RegistryAdapter(root));
        }

        public static ISettingsBuilder AddRegistryAdapter(
            this ISettingsBuilder builder,
            string root)
        {
            return builder.Add(new RegistryAdapter(root));
        }
    }
}