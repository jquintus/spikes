using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;

namespace SwipeyView
{
    public class DemoCollectionPagerAdapter : FragmentPagerAdapter
    {
        public DemoCollectionPagerAdapter(FragmentManager fm)
            : base(fm)
        {
        }

        public override int Count { get { return 4; } }

        public override Fragment GetItem(int i)
        {
            switch (i)
            {
                case 0: return new TabOne();
                case 1: return new TabTwo();
                case 2: return new TabThree();
                case 3: return new TabFour();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class DemoObjectFragment : Fragment
    {
        public const string ARG_OBJECT = "object";

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // The last two arguments ensure LayoutParams are inflated properly
            View rootView = inflater.Inflate(Resource.Layout.fragment_collection_object, container, false);

            Bundle args = Arguments;
            var view = rootView.FindViewById<TextView>(Android.Resource.Id.Text1);

            view.Text = args.GetInt(ARG_OBJECT).ToString();
            return rootView;
        }
    }

    public abstract class JoshFragment : Fragment
    {
        private int _id;

        public JoshFragment(int id)
        {
            _id = id;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(_id, container, false);
            return rootView;
        }
    }

    public class TabFour : JoshFragment
    {
        public TabFour()
            : base(Resource.Layout.layout4)
        {
        }
    }

    public class TabOne : JoshFragment
    {
        public TabOne()
            : base(Resource.Layout.layout1)
        {
        }
    }

    public class TabThree : JoshFragment
    {
        public TabThree()
            : base(Resource.Layout.layout3)
        {
        }
    }

    public class TabTwo : JoshFragment
    {
        public TabTwo()
            : base(Resource.Layout.layout2)
        {
        }
    }
}