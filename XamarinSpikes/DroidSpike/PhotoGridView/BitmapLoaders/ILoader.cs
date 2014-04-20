using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Util;
using System.Collections.Generic;
using Uri = Android.Net.Uri;

namespace PhotoGridView.BitmapLoaders
{

    public static class PreLoader
    {
        public static void Loader()
        {
            ALoader myLoader;
            myLoader = new MediaStoreToMemoryStream();
            myLoader = new MediaStoreWithInputParamsToMemoryStream();
            myLoader = new ScaledBitmapLoader();
            myLoader = new BitmapFactoryLoader();
            myLoader = new BitmapUtilLoader();
        }
    }


    public abstract class ALoader
    {
        public const int MinSide = 200;

        private static readonly List<ALoader> __loaders;

        static ALoader()
        {
            __loaders = new List<ALoader>();
        }

        public ALoader()
        {
            __loaders.Add(this);
        }

        public abstract string Name { get; }

        public static void TimeIt(Context context, long id)
        {
            foreach (var item in __loaders)
            {
                TimeIt(item, context, id);
            }
        }

        protected static Uri IdToUri(long id)
        {
            var uri = Uri.WithAppendedPath(MediaStore.Images.Media.ExternalContentUri, id.ToString());
            return uri;
        }

        protected Bitmap CreateFromThumbnailService(long id, Context context, BitmapFactory.Options opt)
        {
            Bitmap bm = MediaStore.Images.Thumbnails.GetThumbnail(context.ContentResolver, id, ThumbnailKind.MiniKind, opt);
            return bm;
        }

        protected abstract Bitmap Load(Context context, long id);

        private static void TimeIt(ALoader item, Context context, long id)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            using (var bm = item.Load(context, id))
            {
                sw.Stop();
                bm.Recycle();
            }

            Log.Info("BM_TIMER", string.Format("{0} ran in {1}.{2}seconds", item.Name, sw.Elapsed.Seconds, sw.ElapsedMilliseconds));
        }
    }
}