namespace FunWithCastles.Settings.Adapters
{
    public static class RegistrySettingsBuilderExt
    {
        public static ISettingsBuilder AddReadOnlyRegistryAdapter(
            this ISettingsBuilder builder,
            string root,
            ISettingConverter converter = null)
        {
            return builder.AddReadOnly(new RegistryAdapter(root), converter);
        }

        public static ISettingsBuilder AddRegistryAdapter(
            this ISettingsBuilder builder,
            string root,
            ISettingConverter converter = null)
        {
            return builder.Add(new RegistryAdapter(root), converter);
        }
    }
}