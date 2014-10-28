using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using MccmCrossSpikes.XF.Core;
using Xamarin.Forms.Platform.Android;

namespace MvvmCrossSpikes.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);


            StartActivity(typeof(XfView));

        }

    }

    [Activity(Label = "View for FirstViewModel")]

    public class XfView : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());
        }
    }
}