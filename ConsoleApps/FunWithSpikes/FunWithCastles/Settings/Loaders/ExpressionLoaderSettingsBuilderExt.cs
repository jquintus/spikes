using System;
using System.Linq.Expressions;

namespace FunWithCastles.Settings.Loaders
{
    public static class ExpressionLoaderSettingsBuilderExt
    {
        public static ExpressionLoaderSettingsBuilder<TMapper> Map<TMapper, TProp>(
            this ISettingsBuilder builder,
            Expression<Func<TMapper, TProp>> expression,
            TProp value)
        {
            return builder.StartMapping<TMapper>()
                          .Map(expression, value);
        }

        public static ExpressionLoaderSettingsBuilder<TMapper> StartMapping<TMapper>(this ISettingsBuilder builder)
        {
            return new ExpressionLoaderSettingsBuilder<TMapper>(builder);
        }
    }
}