using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Google.Analytics.Tracking;

namespace AnalyticsDroidSample
{
	[Activity (Label = "Analytics Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			Button btnSecondActivity = FindViewById<Button> (Resource.Id.btnSecondActivity);
			
			button.Click += delegate {

				// May return null if a EasyTracker has not yet been initialized with a
				// property ID.
				var easyTracker = EasyTracker.GetInstance (this);

				// MapBuilder.createEvent().build() returns a Map of event fields and values
				// that are set and sent with the hit.
				var gaEvent = MapBuilder.CreateEvent ("UI", "button_press", "create_and_send_button", null).Build ();
				easyTracker.Send (gaEvent);

				Console.WriteLine ("Event Sent, please see GA Events Console");
			};

			btnSecondActivity.Click += delegate {
				// Show the sencond activity
				StartActivity (typeof (SecondActivity));
			};
		}

		protected override void OnStart ()
		{
			base.OnStart ();

			// Setup Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStart (this);

			// By default, data is dispatched from the Google Analytics SDK for Android every 30 minutes.
			// You can override this by setting the dispatch period in seconds.
			GAServiceManager.Instance.SetLocalDispatchPeriod (5);
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			// Stop Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStop (this);
		}
	}
}


