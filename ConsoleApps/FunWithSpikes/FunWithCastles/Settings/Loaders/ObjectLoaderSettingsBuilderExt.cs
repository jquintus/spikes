namespace FunWithCastles.Settings.Loaders
{
    public static class ObjectLoaderSettingsBuilderExt
    {
        public static ISettingsBuilder LoadFromObject<T>(
            this ISettingsBuilder builder,
            T data)
        {
            return builder.Load(new ObjectLoader<T>(data));
        }
    }
}