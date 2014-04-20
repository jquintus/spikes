using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace DroidSpike
{
    public class MyPagerAdapter : FragmentPagerAdapter
    {
        private List<Android.Support.V4.App.Fragment> fragments;

        public MyPagerAdapter(Android.Support.V4.App.FragmentManager fm, List<Android.Support.V4.App.Fragment> fragments)
            : base(fm)
        {
            this.fragments = fragments;
        }

        public override int Count { get { return fragments.Count; } }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }

    public class Tab1Fragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                 Bundle savedInstanceState)
        {
            return (LinearLayout)inflater.Inflate(Resource.Layout.redlayout, container, false);
        }
    }

    public class Tab2Fragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                 Bundle savedInstanceState)
        {
            return (LinearLayout)inflater.Inflate(Resource.Layout.greenlayout, container, false);
        }
    }

    public class Tab3Fragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                 Bundle savedInstanceState)
        {
            return (LinearLayout)inflater.Inflate(Resource.Layout.bluelayout, container, false);
        }
    }

    //[Activity(Label = "DroidSpike", MainLauncher = true, Icon = "@drawable/icon")]
    public class ViewPagerFragmentActivity : FragmentActivity
    {
        private MyPagerAdapter mPagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.viewpager_layout);

            //initialsie the pager
            InitialisePaging();
        }

        private void InitialisePaging()
        {
            var fragments = new List<Android.Support.V4.App.Fragment>(){
                new Tab1Fragment(),
                new Tab2Fragment(),
                new Tab3Fragment(),
            };

            mPagerAdapter = new MyPagerAdapter(SupportFragmentManager, fragments);

            ViewPager pager = FindViewById<ViewPager>(Resource.Id.viewpager);
            pager.Adapter = mPagerAdapter;
        }
    }
}