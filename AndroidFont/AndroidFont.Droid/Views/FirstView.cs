using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace AndroidFont.Droid.Views
{
    [Activity(Label = "Fonts")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}