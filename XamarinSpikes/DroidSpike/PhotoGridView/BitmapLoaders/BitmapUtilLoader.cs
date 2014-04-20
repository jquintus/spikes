using Android.Graphics;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoGridView.BitmapLoaders
{
    /// <summary>
    /// http://stackoverflow.com/a/12294235/1480854
    /// </summary>
    public class BitmapUtilLoader : ALoader
    {
        public override string Name
        {
            get { return "Bitmap Util"; }
        }

        protected override Bitmap Load(Android.Content.Context _context, long id)
        {

            var uri = IdToUri(id);


            using (var inputStream = _context.ContentResolver.OpenInputStream(uri))
            {
                var bitmap = BitmapFactory.DecodeStream(inputStream, null, null);
                Bitmap ThumbImage = ThumbnailUtils.ExtractThumbnail(bitmap, MinSide, MinSide);

                bitmap.Recycle();
                bitmap.Dispose();

                return ThumbImage;
            }
        }
    }
}
