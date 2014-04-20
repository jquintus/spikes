using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
using System.Collections;

namespace DroidSpike
{
    public class CursorReader<T> : IEnumerable<T>, IDisposable, IEnumerator<T>
    {
        private readonly ICursor _cursor;
        private readonly Func<ICursor, T> _factory;

        public CursorReader(ICursor cursor, Func<ICursor, T> factory)
        {
            _cursor = cursor;
            _factory = factory;
        }

        public T Current
        {
            get
            {
                T item = _factory(_cursor);
                return item;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            _cursor.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            return _cursor.MoveToNext();
        }

        public void Reset()
        {
            _cursor.MoveToFirst();
        }
    }
}