using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MultiSelectImageGallery
{
    [Activity(Label = "MultiSelectImageGallery", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {

                var intent = new Intent(Intent.ActionGetContent);
                intent.SetType("image/*");
                intent.PutExtra(Intent.ExtraAllowMultiple, true);
                StartActivityForResult(intent, 100);
            };
        }




        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            Console.WriteLine(requestCode);
            Console.WriteLine(resultCode);


        }


    }



}

