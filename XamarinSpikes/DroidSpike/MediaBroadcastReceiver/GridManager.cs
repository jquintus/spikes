using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Util;
using Android.Widget;
using System.Collections.Generic;

namespace MediaBroadcastReceiver
{
    public class GridManager
    {
        private readonly Context _ctx;
        private readonly GridView _grid;
        private readonly List<PhotosObserver> _observers;
        private IListAdapter _adapter;
        private CursorLoader _loader;

        public GridManager(Context ctx, GridView grid, List<PhotosObserver> observers)
        {
            _grid = grid;
            _ctx = ctx;
            _observers = observers;

            foreach (var observer in observers)
            {
                observer.DataUpdated += delegate { Swap(); };
            }
        }

        public void Init()
        {
            CreateLoader();
            CreateAdapter();

            _grid.Adapter = _adapter;
        }

        private void CreateAdapter()
        {
            var cursor = (ICursor)_loader.LoadInBackground();

            _adapter = new CursorImageAdapter(_ctx, cursor);
        }

        private void CreateLoader()
        {
            string[] columns = { MediaStore.Images.Media.InterfaceConsts.Data, MediaStore.Images.Media.InterfaceConsts.Id };
            string orderBy = MediaStore.Images.Media.InterfaceConsts.Id;
            _loader = new CursorLoader(_ctx, MediaStore.Images.Media.ExternalContentUri, columns, null, null, orderBy + " DESC");
        }

        private void Swap()
        {
            try
            {
                var cursor = (ICursor)_loader.LoadInBackground();
                ((CursorAdapter)_adapter).ChangeCursor(cursor);
            }
            catch (System.Exception e)
            {
                Log.Error(A.B, "Error swapping cursor" + e.Message);
            }
        }
    }
}