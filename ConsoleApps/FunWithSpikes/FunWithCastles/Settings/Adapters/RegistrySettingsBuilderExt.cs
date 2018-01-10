namespace FunWithCastles.Settings.Adapters
{
    public static class RegistrySettingsBuilderExt
    {
        public static SettingsBuilder AddReadOnlyRegistryAdapter(
            this SettingsBuilder builder,
            string root)
        {
            return builder.AddReadOnly(new RegistryAdapter(root));
        }

        public static SettingsBuilder AddRegistryAdapter(
                    this SettingsBuilder builder,
            string root)
        {
            return builder.Add(new RegistryAdapter(root));
        }
    }
}