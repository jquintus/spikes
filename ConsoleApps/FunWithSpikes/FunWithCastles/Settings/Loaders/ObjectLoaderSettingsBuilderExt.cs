namespace FunWithCastles.Settings.Loaders
{
    public static class ObjectLoaderSettingsBuilderExt
    {
        public static ISettingsBuilder LoadFromObject<T>(
            this ISettingsBuilder builder,
            T data,
            ISettingConverter converter = null)
        {
            return builder.Load(new ObjectLoader<T>(data), converter);
        }
    }
}