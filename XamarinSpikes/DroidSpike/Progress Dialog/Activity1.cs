using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace Progress_Dialog
{
    [Activity(Label = "Progress_Dialog", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button start = FindViewById<Button>(Resource.Id.startButton);
            Button stop = FindViewById<Button>(Resource.Id.stopButton);

            ProgressDialog pd = new ProgressDialog(this)
            {
                Indeterminate = true,
            };

            pd.SetMessage("Waiting");

            pd.SetButton("cancel", (s, e) => Stop(pd));
            pd.SetIcon(Resource.Drawable.Icon);

            //pd.SetCancelable(false);

            Drawable myIcon = Resources.GetDrawable(Resource.Animation.progress_dialog_icon_drawable_animation);
            pd.SetIndeterminateDrawable(myIcon);

            start.Click += delegate { Start(pd); };
            stop.Click += delegate { Stop(pd); };
        }

        private void Start(ProgressDialog pd)
        {
            try
            {

                pd.Show();
            }
            catch (System.Exception ex)
            {
                Log.Debug("TEST", ex.Message);
            }
        }

        private void Stop(ProgressDialog pd)
        {
            pd.Dismiss();
        }
    }
}