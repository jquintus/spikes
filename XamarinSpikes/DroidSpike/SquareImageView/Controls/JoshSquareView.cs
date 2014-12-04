using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace SquareImageView.Controls
{
    public class JoshSquareView : View
    {
        public JoshSquareView(Context context) : base(context) { }

        public JoshSquareView(Context context, IAttributeSet attrs) : base(context, attrs) { }

        public JoshSquareView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { }

        protected JoshSquareView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            Console.WriteLine("Input:  {0} x {1}", widthMeasureSpec, heightMeasureSpec);
            heightMeasureSpec = widthMeasureSpec;
            Console.WriteLine("Output:  {0} x {1}", widthMeasureSpec, heightMeasureSpec);

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}