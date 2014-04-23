using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Provider;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MediaBroadcastReceiver
{
    public static class Utils
    {
        public static int DipToPixels(Context context, float dipValue)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dipValue, metrics);
        }

        public static int GetPixFromGridView(Context context, GridView grid)
        {
            if (grid == null) return (int)Utils.DipToPixels(context, 90);
            return (int)DipToPixels(context, grid.ColumnWidth);
        }
    }

    public class CursorImageAdapter : CursorAdapter
    {
        private Context context;

        public CursorImageAdapter(Context context, ICursor c)
            : base(context, c, true)
        {
            this.context = context;
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            int image_column_index = cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Id);
            var imageView = (ImageView)view;
            int id = cursor.GetInt(image_column_index);

            Bitmap bm = MediaStore.Images.Thumbnails.GetThumbnail(context.ContentResolver, id, ThumbnailKind.MicroKind, null);

            BitmapDrawable drawable = imageView.Drawable as BitmapDrawable;

            if (drawable != null && drawable.Bitmap != null)
            {
                drawable.Bitmap.Recycle();
            }

            imageView.SetImageBitmap(bm);
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            var gv = parent as GridView;

            int px = Utils.GetPixFromGridView(context, parent as GridView);
            px = gv.ColumnWidth;

            var imageView = new ImageView(context);
            imageView.LayoutParameters = new GridView.LayoutParams(px, px);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetPadding(8, 8, 8, 8);

            return imageView;
        }
    }
}