using Android.App;
using Android.Content;
using Android.OS;

namespace Launcher
{
    [Activity(Label = "Yarly Launcher", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Intent launchIntent = PackageManager.GetLaunchIntentForPackage("co.yarly.droid");
            StartActivity(launchIntent);

            Finish();
        }
    }
}