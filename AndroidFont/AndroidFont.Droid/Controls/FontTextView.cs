using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using System;
using System.Linq;

namespace AndroidFont.Droid.Controls
{
    public class FontTextView : TextView
    {
        public FontTextView(Context context)
            : base(context)
        {
            Init(context);
        }

        public FontTextView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Init(context);
        }

        public FontTextView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            this.Typeface = Typeface.CreateFromAsset(context.Assets, "font/Fontin-Italic.ttf");
        }
    }
}