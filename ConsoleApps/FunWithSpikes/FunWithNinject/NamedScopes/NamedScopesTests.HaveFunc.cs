using System;

namespace FunWithNinject.NamedScopes
{
    public class HaveFunc : IHaveFunc
    {
        private IEventAggregator _events;
        private Func<IEventAggregator> _maker;

        public HaveFunc(Func<IEventAggregator> maker)
        {
            _maker = maker;
            _events = null;
        }

        public IEventAggregator ChildEventAggregator
        {
            get
            {
                return _events ?? (_events = _maker());
            }
        }
    }
}