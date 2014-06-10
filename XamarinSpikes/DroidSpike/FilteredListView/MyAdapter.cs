using Android.App;
using Android.Views;
using Android.Widget;
using System.Linq;

namespace FilteredListView
{
    public class MyAdapter : BaseAdapter<string>, IFilterable
    {
        private Activity _context;
        private string[] _items;

        public MyAdapter(Activity context, string[] items)
            : base()
        {
            _context = context;
            _items = items;
            MatchItems = items;
            Filter = new MyFilter(items.ToList(), this);
        }

        public override int Count
        {
            get { return MatchItems.Length; }
        }
        public Filter Filter { get; private set; }
        public string[] MatchItems { get; set; }
        public override string this[int position]
        {
            get { return MatchItems[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                //view = new View(this.context);
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = MatchItems[position];
            return view;
        }
    }
}