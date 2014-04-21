using Android.Content;
using Android.Util;

namespace HeaderedGridView.Droid
{
    public static class ContextExtensions
    {
        /// <summary>
        /// Retrieve styled attribute information in this Context's theme.
        /// </summary>
        /// <remarks>
        /// Retrieve styled attribute information in this Context's theme. See Android.Content.Res.Resources.Theme.ObtainStyledAttributes(Android.Util.IAttributeSet,
        /// System.Int32[], System.Int32[], System.Int32[]) for more information.
        /// [Android Documentation]
        /// </remarks>
        public static DisposableTypedArray ObtainDisposableStyledAttributes(this Context ctx, int[] attrs)
        {
            return new DisposableTypedArray(ctx.ObtainStyledAttributes(attrs));
        }

        /// <summary>
        /// Retrieve styled attribute information in this Context's theme.
        /// </summary>
        /// <remarks>
        /// Retrieve styled attribute information in this Context's theme. See Android.Content.Res.Resources.Theme.ObtainStyledAttributes(Android.Util.IAttributeSet,
        /// System.Int32[], System.Int32[], System.Int32[]) for more information.
        /// [Android Documentation]
        /// </remarks>
        public static DisposableTypedArray ObtainDisposableStyledAttributes(this Context ctx, IAttributeSet set, int[] attrs)
        {
            return new DisposableTypedArray(ctx.ObtainStyledAttributes(set, attrs));
        }

        /// <summary>
        /// Retrieve styled attribute information in this Context's theme.
        /// </summary>
        /// <exception cref="Android.Content.Res.Resources+NotFoundException"/>
        /// <remarks>
        /// Retrieve styled attribute information in this Context's theme. See Android.Content.Res.Resources.Theme.ObtainStyledAttributes(System.Int32,
        /// System.Int32[]) for more information.
        /// [Android Documentation]
        /// </remarks>
        public static DisposableTypedArray ObtainDisposableStyledAttributes(this Context ctx, int resid, int[] attrs)
        {
            return new DisposableTypedArray(ctx.ObtainStyledAttributes(resid, attrs));
        }

        /// <summary>
        /// Retrieve styled attribute information in this Context's theme.
        /// </summary>
        /// <remarks>
        /// Retrieve styled attribute information in this Context's theme. See Android.Content.Res.Resources.Theme.ObtainStyledAttributes(Android.Util.IAttributeSet,
        /// System.Int32[], System.Int32[], System.Int32[]) for more information.
        /// [Android Documentation]
        /// </remarks>
        public static DisposableTypedArray ObtainDisposableStyledAttributes(this Context ctx, IAttributeSet set, int[] attrs, int defStyleAttr, int defStyleRes)
        {
            return new DisposableTypedArray(ctx.ObtainStyledAttributes(set, attrs, defStyleAttr, defStyleRes));
        }
    }
}