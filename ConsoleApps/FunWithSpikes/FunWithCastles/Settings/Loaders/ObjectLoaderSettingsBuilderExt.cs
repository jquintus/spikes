namespace FunWithCastles.Settings.Loaders
{
    public static class ObjectLoaderSettingsBuilderExt
    {
        public static SettingsBuilder LoadFromObject<T>(
            this SettingsBuilder builder,
            T data)
        {
            return builder.Load(new ObjectLoader<T>(data));
        }
    }
}