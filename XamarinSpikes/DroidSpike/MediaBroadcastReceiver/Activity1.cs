using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Widget;
using Java.IO;
using System;

namespace MediaBroadcastReceiver
{
    [Activity(Label = "MediaBroadcastReceiver", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private Random rnd = new Random();

        public Android.Net.Uri CreateImage()
        {
            using (var b = Bitmap.CreateBitmap(100, 100, Bitmap.Config.Argb8888))
            using (Canvas c = new Canvas(b))
            {
                var color = Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
                c.DrawColor(color);

                return SaveBitmap(b);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                try
                {
                    CreateImage();
                }
                catch (Exception e)
                {
                    Log.Error(A.B, "Error creting image:  " + e.Message);
                }
            };
        }

        private Android.Net.Uri SaveBitmap(Bitmap b)
        {
            string filename = string.Format(@"/sdcard/test/MyFile_{0:HH_mm_s}.jpg", DateTime.Now);
            File f = new File(filename);
            using (System.IO.FileStream fs = new System.IO.FileStream(f.AbsolutePath, System.IO.FileMode.OpenOrCreate))
            {
                b.Compress(Bitmap.CompressFormat.Jpeg, 9, fs);

                var uri = Android.Net.Uri.FromFile(f);
                return uri;
            }
        }
    }
}