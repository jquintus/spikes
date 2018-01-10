using Castle.DynamicProxy;
using FunWithCastles.Settings.Adapters;
using System.Collections.Generic;
using System.Linq;

namespace FunWithCastles.Settings
{
    public class SettingsBuilder
    {
        private readonly ProxyGenerator _generator;
        private readonly List<IInterceptor> _interceptors;

        public SettingsBuilder()
        {
            _generator = new ProxyGenerator();
            _interceptors = new List<IInterceptor>();
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

        public SettingsBuilder AddReadOnly(ISettingsAdapter adapter)
        {
            var readOnlyAdapter = new ReadOnlyAdapter(adapter);
            return Add(readOnlyAdapter);
        }

        public TSettings Build<TSettings>() where TSettings : class
        {
            var proxy = _generator.CreateInterfaceProxyWithoutTarget<TSettings>(_interceptors.ToArray());
            return proxy;
        }
    }
}