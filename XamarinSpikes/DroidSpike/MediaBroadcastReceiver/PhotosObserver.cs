using Android.Content;
using Android.Database;
using Android.Net;
using Android.Provider;
using Android.Util;
using Java.IO;
using DateTime = System.DateTime;

namespace MediaBroadcastReceiver
{
    public class Media
    {
        public System.DateTime Added { get; set; }
        public File File { get; set; }
        public System.DateTime Modified { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            try
            {
                return string.Format("{0} {1} Added: {2}, Modified {3}", File.AbsolutePath, Type, Added, Modified);
            }
            catch (System.Exception e)
            {
                return "Error to-stringing the media object:  " + e.Message;
            }
        }
    }

    public class PhotosObserver : ContentObserver
    {
        private readonly Context _context;
        private readonly string _name;
        private readonly Uri _uri;

        public PhotosObserver(Context context, string name, Uri uri)
            : base(null)
        {
            _context = context;
            _uri = uri;
            _name = name;
        }

        public static PhotosObserver CreateExternalObserver(Context context)
        {
            return new PhotosObserver(context, "External", MediaStore.Images.Media.ExternalContentUri);
        }

        public static PhotosObserver CreateInternalObserver(Context context)
        {
            return new PhotosObserver(context, "Internal", MediaStore.Images.Media.InternalContentUri);
        }

        public override void OnChange(bool selfChange)
        {
            base.OnChange(selfChange);
            Media media = ReadFromMediaStore(_context, _uri);
            if (media != null)
            {
                string saved = string.Format("{0} detected {1}", _name, media);
                Log.Info(A.B, saved);
            }
        }

        public PhotosObserver Register()
        {
            var resolver = _context.ApplicationContext.ContentResolver;
            resolver.RegisterContentObserver(_uri, true, this);

            return this;
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Local);
            return epoch.AddSeconds(unixTime);
        }

        private Media ReadFromMediaStore(Context context, Uri uri)
        {
            ICursor cursor = context.ContentResolver.Query(uri, null, null, null, "date_added DESC");
            Media media = null;
            if (cursor.MoveToNext())
            {
                int dataColumn = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data);
                int mimeTypeColumn = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.MimeType);
                int modifiedColumn = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.DateModified);
                int dateAddedColumn = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.DateAdded);

                string filePath = cursor.GetString(dataColumn);
                string mimeType = cursor.GetString(mimeTypeColumn);

                var added = cursor.GetLong(dateAddedColumn);
                var modified = cursor.GetLong(dateAddedColumn);

                media = new Media()
                {
                    File = new File(filePath),
                    Type = mimeType,
                    Modified = FromUnixTime(modified),
                    Added = FromUnixTime(added),
                };
            }
            cursor.Close();
            return media;
        }
    }
}