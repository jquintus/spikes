using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using R = Android.Resource;

namespace SwipeyView
{
    //[Activity(Label = "Flipper", MainLauncher = true, Icon = "@drawable/icon")]
    public class Flipper : Activity, Android.Views.View.IOnClickListener
    {
        public ViewFlipper flippy { get; set; }

        public void OnClick(View v)
        {
            flippy.ShowNext();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.simple_flipper);

            flippy = FindViewById<ViewFlipper>(Resource.Id.flippy);
            var buttony = FindViewById<Button>(Resource.Id.buttony);

            buttony.SetOnClickListener(this);

            flippy.SetInAnimation(this, R.Animation.SlideInLeft);
            flippy.SetOutAnimation(this, R.Animation.SlideOutRight);
        }
    }
}