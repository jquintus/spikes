using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace HeaderedGridView.Droid.Views
{
    [Activity(Label = "Headered Grid View")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            {
                SetContentView(Resource.Layout.FirstView);
            }
        }
    }
}