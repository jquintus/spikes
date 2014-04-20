using Android.Content;
using Android.Graphics;
using System;
using System.IO;

namespace PhotoGridView.BitmapLoaders
{
    public class MediaStoreWithInputParamsToMemoryStream : ALoader
    {
        public override string Name { get { return "MediaStore Using Just Decode Bounds"; } }

        protected override Bitmap Load(Context context, long id)
        {
            using (Bitmap bitmap = CreateFromThumbnailService(id, context, new BitmapFactory.Options() { InJustDecodeBounds = true }))
            {
                int minDimen = Math.Min(bitmap.Height, bitmap.Width);
                bitmap.Recycle();

                int sampleSize = (int)Math.Ceiling((double)(minDimen) / MinSide);

                var options = new BitmapFactory.Options()
                {
                    InSampleSize = sampleSize,
                    InPurgeable = true
                };

                var bm = CreateFromThumbnailService(id, context, options);
                return bm;
            }
        }
    }

    public class MediaStoreToMemoryStream : ALoader
    {
        public override string Name { get { return "MediaStore To Memory Stream"; } }

        protected override Bitmap Load(Context context, long id)
        {
            using (Bitmap bitmap = CreateFromThumbnailService(id, context, null))
            using (var x = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 74, x);
                int minDimen = Math.Min(bitmap.Height, bitmap.Width);
                bitmap.Recycle();
                x.Position = 0;

                int sampleSize = (int)Math.Ceiling((double)(minDimen) / MinSide);

                var options = new BitmapFactory.Options()
                {
                    InSampleSize = sampleSize,
                    InPurgeable = true
                };

                var bm = CreateFromThumbnailService(id, context, options);
                return bm;
            }
        }
    }
}