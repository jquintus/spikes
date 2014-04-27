using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace MvxListWithHeader.Droid
{
    public class DisposableTypedArray : IDisposable, IEnumerable<int>
    {
        private readonly TypedArray _array;

        public DisposableTypedArray(TypedArray array)
        {
            _array = array;
        }

        public TypedArray Array { get { return _array; } }

        public void Dispose()
        {
            _array.Recycle();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return GetIndex(i);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Typed Array Wrappers

        public int Length { get { return _array.Length(); } }

        public bool GetBoolean(int index, bool defValue) { return _array.GetBoolean(index, defValue); }

        public Color GetColor(int index, int defValue) { return _array.GetColor(index, defValue); }

        public ColorStateList GetColorStateList(int index) { return _array.GetColorStateList(index); }

        public float GetDimension(int index, float defValue) { return _array.GetDimension(index, defValue); }

        public int GetDimensionPixelOffset(int index, int defValue) { return _array.GetDimensionPixelOffset(index, defValue); }

        public int GetDimensionPixelSize(int index, int defValue) { return _array.GetDimensionPixelSize(index, defValue); }

        public Drawable GetDrawable(int index) { return _array.GetDrawable(index); }

        public float GetFloat(int index, float defValue) { return _array.GetFloat(index, defValue); }

        public float GetFraction(int index, int @base, int pbase, float defValue) { return _array.GetFraction(index, @base, pbase, defValue); }

        public int GetIndex(int at) { return _array.GetIndex(at); }

        public int GetInt(int index, int defValue) { return _array.GetInt(index, defValue); }

        public int GetInteger(int index, int defValue) { return _array.GetInteger(index, defValue); }

        public int GetLayoutDimension(int index, int defValue) { return _array.GetLayoutDimension(index, defValue); }

        public int GetLayoutDimension(int index, string name) { return _array.GetLayoutDimension(index, name); }

        public string GetNonResourceString(int index) { return _array.GetNonResourceString(index); }

        public int GetResourceId(int index, int defValue) { return _array.GetResourceId(index, defValue); }

        public string GetString(int index) { return _array.GetString(index); }

        public string GetText(int index) { return _array.GetText(index); }

        public string[] GetTextArray(int index) { return _array.GetTextArray(index); }

        public ICharSequence[] GetTextArrayFormatted(int index) { return _array.GetTextArrayFormatted(index); }

        public ICharSequence GetTextFormatted(int index) { return _array.GetTextFormatted(index); }

        public bool GetValue(int index, TypedValue outValue) { return _array.GetValue(index, outValue); }

        public bool HasValue(int index) { return _array.HasValue(index); }

        public TypedValue PeekValue(int index) { return _array.PeekValue(index); }

        #endregion
    }

}