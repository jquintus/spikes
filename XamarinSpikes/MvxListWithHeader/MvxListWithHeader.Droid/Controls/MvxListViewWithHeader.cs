using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using MvxListWithHeader.Droid.Adapters;
using System.Collections.Generic;

namespace MvxListWithHeader.Droid.Controls
{
    public class MvxListViewWithHeader : MvxListView
    {
        /// <summary>
        /// The default id for the grid header/footer.  This means there is no header/footer
        /// </summary>
        private const int DEFAULT_HEADER_ID = -1;

        private int _footerId;
        private int _headerId;

        public MvxListViewWithHeader(Context context, IAttributeSet attrs)
            : base(context, attrs, null)
        {
            IMvxAdapter adapter = new MvxAdapter(context);

            ApplyAttributes(context, attrs);

            var itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
            adapter.ItemTemplateId = itemTemplateId;

            var headers = GetHeaders();
            var footers = GetFooters();

            IMvxAdapter headerAdapter = new HeaderMvxAdapter(headers, footers, adapter);

            Adapter = headerAdapter;
        }

        private void ApplyAttributes(Context c, IAttributeSet attrs)
        {
            _headerId = DEFAULT_HEADER_ID;
            _footerId = DEFAULT_HEADER_ID;

            using (var attributes = c.ObtainDisposableStyledAttributes(attrs, Resource.Styleable.ListView))
            {
                foreach (var a in attributes)
                {
                    switch (a)
                    {
                        case Resource.Styleable.ListView_header:
                            _headerId = attributes.GetResourceId(a, DEFAULT_HEADER_ID);
                            break;

                        case Resource.Styleable.ListView_footer:
                            _footerId = attributes.GetResourceId(a, DEFAULT_HEADER_ID);
                            break;
                    }
                }
            }
        }

        private IList<ListView.FixedViewInfo> GetFixedViewInfos(int id)
        {
            var viewInfos = new List<ListView.FixedViewInfo>();

            View view = GetBoundView(id);

            if (view != null)
            {
                var info = new ListView.FixedViewInfo(this)
                {
                    Data = null,
                    IsSelectable = true,
                    View = view,
                };
                viewInfos.Add(info);
            }

            return viewInfos;
        }

        private IList<ListView.FixedViewInfo> GetFooters()
        {
            return GetFixedViewInfos(_footerId);
        }

        private IList<ListView.FixedViewInfo> GetHeaders()
        {
            return GetFixedViewInfos(_headerId);
        }

        private View GetBoundView(int id)
        {
            if (id == DEFAULT_HEADER_ID) return null;

            IMvxAndroidBindingContext bindingContext = MvxAndroidBindingContextHelpers.Current();
            var view = bindingContext.BindingInflate(id, null);

            return view;
        }
    }
}