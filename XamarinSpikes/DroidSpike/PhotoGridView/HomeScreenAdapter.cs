using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace PhotoGridView
{
    public class HomeScreenAdapter : BaseAdapter<TableItem>
    {
        private Activity context;
        private List<TableItem> items;

        public HomeScreenAdapter(Activity context, List<TableItem> items)
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null)
            {
                //view = new View(this.context);
                //view.Background = new ColorDrawable(Color.Transparent);
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            }
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

            view.FocusableInTouchMode = false;
            view.SetOnHoverListener(null);
            view.SetOnClickListener(null);
            view.SetOnKeyListener(null);
            view.SetOnTouchListener(null);

            view.Clickable = false;
            view.Focusable = false;


            return view;
        }

    }

    class Josh : View
    {
        public Josh(Context ctx)
            : base(ctx)
        {

        }
    }

    public class TableItem
    {
        public string Heading { get; set; }

        public string SubHeading { get; set; }

        public int ImageResourceId { get; set; }
    }
}