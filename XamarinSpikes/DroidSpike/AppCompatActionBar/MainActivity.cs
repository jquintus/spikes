using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using AppCompatActionBar;

namespace GooglePlusSignIn
{
    [Activity(Label = "ActionBarCompat", Icon = "@drawable/ic_launcher", Theme = "@style/Theme.AppCompat.Light", MainLauncher = true/*, UiOptions = Android.Content.PM.UiOptions.SplitActionBarWhenNarrow*/)]
    //[MetaData ("android.support.UI_OPTIONS", Value = "splitActionBarWhenNarrow")]//If you wanted to slit it!
    public class MainActivity : ActionBarActivity
    {
        bool indeterminateVisible;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Needs to be called before setting the content view
            SupportRequestWindowFeature((int)WindowFeatures.IndeterminateProgress);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var button = FindViewById<Button>(Resource.Id.progress_button);
            button.Click += (sender, e) =>
            {
                // Switch the state of the ProgressBar and set it
                indeterminateVisible = !indeterminateVisible;
                SetSupportProgressBarIndeterminateVisibility(indeterminateVisible);

                // Update the button text
                button.Text = indeterminateVisible ? "Stop Progress" : "Start Progress";

                SupportInvalidateOptionsMenu();
            };

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            if (indeterminateVisible)
            {
                menu.RemoveItem(Resource.Id.action_edit);
                menu.RemoveItem(Resource.Id.action_save);
            }

            return base.OnPrepareOptionsMenu(menu);
        }

        Android.Support.V7.Widget.ShareActionProvider actionProvider;
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.main_menu, menu);

            var shareItem = menu.FindItem(Resource.Id.action_share);
            var test = MenuItemCompat.GetActionProvider(shareItem);
            actionProvider = test.JavaCast<Android.Support.V7.Widget.ShareActionProvider>();

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, "ActionBarCompat is Awesome! Support Lib v7 #Xamarin");

            actionProvider.SetShareIntent(intent);


            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_edit:
                    Toast.MakeText(this, "You pressed edit action!", ToastLength.Short).Show();
                    break;
                case Resource.Id.action_save:
                    Toast.MakeText(this, "You pressed save action!", ToastLength.Short).Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }


    }
}


