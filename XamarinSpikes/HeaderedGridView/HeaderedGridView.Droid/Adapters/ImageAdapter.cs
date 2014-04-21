using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Provider;
using Android.Views;
using Android.Widget;

namespace HeaderedGridView.Droid.Adapters
{
    public class ImageAdapter : CursorAdapter
    {
        private readonly Context context;

        public ImageAdapter(Context context, ICursor c)
            : base(context, c, true)
        {
            this.context = context;
        }

        public static ICursor CreateCursor(Context ctx)
        {
            string[] columns = { MediaStore.Images.Media.InterfaceConsts.Data, MediaStore.Images.Media.InterfaceConsts.Id };

            string orderBy = MediaStore.Images.Media.InterfaceConsts.Id;

            var loader = new Android.Support.V4.Content.CursorLoader(ctx, MediaStore.Images.Media.ExternalContentUri, columns, null, null, orderBy + " DESC");
            var imagecursor = (ICursor)loader.LoadInBackground();

            return imagecursor;
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
            var grid = (GridView)parent;

            var imageView = new ImageView(context);
            imageView.LayoutParameters = new GridView.LayoutParams(grid.ColumnWidth, grid.ColumnWidth);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetPadding(8, 8, 8, 8);

            return imageView;
        }
    }
}