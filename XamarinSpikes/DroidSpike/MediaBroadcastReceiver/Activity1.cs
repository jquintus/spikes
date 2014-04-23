using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Widget;
using Java.IO;
using System;
using System.Collections.Generic;

namespace MediaBroadcastReceiver
{
    [Activity(Label = "MediaBroadcastReceiver", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private const string DIRECTORY_PATH = @"/sdcard/test/";
        private List<PhotosObserver> _observers;
        private Random rnd = new Random();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button imageButton = FindViewById<Button>(Resource.Id.MyButton);
            Button scanButton = FindViewById<Button>(Resource.Id.scanButton);
            Button newlineButton = FindViewById<Button>(Resource.Id.newlineButton);

            imageButton.Click += delegate
            {
                try
                {
                    var f = CreateImage();
                    MediaScannerConnection.ScanFile(this, new String[] { f.AbsolutePath }, null, null);

                    Log.Info(A.B, "Created image:  " + f.Path);
                }
                catch (Exception e)
                {
                    Log.Error(A.B, "Error creting image:  " + e.Message);
                }
            };

            scanButton.Click += delegate
            {
                try
                {
                    ScanForMedia();
                }
                catch (Exception e)
                {
                    Log.Error(A.B, "Error scanning for images:  " + e.Message);
                }
            };

            newlineButton.Click += delegate { Log.Debug(A.B, "_"); };

            RegisterObserver();
        }

        private File CreateImage()
        {
            using (var b = Bitmap.CreateBitmap(100, 100, Bitmap.Config.Argb8888))
            using (Canvas c = new Canvas(b))
            {
                var color = Color.Argb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
                c.DrawColor(color);

                return SaveBitmap(b);
            }
        }

        private void RegisterObserver()
        {
            _observers = new List<PhotosObserver>(){
                PhotosObserver.CreateExternalObserver(this).Register(),
                PhotosObserver.CreateInternalObserver(this).Register(),
            };
        }

        private File SaveBitmap(Bitmap b)
        {
            string filename = string.Format("{0}MyFile{1:HH_mm_s}.jpg", DIRECTORY_PATH, DateTime.Now);
            File f = new File(filename);
            using (System.IO.FileStream fs = new System.IO.FileStream(f.AbsolutePath, System.IO.FileMode.OpenOrCreate))
            {
                b.Compress(Bitmap.CompressFormat.Jpeg, 9, fs);

                return f;
            }
        }

        private void ScanForMedia()
        {
            File f = new File(DIRECTORY_PATH);
            var contentUri = Android.Net.Uri.FromFile(f);

            var mediaScanIntent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(contentUri);
            this.SendBroadcast(mediaScanIntent);
        }
    }
}