namespace FunWithNinject.NamedScopes
{
    public interface IRoot
    {
        IEventAggregator ChildEventAggregator { get; }
        IHaveFunc ChildFuncHaver { get; }

        IEventAggregator EventAggregator { get; }
    }
}