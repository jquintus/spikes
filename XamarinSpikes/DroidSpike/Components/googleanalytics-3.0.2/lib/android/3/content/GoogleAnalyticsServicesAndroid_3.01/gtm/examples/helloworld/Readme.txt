To build this example:
  1. Run Eclipse.
  2. Open the the Import dialog ("File->Import..." menu).
  3. Select "Android/Existing Android Code Into Workspace" and click "Next>".
  4. Select the directory containing this file (by either typing it into the
     "Root Directory" field, or using "Browse..." to select it).
  5. Click "Refresh", and you should see "HelloWorld" listed as a
     "New Project Name".
  6. Click the checkbox on the "HelloWorld" line.
  7. Optionally, click the "Copy projects into workspace" checkbox.
  8. Click "Finish".
  9. At this point, you have a project.  You still need to add the TagManager
     library.
 10. Copy libGoogleAnalyticsServices.jar into the libs directory.

This sample uses a container ID for a non-existent container: "GTM-XXXX".
There's a corresponding "GTM-XXXX.json" in assets/tagmanager which is used
as the default container.  Although the app will run and use those values,
there's no way to dynamically update those values, since this is a
non-existent container.

To use real values, create a container in the Tag Manager UI, and note the
resulting container ID:
  1. Change the name of GTM-XXXX.json to GTM-1234.json (where
     GTM-1234 is the container ID for the new container).
  2. Change the value of the CONTAINER_ID constant in MainActivity.java to the
     new container ID.
