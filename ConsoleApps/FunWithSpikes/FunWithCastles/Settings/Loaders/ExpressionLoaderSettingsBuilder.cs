using System;
using System.Linq.Expressions;

namespace FunWithCastles.Settings.Loaders
{
    public class ExpressionLoaderSettingsBuilder<TMapper> : ISettingsBuilder
    {
        public readonly ExpressionLoader<TMapper> _expressionLoader;
        private readonly ISettingsBuilder _builder;
        private readonly ISettingConverter _converter;

        public ExpressionLoaderSettingsBuilder(ISettingsBuilder builder, ISettingConverter converter)
        {
            _builder = builder;
            _expressionLoader = new ExpressionLoader<TMapper>();
            _converter = converter;
        }

        public ISettingsBuilder Add(ISettingsAdapter adapter, ISettingConverter converter)
        {
            _builder.Load(_expressionLoader, _converter);
            return _builder.Add(adapter, converter);
        }

        public ISettingsBuilder AddReadOnly(ISettingsAdapter adapter, ISettingConverter converter)
        {
            _builder.Load(_expressionLoader, _converter);
            return _builder.AddReadOnly(adapter, converter);
        }

        public TSettings CreateSettings<TSettings>(string root = null) where TSettings : class
        {
            _builder.Load(_expressionLoader, _converter);
            return _builder.CreateSettings<TSettings>();
        }

        public ISettingsBuilder Load(ISettingsLoader loader, ISettingConverter converter)
        {
            _builder.Load(_expressionLoader, _converter);
            return _builder.Load(loader, converter);
        }

        public ExpressionLoaderSettingsBuilder<TMapper> Map<TProp>(
            Expression<Func<TMapper, TProp>> expression,
            TProp value)
        {
            _expressionLoader.Map(expression, value);
            return this;
        }
    }
}