using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using R = Android.Resource;

namespace PhotoGridView
{
    public class CheckableRelativeLayout : RelativeLayout, ICheckable
    {
        private readonly static int[] CheckedStateSet = { R.Attribute.StateChecked };

        public CheckableRelativeLayout(Context context)
            : base(context, null)
        {
        }

        public CheckableRelativeLayout(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public bool Checked { get; set; }

        public void Toggle()
        {
            Checked = !Checked;
        }

        protected override int[] OnCreateDrawableState(int extraSpace)
        {
            var drawableState = base.OnCreateDrawableState(extraSpace);

            if (Checked)
            {
                MergeDrawableStates(drawableState, CheckedStateSet);
            }

            return drawableState;
        }
    }
}