using System;
using System.Linq.Expressions;

namespace FunWithCastles.Settings.Loaders
{
    public class ExpressionLoaderSettingsBuilder<TMapper> : ISettingsBuilder
    {
        public readonly ExpressionLoader<TMapper> _expressionLoader;
        private readonly ISettingsBuilder _builder;

        public ExpressionLoaderSettingsBuilder(ISettingsBuilder builder)
        {
            _builder = builder;
            _expressionLoader = new ExpressionLoader<TMapper>();
        }

        public ISettingsBuilder Add(ISettingsAdapter adapter)
        {
            _builder.Load(_expressionLoader);
            return _builder.Add(adapter);
        }

        public ISettingsBuilder AddReadOnly(ISettingsAdapter adapter)
        {
            _builder.Load(_expressionLoader);
            return _builder.AddReadOnly(adapter);
        }

        public TSettings Build<TSettings>() where TSettings : class
        {
            _builder.Load(_expressionLoader);
            return _builder.Build<TSettings>();
        }

        public ISettingsBuilder Load(ISettingsLoader loader)
        {
            _builder.Load(_expressionLoader);
            return _builder.Load(loader);
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