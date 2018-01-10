using Castle.DynamicProxy;
using FunWithCastles.Settings.Adapters;
using FunWithCastles.Settings.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FunWithCastles.Settings
{

    public class SettingsBuilder
    {
        private readonly Dictionary<Type, MemoryAdapter> _defaults;
        private readonly ProxyGenerator _generator;
        private readonly List<IInterceptor> _interceptors;

        public SettingsBuilder Load(ISettingsLoader loader)
        {
            var data = loader.Load();
            return AddReadOnly(new MemoryAdapter(data));
        }

        private SettingsBuilder()
        {
            _generator = new ProxyGenerator();
            _interceptors = new List<IInterceptor>();
            _defaults = new Dictionary<Type, MemoryAdapter>();
        }

        public static SettingsBuilder Create()
        {
            return new SettingsBuilder();
        }

        public SettingsBuilder Add(ISettingsAdapter adapter)
        {
            _interceptors.Add(new SettingsInterceptor(adapter));

            return this;
        }

        public SettingsBuilder Add(params ISettingsAdapter[] adapters)
        {
            var interceptors = adapters.Select(a => new SettingsInterceptor(a));
            _interceptors.AddRange(interceptors);
            return this;
        }

        public SettingsBuilder AddDefault<TSettings, TProperty>(
            Expression<Func<TSettings, TProperty>> expression,
            TProperty value)
        {
            var adapter = GetDefaultAdapter<TSettings>();
            var name = GetSettingName(expression);

            adapter[name] = value;

            return this;
        }

        public SettingsBuilder AddReadOnly(ISettingsAdapter adapter)
        {
            var readOnlyAdapter = new ReadOnlyAdapter(adapter);
            return Add(readOnlyAdapter);
        }

        public TSettings Build<TSettings>() where TSettings : class
        {
            var defaultInterceptor = GetDefaultInterceptor<TSettings>();
            var interceptors = _interceptors.Prepend(defaultInterceptor)
                                            .Where(i => i != null)
                                            .ToArray();

            var proxy = _generator.CreateInterfaceProxyWithoutTarget<TSettings>(interceptors);
            return proxy;
        }

        public IInterceptor GetDefaultInterceptor<TSettings>()
        {
            var key = typeof(TSettings);
            if (_defaults.ContainsKey(key))
            {
                var defaultAdapter = _defaults[key];
                var readOnlyAdapter = new ReadOnlyAdapter(defaultAdapter);
                var interceptor = new SettingsInterceptor(readOnlyAdapter);

                return interceptor;
            }

            return null;
        }

        private static string GetSettingName<TSettings, TProperty>(
                            Expression<Func<TSettings, TProperty>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            var name = member.Member.Name;
            return name;
        }

        private MemoryAdapter GetDefaultAdapter<TSettings>()
        {
            var key = typeof(TSettings);
            if (!_defaults.ContainsKey(key))
            {
                _defaults[key] = new MemoryAdapter();
            }

            var adapter = _defaults[key];
            return adapter;
        }
    }
}