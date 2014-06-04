using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace SwipeyView
{
    [Activity(Label = "SwipeyView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private DemoCollectionPagerAdapter mDemoCollectionPagerAdapter;
        private ViewPager mViewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            var actionBar = ActionBar;

            mDemoCollectionPagerAdapter = new DemoCollectionPagerAdapter(SupportFragmentManager);
            mViewPager = FindViewById<ViewPager>(Resource.Id.pager);
            mViewPager.Adapter = mDemoCollectionPagerAdapter;

            mViewPager.SetOnPageChangeListener(new OnPageChangeListener(actionBar));

            actionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            ActionBar.ITabListener tabListener = new TabListener(mViewPager);

            for (int i = 0; i < mDemoCollectionPagerAdapter.Count; i++)
            {
                actionBar.AddTab(
                        actionBar.NewTab()
                                .SetText("Tab " + (i + 1))
                                .SetTabListener(tabListener));
            }
        }
    }

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