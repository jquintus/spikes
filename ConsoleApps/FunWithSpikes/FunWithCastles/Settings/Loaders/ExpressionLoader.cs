using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FunWithCastles.Settings.Loaders
{
    public class ExpressionLoader<TMapper> : ISettingsLoader
    {
        private readonly Dictionary<string, object> _mappings;

        public ExpressionLoader()
        {
            _mappings = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Load()
        {
            return _mappings;
        }

        public void Map<TProp>(
            Expression<Func<TMapper, TProp>> expression,
            TProp value)
        {
            var name = GetSettingName(expression);
            _mappings[name] = value;
        }

        private static string GetSettingName<TProp>(Expression<Func<TMapper, TProp>> expression)
        {
            var member = expression.Body as MemberExpression;
            var name = member.Member.Name;
            return name;
        }
    }
}