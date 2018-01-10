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

        public object this[string name]
        {
            get { return _adaptee[name]; }
            set
            {
                new InvalidOperationException($"Reading values is not supported by the {nameof(ReadOnlyAdapter)}");
            }
        }

        public bool CanRead(string name)
        {
            return _adaptee.CanRead(name);
        }

        public bool CanWrite(string name)
        {
            return false;
        }
    }
}