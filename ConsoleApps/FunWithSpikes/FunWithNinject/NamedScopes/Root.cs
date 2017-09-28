namespace FunWithNinject.NamedScopes
{
    public class Root : IRoot
    {
        public Root(IEventAggregator events, IHaveFunc funcHaver)
        {
            EventAggregator = events;
            ChildFuncHaver = funcHaver;
        }

        public IEventAggregator ChildEventAggregator { get { return ChildFuncHaver.ChildEventAggregator; } }

        public IHaveFunc ChildFuncHaver { get; set; }

        public IEventAggregator EventAggregator { get; private set; }
    }
}