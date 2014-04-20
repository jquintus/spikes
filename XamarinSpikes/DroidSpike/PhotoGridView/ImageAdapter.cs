using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Provider;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PhotoGridView
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
        private Activity context;

        public CursorImageAdapter(Activity context, ICursor c)
            : base(context, c, true)
        {
            this.context = context;
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            //var textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            //textView.Text = cursor.GetString(1); // 'name' is column 1

            int image_column_index = cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Id);
            var imageView = (ImageView)view;
            int id = cursor.GetInt(image_column_index);

            Bitmap bm = MediaStore.Images.Thumbnails.GetThumbnail(context.ContentResolver, id, ThumbnailKind.MicroKind, null);
            //Bitmap bm = MediaStore.Images.Media.GetBitmap(context.ContentResolver, id);

            BitmapDrawable drawable = imageView.Drawable as BitmapDrawable;

            if (drawable != null && drawable.Bitmap != null)
            {
                //drawable.Bitmap.Dispose();
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

    public class ImageAdapter : BaseAdapter
    {
        private Context context;

        public ImageAdapter(Context c)
        {
            context = c;
        }

        public override int Count { get { return thumbIds.Length; } }

        public Bitmap[] thumbIds { get; set; }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int px = Utils.GetPixFromGridView(context, parent as GridView);

            ImageView imageView;
            if (convertView == null) // if it's not recycled, initialize some attributes
            {
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(px, px);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            imageView.SetImageBitmap(thumbIds[position]);
            return imageView;
        }
    }
}