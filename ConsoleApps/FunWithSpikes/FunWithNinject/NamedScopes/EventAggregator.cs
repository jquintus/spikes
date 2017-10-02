namespace FunWithNinject.NamedScopes
{
    public class EventAggregator : IEventAggregator
    {
        private static int _count;
        private readonly int _id = _count++;

        public override string ToString()
        {
            return string.Format("EventAggregator #{0}", _id);
        }
    }
}