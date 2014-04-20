using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace PhotoGridView
{
    [Activity(Label = "Home Screen", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity
    {
        private ListView _listView;
        private List<TableItem> tableItems;

        public HomeScreen()
        {
            tableItems = new List<TableItem>(){
                    new TableItem() { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.Vegetables },
                    new TableItem() { Heading = "Fruits", SubHeading = "17 items", ImageResourceId = Resource.Drawable.Fruits },
                    new TableItem() { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.FlowerBuds },
                    new TableItem() { Heading = "Legumes", SubHeading = "33 items", ImageResourceId = Resource.Drawable.Legumes },
                    new TableItem() { Heading = "Bulbs", SubHeading = "18 items", ImageResourceId = Resource.Drawable.Bulbs },
                    new TableItem() { Heading = "Tubers", SubHeading = "43 items", ImageResourceId = Resource.Drawable.Tubers },              
                    new TableItem() { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.Vegetables },
                    new TableItem() { Heading = "Fruits", SubHeading = "17 items", ImageResourceId = Resource.Drawable.Fruits },
                    new TableItem() { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.FlowerBuds },
                    new TableItem() { Heading = "Legumes", SubHeading = "33 items", ImageResourceId = Resource.Drawable.Legumes },
                    new TableItem() { Heading = "Bulbs", SubHeading = "18 items", ImageResourceId = Resource.Drawable.Bulbs },
                    new TableItem() { Heading = "Tubers", SubHeading = "43 items", ImageResourceId = Resource.Drawable.Tubers },
                    new TableItem() { Heading = "Vegetables", SubHeading = "65 items", ImageResourceId = Resource.Drawable.Vegetables },
                    new TableItem() { Heading = "Fruits", SubHeading = "17 items", ImageResourceId = Resource.Drawable.Fruits },
                    new TableItem() { Heading = "Flower Buds", SubHeading = "5 items", ImageResourceId = Resource.Drawable.FlowerBuds },
                    new TableItem() { Heading = "Legumes", SubHeading = "33 items", ImageResourceId = Resource.Drawable.Legumes },
                    new TableItem() { Heading = "Bulbs", SubHeading = "18 items", ImageResourceId = Resource.Drawable.Bulbs },
                    new TableItem() { Heading = "Tubers", SubHeading = "43 items", ImageResourceId = Resource.Drawable.Tubers },
            };
        }

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);

                SetContentView(Resource.Layout.HomeScreen);

                _listView = FindViewById<ListView>(Resource.Id.List);
                View header = LayoutInflater.Inflate(Resource.Layout.EmptyLayout, null);
                //header.Clickable = false;
                //header.Focusable = false;
                //header.SetOnClickListener(null);
                //header.SetOnLongClickListener(null);
                //header.SetOnTouchListener(null);

                _listView.AddHeaderView(header, null, false);

                WireButton(Resource.Id.button1);
                WireButton(Resource.Id.button2);
                WireButton(Resource.Id.button3);
                WireButton(Resource.Id.button4);

                _listView.OverscrollHeader = new ColorDrawable(Android.Graphics.Color.MediumPurple);
                _listView.OverscrollFooter= new ColorDrawable(Android.Graphics.Color.PapayaWhip);

                _listView.Adapter = new HomeScreenAdapter(this, tableItems);
                _listView.ItemClick += listView_ItemClick;
                _listView.Clickable = false;
                _listView.ItemsCanFocus = false;
                _listView.OnItemSelectedListener = null;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = tableItems[e.Position];
            Toast.MakeText(this, item.Heading, ToastLength.Short).Show();
        }

        private void WireButton(int id)
        {
            var button = FindViewById<Button>(id);
            var message = button.Text + " Pressed";
            button.Click += (s, e) => Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}