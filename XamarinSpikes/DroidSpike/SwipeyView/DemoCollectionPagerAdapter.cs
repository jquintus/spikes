using Android.OS;
using Android.Support.V4.App;
using Android.Text;
using Android.Views;
using System.Collections.Generic;

namespace SwipeyView
{
    public class DemoCollectionPagerAdapter : FragmentPagerAdapter
    {
        public DemoCollectionPagerAdapter(FragmentManager fm, Dictionary<int, int> pageNumberToLayoutId)
            : base(fm)
        {
            _pageNumberToLayoutId = pageNumberToLayoutId;
        }

        public Dictionary<int, int> _pageNumberToLayoutId { get; set; }
        public override int Count { get { return _pageNumberToLayoutId.Count; } }

        public override Fragment GetItem(int i)
        {
            Fragment fragment = new SimpleFragment()
            {
                Arguments = new Bundle()
            };
            fragment.Arguments.PutInt(SimpleFragment.LAYOUT_ID_KEY, _pageNumberToLayoutId[i]);
            return fragment;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            SpannedString txt = new SpannedString(new string('x', 1 + position));
            return txt;
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