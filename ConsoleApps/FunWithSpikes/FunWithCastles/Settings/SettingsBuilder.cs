using Castle.DynamicProxy;
using FunWithCastles.Settings.Adapters;
using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public class SettingsBuilder : ISettingsBuilder
    {
        private readonly ProxyGenerator _generator;
        private readonly List<SettingsReaderWriter> _readerWriters;

        private SettingsBuilder()
        {
            _generator = new ProxyGenerator();
            _readerWriters = new List<SettingsReaderWriter>();
        }

        public static ISettingsBuilder Create()
        {
            return new SettingsBuilder();
        }

        public ISettingsBuilder Add(ISettingsAdapter adapter, ISettingConverter converter)
        {
            converter = converter ?? new DefaultSettingConverter();
            var readerWriter = new SettingsReaderWriter(adapter, converter);
            _readerWriters.Add(readerWriter);
            return this;
        }

        public ISettingsBuilder AddReadOnly(ISettingsAdapter adapter, ISettingConverter converter)
        {
            var readOnlyAdapter = new ReadOnlyAdapter(adapter);
            return Add(readOnlyAdapter, converter);
        }

        public TSettings Create<TSettings>(string root = null) where TSettings : class
        {
            var interceptor = new SettingsInterceptor(_readerWriters);
            var proxy = _generator.CreateInterfaceProxyWithoutTarget<TSettings>(interceptor);
            return proxy;
        }

        public ISettingsBuilder Load(ISettingsLoader loader, ISettingConverter converter)
        {
            var data = loader.Load();
            return AddReadOnly(new MemoryAdapter(data), converter);
        }
    }
}