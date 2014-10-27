using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace DialogBackButton
{
    [Activity(Label = "DialogBackButton", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IDialogInterfaceOnKeyListener
    {
        private Switch _downSwitch;
        private Switch _multipleSwitch;
        private Switch _upSwitch;

        public bool Down { get { return _downSwitch.Checked; } }

        public bool Multiple { get { return _multipleSwitch.Checked; } }

        public bool Up { get { return _upSwitch.Checked; } }

        public bool OnKey(IDialogInterface dialog, Keycode keyCode, KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
                switch (e.Action)
                {
                    case KeyEventActions.Down: return Down;
                    case KeyEventActions.Multiple: return Multiple;
                    case KeyEventActions.Up: return Up;
                }
            return false;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            _upSwitch = FindViewById<Switch>(Resource.Id.upToggleButton);
            _downSwitch = FindViewById<Switch>(Resource.Id.downToggleButton);
            _multipleSwitch = FindViewById<Switch>(Resource.Id.multipleToggleButton);

            button.Click += delegate
            {
                var dialog = new AlertDialog.Builder(this)
                                    .SetTitle("Delete entry")
                                    .SetMessage("Are you sure you want to delete this entry?")
                                     .Show();

                dialog.SetOnKeyListener(this);
            };
        }
    }
}