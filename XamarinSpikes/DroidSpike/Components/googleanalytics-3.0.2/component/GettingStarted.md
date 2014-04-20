# Get your Google Analytics Tracking Id

Follow the instructions in [this page](https://support.google.com/analytics/answer/2614741) to set up and get the tracking ID for a new app property in either a new or existing Google Analytics account.

# iOS Getting Started

There are two steps to getting started with the iOS SDK:

1. Initialize the tracker
2. Add screen measurement

After completing these steps, you'll be able to measure the following with Google Analytics:

* App installations
* Active users and demographics
* Screens and user engagement
* Crashes and exceptions

## Initializing the tracker

To initialize the tracker, use the `GoogleAnalytics.iOS` namespace in your AppDelegate and add this code to your AppDelegate's `FinishedLaunching` method:

```csharp
using GoogleAnalytics.iOS;
//...

// Shared GA tracker
public IGAITracker Tracker;

// Learn how to get your own Tracking Id from:
// https://support.google.com/analytics/answer/2614741?hl=en
public static readonly string TrackingId = "UA-TRACKING-ID";

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{

	// Optional: set Google Analytics dispatch interval to e.g. 20 seconds.
	GAI.SharedInstance.DispatchInterval = 20;
	
	// Optional: automatically send uncaught exceptions to Google Analytics.
	GAI.SharedInstance.TrackUncaughtExceptions = true;
	
	// Initialize tracker.
	Tracker = GAI.SharedInstance.GetTracker (TrackingId);
}
```

**Note**: When you obtain a tracker for a given tracking Id, the tracker instance is persisted in the library. When you call `GetTracker` with the same tracking Id later, the same tracker instance will be returned. Also, the Google Analytics SDK exposes a default tracker instance that gets set to the first tracker instance created. It can be accessed by:

```csharp
GAI.SharedInstance.DefaultTracker
```

Note that in the above example, "UA-TRACKING-ID" here is a placeholder for the tracking ID assigned to you when you created your Google Analytics property. If you are only using one property ID in your app, using the default tracker method is best.

## Implementing screen measurement

To implement it you must provide the view name to be used in your Google Analytics reports. A good place to put this is the view controller's initializer method, if you have one, or the `ViewDidAppear` method:

```csharp
using GoogleAnalytics.iOS;
//...

public override void ViewDidAppear (bool animated)
{
	base.ViewDidAppear (animated);
	
	// This screen name value will remain set on the tracker and sent with
	// hits until it is set to a new value or to null.
	GAI.SharedInstance.DefaultTracker.Set (GAIConstants.ScreenName, "Main View");

	GAI.SharedInstance.DefaultTracker.Send (GAIDictionaryBuilder.CreateAppView ().Build ());
}
```

**Note**: `GAIConstants` is a static class containing all the constants you can set in the `Set` method from the `GAIDictionaryBuilder` class.

To learn more about screen measurement, see the [Screens Developer Guide](https://developers.google.com/analytics/devguides/collection/ios/v3/screens).

Congratulations! Your Xamarin.iOS app is now setup to send data to Google Analytics.

## Next steps

You can do much more with Google Analytics, including measuring campaigns, in-app payments and transactions, and user interaction events. See the following developer guides to learn how to add these features to your implementation:

* [Advanced Configuration](https://developers.google.com/analytics/devguides/collection/ios/v3/advanced) – Learn more about advanced configuration options, including using multiple trackers.
* [Measuring Campaigns](https://developers.google.com/analytics/devguides/collection/ios/v3/campaigns) – Learn how to implement campaign measurement to understand which channels and campaigns are driving app installs.
* [Measuring Events](https://developers.google.com/analytics/devguides/collection/ios/v3/events) – Learn how to measure user engagement with interactive content like buttons, videos, and other media using Events.
* [Measuring In-App Payments](https://developers.google.com/analytics/devguides/collection/ios/v3/ecommerce) – Learn how to measure in-app payments and transactions.
* [User timings](https://developers.google.com/analytics/devguides/collection/ios/v3/usertimings) – Learn how to measure user timings in your app to measure load times, engagement with media, and more.

# Android Getting Started

There are three steps to getting started with the Android SDK:

1. Update AndroidManifest.xml
2. Add EasyTracker methods
3. Create your analytics.xml file

After completing these steps, you'll be able to measure the following with Google Analytics:

* App installations
* Active users and demographics
* Screens and user engagement
* Crashes and exceptions

## Updating AndroidManifest.xml

Update your `AndroidManifest.xml` file by adding the following permissions:

```xml
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
```

## Adding EasyTracker methods

Add the send methods to the `onStart()` and `onStop()` methods of each of your Activities as in the following example:

```csharp
using Google.Analytics.Tracking;
//...

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
```

## Creating your analytics.xml file

When you use EasyTracker, global configuration settings are managed using resources defined in XML. Create a file called `analytics.xml` in your project's `Resources/values` directory and add the following resources:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<resources xmlns:tools="http://schemas.android.com/tools" tools:ignore="TypographyDashes">
	<!--Replace placeholder ID with your tracking ID-->
	<string name="ga_trackingId">UA-XXXX-Y</string>

	<!--Enable automatic activity tracking-->
	<bool name="ga_autoActivityTracking">true</bool>

	<!--Enable automatic exception tracking-->
	<bool name="ga_reportUncaughtExceptions">true</bool>
</resources>
```

**Important**: Do not encode dashes in the `ga_trackingId` string. Doing so will prevent you from seeing any data in your reports.

See the [analytics.xml parameters reference](https://developers.google.com/analytics/devguides/collection/android/parameters) for the complete list of parameters you can use to configure your implementation.

Congratulations! Your Xamarin.Android app is now setup to send data to Google Analytics.

## Next steps

You can do much more with Google Analytics, including measuring campaigns, in-app payments and transactions, and user interaction events. See the following Android developer guides to learn how to add these features to your implementation:

* [Advanced Configuration](https://developers.google.com/analytics/devguides/collection/android/v3/advanced) – Learn more about advanced configuration options, including using multiple trackers.
* [Measuring Campaigns](https://developers.google.com/analytics/devguides/collection/android/v3/campaigns) – Learn how to implement campaign measurement to understand which channels and campaigns are driving app installs.
* [Measuring Events](https://developers.google.com/analytics/devguides/collection/android/v3/events) – Learn how to measure user engagement with interactive content like buttons, videos, and other media using Events.
* [Measuring In-App Payments](https://developers.google.com/analytics/devguides/collection/android/v3/ecommerce) – Learn how to measure in-app payments and transactions.
* [User timings](https://developers.google.com/analytics/devguides/collection/android/v3/usertimings) – Learn how to measure user timings in your app to measure load times, engagement with media, and more.
* [Analytics.xml parameters](https://developers.google.com/analytics/devguides/collection/android/parameters.html) – See the complete list of `analytics.xml` configuration parameters.

# More Resources

* [Google Analytics Developer Portal](https://developers.google.com/analytics/devguides/collection/)


###### The [original content material](https://developers.google.com/analytics/devguides/collection/) of this page is licensed under the [Creative Commons Attribution 3.0 License](http://creativecommons.org/licenses/by/3.0/) and has been adapted to match this page format.