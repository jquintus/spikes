To build this example:
  1. Run Eclipse.
  2. Open the the Import dialog ("File->Import..." menu).
  3. Select "Android/Existing Android Code Into Workspace" and click "Next>".
  4. Select the directory containing this file (by either typing it into the
     "Root Directory" field, or using "Browse..." to select it).
  5. Click "Refresh", and you should see "CuteAnimals" listed as a
     "New Project Name".
  6. Ensure the checkbox on the "CuteAnimals" line is checked.
  7. Optionally, click the "Copy projects into workspace" checkbox.
  8. Click "Finish".
  9. At this point, you have a project.  You still need to add the TagManager
     library.
 10. Copy libGoogleAnalyticsServices.jar into the libs directory.

This sample uses a container ID for a non-existent container: "GTM-XXXX".
There are two corresponding files: "GTM-XXXX" and "GTM-XXXX.json" which
are used as default containers.

GTM-XXXX.json contains default key-value pairs. It is limited to representing
the key-value pairs representable in value collection macros and is ignored if a
GTM-XXXX container is present.

GTM-XXXX is a full-featured default container. It contains the same default
key-value pairs as GTM-XXXX.json plus the configuration of how to trigger
Universal Analytics tags and a custom function call tag. Here is a summary of
the container (more details can be seen in the snapshot at images/Container.png)
   8 Macros:
      * "app name": the pre-populated application name macro.
      * "app version": the pre-populated app version macro.
      * "Cute Animals Android": a value collection macro containing key/value
        pairs as GTM-XXXX.json.
      * "event": an event macro.
      * "numRefreshes": a custom function call macro which records how many
        times the "Refresh" button is clicked.
      * "numRefreshesMod5": a custom function call macro whose value is equal
        to "numRefreshes" mod 5. See images/NumRefreshesMod5.png for more
        details.
      * "screen name": a data layer macro whose data layer variable name
        is "screenName".
      * "true": the pre-populated constant string macro whose value is equal to
        "true".
   5 Rules:
      * "CustomTagFires": the value of the event macro is equal to 'custom_tag'.
      * "CloseScreenEvent": the value of the event macro is equal to
        'closeScreen'.
      * "OpenScreenEvent": the value of the event macro is equal to
        'openScreen'.
      * "RefreshEvent": the value of the event macro is equal to 'refresh' and
        the value of the numRefreshesMod5 macro is equal to 1. See
        images/RefreshEvent.png for more details.
      * "Always": the pre-populated rule which is always evaluated to true.
   4 Tags:
      * "CustomTag": a custom function call tag with the firing rule:
        CustomTagFires is true. See images/CustomTag.png for more details.
      * "RefreshEvent": a Universal Analytics tag with the firing rule:
        RefreshEvent is true. See images/RefreshEventTag.png for more details.
      * "ScreenClosed": a Universal Analytics tag with the firing rule:
        CloseScreenEvent is true. See images/ScreenClosedTag.png for more
        details.
      * "ScreenOpen": a Universal Analytics tag with the firing rule:
        OpenScreenEvent is true. See images/ScreenOpenTag.png for more
        details.

Although the app will run and use those values specified in the GTM-XXXX (or
GTM-XXXX.json if you delete GTM-XXXX from your local machine), there's
no way to dynamically update those values, since this is a non-existent
container.

To use real values, create a container in the Tag Manager UI, and note the
resulting container ID:
  1. Download the container from the Tag Manager UI and rename it to
     GTM-1234 (where GTM-1234 is the container ID for the new container).
     Put GTM-1234 into the same directory with GTM-XXXX.json file.
  2. Change the value of the CONTAINER_ID constant in
     SplashScreenActivity.java to the new container ID.
  3. Optional: delete GTM-XXXX and GTM-XXXX.json files.
