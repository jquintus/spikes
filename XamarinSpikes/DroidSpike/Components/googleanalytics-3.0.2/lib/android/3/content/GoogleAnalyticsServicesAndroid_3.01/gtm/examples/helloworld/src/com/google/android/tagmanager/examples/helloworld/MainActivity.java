package com.google.android.tagmanager.examples.helloworld;

import com.google.tagmanager.Container;
import com.google.tagmanager.ContainerOpener;
import com.google.tagmanager.ContainerOpener.OpenType;
import com.google.tagmanager.TagManager;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.TextView;

/**
 * An {@link Activity} that reads background and text color from a local
 * Json file and applies those colors to text view.
 */
public class MainActivity extends Activity {
  private static final String TAG = "GTMExample";
  private static final String CONTAINER_ID = "GTM-XXXX";
  private static final String BACKGROUND_COLOR_KEY = "background-color";
  private static final String TEXT_COLOR_KEY = "text-color";

  // Set to false for release build.
  private static final Boolean DEVELOPER_BUILD = true;
  private Container container;

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    if (DEVELOPER_BUILD) {
      StrictMode.enableDefaults();
    }
    TagManager tagManager = TagManager.getInstance(this);

    ContainerOpener.ContainerFuture containerFuture = ContainerOpener.openContainer(
        tagManager, CONTAINER_ID, OpenType.PREFER_NON_DEFAULT, null);
    super.onCreate(savedInstanceState);

    setContentView(R.layout.activity_main);

    // This call may block (for up to the timeout specified in
    // ContainerOpener.openContainer). For an example that shows how to use a splash
    // screen to avoid blocking, see cuteanimals example.
    container = containerFuture.get();

    // Modify the background-color and text-color of text based on the value
    // from configuration.
    updateColors();
  }

  private void updateColors() {
    Log.i(TAG, "updateColors");
    TextView textView = (TextView) findViewById(R.id.hello_world);
    textView.setBackgroundColor(getColor(BACKGROUND_COLOR_KEY));
    textView.setTextColor(getColor(TEXT_COLOR_KEY));
  }

  /**
   * Returns an integer representing a color.
   */
  private int getColor(String key) {
    return colorFromColorName(container.getString(key));
  }

  public void colorButtonClicked(View view) {
    Log.i(TAG, "colorButtonClicked");
    AlertDialog alertDialog = new AlertDialog.Builder(this).create();
    alertDialog.setTitle("Getting colors");
    alertDialog.setMessage(BACKGROUND_COLOR_KEY + " = "
        + container.getString(BACKGROUND_COLOR_KEY)
        + " " + TEXT_COLOR_KEY + " = "
        + container.getString(TEXT_COLOR_KEY));
    alertDialog.setButton(AlertDialog.BUTTON_POSITIVE,
        "OK", new DialogInterface.OnClickListener() {
        @Override
        public void onClick(DialogInterface dialog, int which) {
        }
    });
    alertDialog.show();
    updateColors();
  }

  public void refreshButtonClicked(View view) {
    Log.i(TAG, "refreshButtonClicked");
    container.refresh();
  }

  public int colorFromColorName(String colorName) {
    try {
      return Color.parseColor(colorName);
    } catch (Exception e) {
      return Color.BLACK;
    }
  }

  @Override
  public boolean onCreateOptionsMenu(Menu menu) {
    // Inflate the menu; this adds items to the action bar if it is present.
    getMenuInflater().inflate(R.menu.activity_main, menu);
    return true;
  }
}
