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
        private LinearLayout _ll;
        private Tag _tag;
        private View _view;

        public TextView _tv { get; set; }

        [Export("myOnClick1")]
        public void myOnClick1(View v)
        {
            string msg;

            if (_view.Visibility == ViewStates.Visible)
            {
                msg = "Goning progress";
                _view.Visibility = ViewStates.Gone;
            }
            //else if (_view.Visibility == ViewStates.Gone)
            //{
            //    msg = "Hiding progress";
            //    _view.Visibility = ViewStates.Invisible;
            //}
            else
            {
                msg = "Showing progress";
                _view.Visibility = ViewStates.Visible;
            }

            Toast toast = Toast.MakeText(this, msg, ToastLength.Long);
            toast.Show();
        }

        [Export("myOnClick2")]
        public void myOnClick2(View v)
        {
            string msg;

            var existingView = _ll.FindViewWithTag(_tag);
            if (existingView == null)
            {
                msg = "Adding text box";
                _ll.AddView(_tv, 2);
            }
            else
            {
                msg = "Removing Text Box";
                _ll.RemoveView(_tv);
            }

            Toast toast = Toast.MakeText(this, msg, ToastLength.Long);
            toast.Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _ll = FindViewById<LinearLayout>(Resource.Id.myview);

            _view = FindViewById(Resource.Id.progressBar1);

            var tx = new LayoutTransition();
            _ll.LayoutTransition = tx; // This is the magic.  So easy.

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