using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace DynamicThemes
{
    /// <summary>
    /// Source:  http://stackoverflow.com/questions/13116069/dynamic-themes-and-custom-styles
    /// Color pallets created by:  http://paletton.com/#uid=50S120k++k3ZJvC+Wpv+Zer+W78
    /// </summary>
    [Activity(Label = "DynamicThemes", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/Theme.Light")]
    public class MainActivity : Activity
    {
        public static bool IsDarkTheme { get; set; }

        public RadioButton DarkButton { get; set; }

        public RadioButton LightButton { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            if (IsDarkTheme)
            {
                SetTheme(Resource.Style.Theme_Dark);
            }
            else
            {
                SetTheme(Resource.Style.Theme_Light);
            }

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            LightButton = FindViewById<RadioButton>(Resource.Id.radio_light);
            DarkButton = FindViewById<RadioButton>(Resource.Id.radio_dark);

            LightButton.Click += radioButton_Click;
            DarkButton.Click += radioButton_Click;

            button.Click += delegate
            {
                Intent intent = new Intent(this, this.GetType());

                StartActivity(intent);
            };
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            if (sender == DarkButton)
            {
                IsDarkTheme = true;
            }
            else
            {
                IsDarkTheme = false;
            }
        }
    }
}