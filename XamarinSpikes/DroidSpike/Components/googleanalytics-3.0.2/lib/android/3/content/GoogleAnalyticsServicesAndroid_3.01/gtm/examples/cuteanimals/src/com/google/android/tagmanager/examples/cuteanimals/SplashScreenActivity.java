package com.google.android.tagmanager.examples.cuteanimals;

import com.google.tagmanager.Container;
import com.google.tagmanager.Container.FunctionCallMacroHandler;
import com.google.tagmanager.Container.FunctionCallTagHandler;
import com.google.tagmanager.ContainerOpener;
import com.google.tagmanager.ContainerOpener.OpenType;
import com.google.tagmanager.Logger.LogLevel;
import com.google.tagmanager.TagManager;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import java.util.Map;

/**
 * Displays simple splash screen while GTM container is loading. Once the container is loaded,
 * launches the {@link MainActivity}.
 */
public class SplashScreenActivity extends Activity {
  private static final long TIMEOUT_FOR_CONTAINER_OPEN_MILLISECONDS = 2000;
  private static final String CONTAINER_ID = "GTM-XXXX";

  @Override
  public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_splashscreen);

    TagManager tagManager = TagManager.getInstance(this);

    // Modify the log level of the logger to print out not only
    // warning and error messages, but also verbose, debug, info messages.
    tagManager.getLogger().setLogLevel(LogLevel.VERBOSE);

    // The containerAvailable method will be called as soon as one of the following happens:
    //   1. a saved container is loaded
    //   2. if there is no saved container, a network container is loaded
    //   3. the 2-second timeout occurs

    ContainerOpener.openContainer(
        tagManager, CONTAINER_ID, OpenType.PREFER_NON_DEFAULT,
        TIMEOUT_FOR_CONTAINER_OPEN_MILLISECONDS, new ContainerOpener.Notifier() {

          @Override
          public void containerAvailable(Container container) {
            // Register two custom function call macros to the container.
            container.registerFunctionCallMacroHandler("increment", new CustomMacroHandler());
            container.registerFunctionCallMacroHandler("mod", new CustomMacroHandler());
            // Register a custom function call tag to the container.
            container.registerFunctionCallTagHandler("custom_tag", new CustomTagHandler());
            // Save container for use by any other activities in the app.
            ContainerHolder.setContainer(container);
            startMainActivity();
          }
        });
   }

  private void startMainActivity() {
    Intent intent = new Intent(SplashScreenActivity.this, MainActivity.class);
    startActivity(intent);
  }

  class CustomMacroHandler implements FunctionCallMacroHandler {
    private int numCalls;

    @Override
    public Object getValue(String name, Map<String, Object> parameters) {
      if ("increment".equals(name)) {
        return ++numCalls;
      } else if ("mod".equals(name)) {
        return (Long) parameters.get("key1") % Integer.valueOf((String) parameters.get("key2"));
      } else {
        throw new IllegalArgumentException("Custom macro name: " + name + " is not supported.");
      }
    }
  }

  class CustomTagHandler implements FunctionCallTagHandler {
    @Override
    public void execute(String tagName, Map<String, Object> parameters) {
      // The code for firing this custom tag.
      Log.i("CuteAnimals", "Custom function call tag :" + tagName + " is fired.");
    }
  }
}
