using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using System.Collections.Generic;

namespace SwipeyView
{
    /// <summary>
    /// http://developer.android.com/training/implementing-navigation/lateral.html#horizontal-paging
    /// http://android-developers.blogspot.com/2011/08/horizontal-view-swiping-with-viewpager.html
    /// </summary>
    [Activity(Label = "SwipeyView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private DemoCollectionPagerAdapter mDemoCollectionPagerAdapter;
        private ViewPager mViewPager;

        public override void OnBackPressed()
        {
            if (mViewPager.CurrentItem == 0)
            {
                base.OnBackPressed();
            }
            else
            {
                mViewPager.SetCurrentItem(mViewPager.CurrentItem - 1, true);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            mDemoCollectionPagerAdapter = new DemoCollectionPagerAdapter(SupportFragmentManager, new Dictionary<int, int>{
                { 0, Resource.Layout.layout1},
                {  1, Resource.Layout.layout2},
                {  2, Resource.Layout.layout3},
                {  3, Resource.Layout.layout4},
            });
            mViewPager = FindViewById<ViewPager>(Resource.Id.pager);
            mViewPager.Adapter = mDemoCollectionPagerAdapter;
            mViewPager.OffscreenPageLimit = mDemoCollectionPagerAdapter.Count; // Keep them all in memory.  These are small views, who cares.

            //If we want to use tab, uncomment this
            var actionBar = ActionBar;
            mViewPager.SetOnPageChangeListener(new OnPageChangeListener(actionBar));

            actionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            ActionBar.ITabListener tabListener = new TabListener(mViewPager);

            var tabStrip = FindViewById<PagerTabStrip>(Resource.Id.tabStrip);
            bool drawFullUnderline = tabStrip.DrawFullUnderline;
            tabStrip.DrawFullUnderline = !drawFullUnderline;
            tabStrip.TabIndicatorColor = Android.Graphics.Color.Red;

            for (int i = 0; i < mDemoCollectionPagerAdapter.Count; i++)
            {
                actionBar.AddTab(
                        actionBar.NewTab()
                    //.SetText("Tab " + (i + 1))
                                .SetText(mDemoCollectionPagerAdapter.GetPageTitle(i))
                                .SetTabListener(tabListener));
            }
        }
    }
}