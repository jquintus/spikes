using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using System.Collections;
using System.Collections.Generic;

namespace MvxListWithHeader.Droid.Adapters
{
    public class HeaderMvxAdapter : HeaderViewListAdapter, IMvxAdapter
    {
        private readonly IMvxAdapter _adapter;

        public HeaderMvxAdapter(IList<ListView.FixedViewInfo> headers, IMvxAdapter adapter)
            : this(headers, new List<ListView.FixedViewInfo>(), adapter)
        { }

        public HeaderMvxAdapter(IList<ListView.FixedViewInfo> headers, IList<ListView.FixedViewInfo> footers, IMvxAdapter adapter)
            : base(headers, footers, adapter)
        {
            _adapter = adapter;
        }

        public int DropDownItemTemplateId
        {
            get { return _adapter.DropDownItemTemplateId; }
            set { _adapter.DropDownItemTemplateId = value; }
        }

        public IEnumerable ItemsSource
        {
            get { return _adapter.ItemsSource; }
            set { _adapter.ItemsSource = value; }
        }

        public int ItemTemplateId
        {
            get { return _adapter.ItemTemplateId; }
            set { _adapter.ItemTemplateId = value; }
        }

        public int SimpleViewLayoutId
        {
            get { return _adapter.SimpleViewLayoutId; }
            set { _adapter.SimpleViewLayoutId = value; }
        }

        public View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            return _adapter.GetDropDownView(position, convertView, parent);
        }

        public int GetPosition(object value)
        {
            return _adapter.GetPosition(value);
        }

        public object GetRawItem(int position)
        {
            return _adapter.GetRawItem(position);
        }
    }
}