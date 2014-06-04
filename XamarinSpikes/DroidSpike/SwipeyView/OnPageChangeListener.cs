using Android.App;

namespace SwipeyView
{
    public class OnPageChangeListener : Java.Lang.Object, Android.Support.V4.View.ViewPager.IOnPageChangeListener
    {
        private ActionBar mActionBar;

        public OnPageChangeListener(ActionBar ab)
        {
            mActionBar = ab;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageSelected(int position)
        {
            mActionBar.SetSelectedNavigationItem(position);
        }
    }
}