package com.google.android.tagmanager.examples.cuteanimals;

import com.google.tagmanager.Container;

/**
 * Singleton to hold the GTM Container (since it should be only created once
 * per run of the app).
 */
public class ContainerHolder {
  private static Container container;
  
  /**
   * Utility class; don't instantiate.
   */
  private ContainerHolder() {
  }
  
  public static Container getContainer() {
    return container;
  }
  
  public static void setContainer(Container c) {
    container = c;
  }
}
