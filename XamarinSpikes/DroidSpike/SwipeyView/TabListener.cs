using Android.App;
using Android.Support.V4.View;

namespace SwipeyView
{
    public class TabListener : Java.Lang.Object, ActionBar.ITabListener
    {
        private ViewPager mViewPager;

        public TabListener(ViewPager vp)
        {
            mViewPager = vp;
        }

        public void OnTabReselected(ActionBar.Tab tab, Android.App.FragmentTransaction ft)
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, Android.App.FragmentTransaction ft)
        {
            mViewPager.SetCurrentItem(tab.Position, true);
        }

        public void OnTabUnselected(ActionBar.Tab tab, Android.App.FragmentTransaction ft)
        {
        }
    }
}