using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;

namespace FacebookEffect
{
    [Activity(Label = "FacebookEffect", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private View _slider;
        private Animation inAnim;
        private Animation outAnim;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            _slider = FindViewById<View>(Resource.Id.slider_view);
            var showButton = FindViewById<Button>(Resource.Id.selectPhotosButton);
            var cancelButton = FindViewById<Button>(Resource.Id.cancelButton);

            showButton.Click += showButton_Click;
            cancelButton.Click += cancelButton_Click;


            inAnim = AnimationUtils.LoadAnimation(this, Resource.Animation.SlideInUp);
            outAnim = AnimationUtils.LoadAnimation(this, Resource.Animation.SlideOutDown);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _slider.StartAnimation(inAnim);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            _slider.StartAnimation(outAnim);
        }
    }
}