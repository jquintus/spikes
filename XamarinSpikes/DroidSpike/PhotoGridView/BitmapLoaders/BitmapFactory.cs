using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Net;
using Android.Graphics;
using System.IO;
using Uri = Android.Net.Uri;
using System;

namespace PhotoGridView.BitmapLoaders
{
    public class BitmapFactoryLoader : ALoader
    {
        public override string Name
        {
            get { return "Load from Bitmap Factory"; }
        }

        protected override Android.Graphics.Bitmap Load(Context _context, long id)
        {
            var uri = IdToUri(id);

            using (var inputStream = _context.ContentResolver.OpenInputStream(uri))
            {
                int minDimen = GetSmallestDimensionOfImage(_context.ContentResolver, uri);

                int sampleSize = (int)Math.Ceiling((double)minDimen / MinSide);

                var options = new BitmapFactory.Options()
                {
                    InSampleSize = sampleSize,
                    //InPurgeable = true 
                };

                var bitmap = BitmapFactory.DecodeStream(inputStream, null, options);
                return bitmap;
            }
        }

  

        private static int GetSmallestDimensionOfImage(ContentResolver cr, Uri uri)
        {
            using (var inputStream = cr.OpenInputStream(uri))
            {
                var justSizeOptions = new BitmapFactory.Options();
                justSizeOptions.InJustDecodeBounds = true;

                BitmapFactory.DecodeStream(inputStream, new Rect(), justSizeOptions);

                return Math.Min(justSizeOptions.OutHeight, justSizeOptions.OutWidth);
            }
        }
    }

}