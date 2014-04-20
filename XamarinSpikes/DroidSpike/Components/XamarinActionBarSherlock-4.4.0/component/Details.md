Xamarin.Android Binding for ActionBarSherlock
=============================================

This package is a binding for ActionBarSherlock Android library by Jake Wharton.

ActionBarSherlock
=================

ActionBarSherlock is a standalone library designed to facilitate the use of
the action bar design pattern across all versions of Android through a single
API.

The library will automatically use the [native ActionBar][2] implementation on
Android 4.0 or later. For previous versions which do not include ActionBar, a
custom action bar implementation based on the sources of Ice Cream Sandwich
will automatically be wrapped around the layout. This allows you to easily
develop an application with an action bar for every version of Android from 2.x
and up.

About This Binding
==================

The source code for this binding is available at [monodroid-samples on GitHub][1].

Java packages are renamed in order them to conform to standard .NET naming conventions. For example, we rename "com.actionbar.sherlock" to "Xamarin.ActionBarSherlockBinding".

For a complete mapping see [Metadata.xml][5] in the source code.


Screenshots
===========

Note that this component is primarily about action bars, navigation, so the additional content visible in the screenshots below was added solely for the purpose of demonstration.

List navigation example:

![List Navigation][3]

Feature showcase (from "FeatureToggles" sample):

![Feature showcase (from "FeatureToggles" sample)][4]


[1]: https://github.com/xamarin/monodroid-samples/tree/master/ActionBarSherlock
[2]: http://developer.android.com/guide/topics/ui/actionbar.html
[3]: https://components.xamarin.com/resources/icons/component-228/sshot_ListNavigation.png
[4]: https://components.xamarin.com/resources/icons/component-228/sshot_FeatureToggles.png
[5]: https://github.com/xamarin/monodroid-samples/blob/master/ActionBarSherlock/ActionBarSherlock/Transforms/Metadata.xml

*Screenshots generated with [PlaceIt](http://placeit.breezi.com/).*