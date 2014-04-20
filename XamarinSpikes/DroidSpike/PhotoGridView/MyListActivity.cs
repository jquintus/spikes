using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace PhotoGridView
{
    //[Activity(Label = "BasicTable", MainLauncher = true, Icon = "@drawable/icon")]
    public class MyListActivity : ListActivity
    {
        string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            items = new string[] {
                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,                "Vegetables", 
                "Fruits", 
                "Flower Buds", 
                "Legumes", 
                "Bulbs", 
                "Tubers" ,
            };


            //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            ListAdapter = new ListActivityHomeScreenAdapter(this, items);
            ListView.FastScrollEnabled = true;

        }


        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var clickedItem = items[position];
            Toast.MakeText(this, clickedItem, ToastLength.Short).Show();
        }
    }


    public class ListActivityHomeScreenAdapter : BaseAdapter<string>
    {
        private string[] items;
        private Activity context;
        public ListActivityHomeScreenAdapter(Activity context, string[] items)
            : base()
        {
            this.context = context;
            this.items = items;
        }

        public override string this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Length; }
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
                view = new View(this.context);
                view.Background = new ColorDrawable(Color.Transparent);
                //view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position];
            return view;
        }
    }
}