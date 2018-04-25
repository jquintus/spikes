using System;

namespace FunWithCastles.Settings.Adapters
{
    internal class ReadOnlyAdapter : ISettingsAdapter
    {
        private ISettingsAdapter _adaptee;

        public ReadOnlyAdapter(ISettingsAdapter adaptee)
        {
            if (null == adaptee)
            {
                throw new ArgumentNullException(nameof(adaptee));
            }
            _adaptee = adaptee;
        }

        public bool TryRead(string name, out object value)
        {
            return _adaptee.TryRead(name, out value);
        }

        public bool TryWrite(string name, object value)
        {
            return false;
        }
    }
}