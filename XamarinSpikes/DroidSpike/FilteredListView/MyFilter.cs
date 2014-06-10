using Android.Widget;
using Java.Lang;
using System.Collections.Generic;
using System.Linq;

namespace FilteredListView
{
    public class MyFilter : Filter
    {
        private MyAdapter _adapter;
        private List<string> _items;

        public MyFilter(List<string> items, MyAdapter adapter)
        {
            _items = items;
            _adapter = adapter;
        }

        protected override Filter.FilterResults PerformFiltering(ICharSequence constraint)
        {
            string sConsraint = ToString(constraint);
            return PerformFiltering(sConsraint);
        }

        private class JavaWrapper<T> : Java.Lang.Object
        {
            private readonly T _wrapped;
            public T Wrapped { get { return _wrapped; } }
            public JavaWrapper(T wrapped)
            {
                _wrapped = wrapped;
            }
        }

        protected override void PublishResults(ICharSequence constraint, Filter.FilterResults results)
        {
            _adapter.MatchItems = ((JavaWrapper<string[]>)results.Values).Wrapped;
            if (results.Count == 0)
            {
                _adapter.NotifyDataSetInvalidated();
            }
            else
            {
                _adapter.NotifyDataSetChanged();
            }
        }

        private Filter.FilterResults PerformFiltering(string constraint)
        {
            Filter.FilterResults results = new FilterResults();
            if (string.IsNullOrEmpty(constraint))
            {
                results.Values = ToJavaList(_items.ToArray());
                results.Count = _items.Count;
            }
            else
            {
                var values = _items.Where(i => i.ToLower().Contains(constraint.ToLower())).ToArray();
                results.Values = ToJavaList(values);
                results.Count = values.Count();
            }
            return results;
        }

        private Java.Lang.Object ToJavaList(string[] list)
        {
            return new JavaWrapper<string[]>(list);
            //return list.Select(l => new Java.Lang.String(l)).ToArray();
        }

        private string ToString(ICharSequence constraint)
        {
            if (constraint == null) return null;

            return constraint.ToString();
        }
    }
}