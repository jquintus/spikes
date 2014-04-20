package com.google.android.tagmanager.examples.cuteanimals;

import com.google.tagmanager.DataLayer;
import com.google.tagmanager.TagManager;

import android.content.Context;

/**
 * Utility class.
 */
public class Utils {
  private Utils() {
    // private constructor.
  }

  /**
   * Push an "openScreen" event with the given screen name. Tags that match that event will fire.
   */
  public static void pushOpenScreenEvent(Context context, String screenName) {
    DataLayer dataLayer = TagManager.getInstance(context).getDataLayer();
    dataLayer.push(DataLayer.mapOf("screenName", screenName, "event", "openScreen"));
  }

  /**
   * Push a "closeScreen" event with the given screen name. Tags that match that event will fire.
   */
  public static void pushCloseScreenEvent(Context context, String screenName) {
    DataLayer dataLayer = TagManager.getInstance(context).getDataLayer();
    dataLayer.push(DataLayer.mapOf("screenName", screenName, "event", "closeScreen"));
  }
}
