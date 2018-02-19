using System;

namespace FunWithCastles.Settings
{
    public class SettingsReaderWriter
    {
        private readonly ISettingsAdapter _adapter;
        private readonly ISettingConverter _converter;

        public SettingsReaderWriter(ISettingsAdapter adapter, ISettingConverter converter)
        {
            _adapter = adapter;
            _converter = converter;
        }

        public bool Read(Type returnType, string name, out object value)
        {
            object adapterValue;
            if (_adapter.TryRead(name, out adapterValue))
            {
                value = _converter.ConvertTo(returnType, adapterValue);
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public bool Write(Type type, string name, object value)
        {
            return _adapter.TryWrite(name, value);
        }
    }
}