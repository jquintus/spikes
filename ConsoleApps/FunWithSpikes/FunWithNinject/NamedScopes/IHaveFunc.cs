namespace FunWithNinject.NamedScopes
{
    public interface IHaveFunc
    {
        IEventAggregator ChildEventAggregator { get; }
    }
}