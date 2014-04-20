using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Google.Analytics.Tracking;

namespace AnalyticsDroidSample
{
	[Activity (Label = "Second Activity")]			
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.Second);

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnSecondEvent = FindViewById<Button> (Resource.Id.btnSecondEvent);


			btnSecondEvent.Click += delegate {

				// May return null if a EasyTracker has not yet been initialized with a
				// property ID.
				var easyTracker = EasyTracker.GetInstance (this);

				// MapBuilder.createEvent().build() returns a Map of event fields and values
				// that are set and sent with the hit.
				var gaEvent = MapBuilder.CreateEvent ("UI", "button_press", "create_and_send_2nd_button", null).Build ();
				easyTracker.Send (gaEvent);

				Console.WriteLine ("Event Sent, please see GA Events Console");
			};

		}

		protected override void OnStart ()
		{
			base.OnStart ();

			// Manual View Tracking

			// May return null if EasyTracker has not yet been initialized with a property Id.
			var easyTracker = EasyTracker.GetInstance(this);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			easyTracker.Set (Fields.ScreenName, "2nd Activity");
			var gaSecondEvent = MapBuilder.CreateAppView ().Build ();
			easyTracker.Send (gaSecondEvent);
		}

		protected override void OnStop ()
		{
			base.OnStop ();

			// Manual View Tracking

			// May return null if EasyTracker has not yet been initialized with a property Id.
			var easyTracker = EasyTracker.GetInstance(this);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			easyTracker.Set (Fields.ScreenName, null);
		}
	}
}

