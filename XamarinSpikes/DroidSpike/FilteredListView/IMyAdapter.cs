namespace FilteredListView
{
    public interface IMyAdapter
    {
        string[] MatchItems { get; set; }

        void NotifyDataSetChanged();

        void NotifyDataSetInvalidated();
    }
}