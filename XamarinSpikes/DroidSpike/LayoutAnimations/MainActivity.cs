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
        private int count = 1;

        public TextView _tv { get; set; }

        [Export("myOnClick")]
        public void myOnClick(View v)
        {
            DoStuff();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _ll = FindViewById<LinearLayout>(Resource.Id.myview);


            var tx = new LayoutTransition();
            _ll.LayoutTransition = tx; // This is the magic.  So easy.


            _tag = new Tag("tag");
            _tv = new TextView(this)
            {
                Text = "Now I'm here",
                Tag = _tag,
            };
        }

        private void DoStuff()
        {
            Toast toast = Toast.MakeText(this, string.Format("You clicked {0} times", ++count), ToastLength.Long);
            toast.Show();

            var existingView = _ll.FindViewWithTag(_tag);
            if (existingView == null)
            {
                _ll.AddView(_tv, 2);
            }
            else
            {
                _ll.RemoveView(_tv);
            }
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