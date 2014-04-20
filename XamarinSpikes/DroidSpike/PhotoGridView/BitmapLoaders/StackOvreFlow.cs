using Android.Content;
using Android.Graphics;

namespace PhotoGridView.BitmapLoaders
{
    public class ScaledBitmapLoader : ALoader
    {
        public override string Name
        {
            get { return "Stack Overflow Answer #1"; }
        }

        protected override Bitmap Load(Context _context, long id)
        {
            var uri = IdToUri(id);

            using (var inputStream = _context.ContentResolver.OpenInputStream(uri))
            {
                Bitmap imageBitmap = BitmapFactory.DecodeStream(inputStream);

                imageBitmap = Bitmap.CreateScaledBitmap(imageBitmap, MinSide, MinSide, false);

                return imageBitmap;
            }
        }
    }
}