using Castle.DynamicProxy;
using FunWithCastles.Settings.Adapters;
using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public class SettingsBuilder : ISettingsBuilder
    {
        private readonly ProxyGenerator _generator;
        private readonly List<IInterceptor> _interceptors;

        private SettingsBuilder()
        {
            _generator = new ProxyGenerator();
            _interceptors = new List<IInterceptor>();
        }

        public static ISettingsBuilder Create()
        {
            return new SettingsBuilder();
        }

        public ISettingsBuilder Add(ISettingsAdapter adapter)
        {
            _interceptors.Add(new SettingsInterceptor(adapter));
            return this;
        }

        public ISettingsBuilder AddReadOnly(ISettingsAdapter adapter)
        {
            var readOnlyAdapter = new ReadOnlyAdapter(adapter);
            return Add(readOnlyAdapter);
        }

        public TSettings Build<TSettings>() where TSettings : class
        {
            var interceptors = _interceptors.ToArray();

            var proxy = _generator.CreateInterfaceProxyWithoutTarget<TSettings>(interceptors);
            return proxy;
        }

        public ISettingsBuilder Load(ISettingsLoader loader)
        {
            var data = loader.Load();
            return AddReadOnly(new MemoryAdapter(data));
        }
    }
}