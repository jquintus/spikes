using Android.Content;
using Android.Database;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using HeaderedGridView.Droid.Adapters;
using System.Collections.Generic;

namespace HeaderedGridView.Droid.Controls
{
    public class HeaderedGridView : GridView
    {
        /// <summary>
        /// The default id for the grid header.  This means there is no header
        /// </summary>
        private const int DEFAULT_HEADER_ID = -1;

        private int _cachedColumnWidth;
        private View _header;
        private int _headerId;

        public HeaderedGridView(Context context)
            : this(context, null)
        {
        }

        public HeaderedGridView(Context context, IAttributeSet attrs)
            : this(context, attrs, 0)
        {
            Init(context, attrs);
        }

        public HeaderedGridView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Init(context, attrs);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            if (_header != null && base.ColumnWidth != _cachedColumnWidth)
            {
                _cachedColumnWidth = base.ColumnWidth;
                _header.LayoutParameters = new ViewGroup.LayoutParams(_cachedColumnWidth, _cachedColumnWidth);
            }
        }

        private IListAdapter GetAdapter()
        {
            var headerInfo = GetHeaders();

            ICursor cursor = ImageAdapter.CreateCursor(Context);
            IListAdapter adapter = new ImageAdapter(Context, cursor);

            if (headerInfo != null)
            {
                adapter = new HeaderViewListAdapter(headerInfo, null, adapter);
            }

            return adapter;
        }

        private IList<ListView.FixedViewInfo> GetHeaders()
        {
            LoadHeader();
            if (_header == null) return null;

            var info = new ListView.FixedViewInfo(new ListView(Context))
            {
                Data = null,
                IsSelectable = true,
                View = _header,
            };
            return new List<ListView.FixedViewInfo>() { info };
        }

        private void Init(Context context, IAttributeSet attrs)
        {
            ProcessAttrs(context, attrs);

            Adapter = GetAdapter();
        }

        private void LoadHeader()
        {
            if (_headerId == DEFAULT_HEADER_ID) return;
            IMvxAndroidBindingContext bindingContext = MvxAndroidBindingContextHelpers.Current();
            _header = bindingContext.BindingInflate(_headerId, null);
        }

        private void ProcessAttrs(Context c, IAttributeSet attrs)
        {
            _headerId = DEFAULT_HEADER_ID;
            using (var attributes = c.ObtainDisposableStyledAttributes(attrs, Resource.Styleable.GridView))
            {
                foreach (var a in attributes)
                {
                    switch (a)
                    {
                        case Resource.Styleable.GridView_header:
                            _headerId = attributes.GetResourceId(a, DEFAULT_HEADER_ID);
                            break;
                    }
                }
            }
        }
    }
}
