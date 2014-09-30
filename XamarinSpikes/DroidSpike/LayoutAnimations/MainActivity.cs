using Android.Animation;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;

namespace LayoutAnimations
{
    [Activity(Label = "LayoutAnimations", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ViewGroup _layout;
        private Tag _tag;
        private View _viewBottom;
        private View _viewTop;

        public TextView _tv { get; set; }

        [Export("myOnClick1")]
        public void myOnClick1(View v)
        {
            string msg;

            if (_viewTop.Visibility == ViewStates.Visible)
            {
                msg = "Goning progress";
                _viewTop.Visibility = ViewStates.Gone;
                _viewBottom.Visibility = ViewStates.Gone;
                _viewBottom.Visibility = ViewStates.Gone;
            }
            else
            {
                msg = "Showing progress";
                _viewTop.Visibility = ViewStates.Visible;
                _viewBottom.Visibility = ViewStates.Visible;
            }

            Toast toast = Toast.MakeText(this, msg, ToastLength.Long);
            toast.Show();
        }

        [Export("myOnClick2")]
        public void myOnClick2(View v)
        {
            string msg;

            var existingView = _layout.FindViewWithTag(_tag);
            if (existingView == null)
            {
                msg = "Adding text box";
                _layout.AddView(_tv, 2);
            }
            else
            {
                msg = "Removing Text Box";
                _layout.RemoveView(_tv);
            }

            Toast toast = Toast.MakeText(this, msg, ToastLength.Long);
            toast.Show();
        }

        [Export("myOnClick3")]
        public void myOnClick3(View v)
        {
            myOnClick1(v);
            myOnClick2(v);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _layout = FindViewById<ViewGroup>(Resource.Id.myview);

            _viewTop = FindViewById(Resource.Id.header);
            _viewBottom = FindViewById(Resource.Id.footer);

            var tx = new LayoutTransition();
            _layout.LayoutTransition = tx; // This is the magic.  So easy.

            _tag = new Tag("tag");
            _tv = new TextView(this)
            {
                Text = "Now I'm here",
                Tag = _tag,
            };
        }

        public class Tag : Java.Lang.Object
        {
            public Tag(string str)
            {
                TagValue = str;
            }

            public string TagValue { get; set; }
        }
    }
}