using Android.OS;
using Android.Support.V4.App;
using Android.Views;

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
            Fragment fragment = new SimpleFragment()
            {
                Arguments = new Bundle()
            };
            fragment.Arguments.PutInt(SimpleFragment.LAYOUT_ID_KEY, GetLayoutId(i));
            return fragment;
        }

        private int GetLayoutId(int i)
        {
            switch (i)
            {
                case 0: return Resource.Layout.layout1;
                case 1: return Resource.Layout.layout2;
                case 2: return Resource.Layout.layout3;
                case 3: return Resource.Layout.layout4;
                default: return Resource.Layout.default_fragment_view;
            }
        }
    }

    public class SimpleFragment : Fragment
    {
        public const string LAYOUT_ID_KEY = "LAYOUT ID KEY";

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            int id = Arguments.GetInt(LAYOUT_ID_KEY);
            View rootView = inflater.Inflate(id, container, false);
            return rootView;
        }
    }
}