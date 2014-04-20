using Android.App;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Support.V4.Content;
using Android.Widget;
using PhotoGridView.BitmapLoaders;
using System;

namespace PhotoGridView
{
    //[Activity(Label = "PhotoGridView", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private Button _cursorButton;
        private Button _arrayButton;
        private GridView _gridView;

        //private ImageAdapter imageAdapter;
        private ICursor _imagecursor;

        private Bitmap[] thumbnails;
        private bool[] thumbnailsselection;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _cursorButton = FindViewById<Button>(Resource.Id.CursorButton);
            _cursorButton.Click += cursorbutton_Click;

            _arrayButton = FindViewById<Button>(Resource.Id.ArrayButton);
            _arrayButton.Click += (s, e) => runDiagnostics();
            //_arrayButton.Click += arraybutton_Click;


            _gridView = FindViewById<GridView>(Resource.Id.gridView1);
            _gridView.ItemClick += _gridVIew_ItemClick;

            _gridView.EmptyView = LayoutInflater.Inflate(Resource.Layout.EmptyLayout, null);

            //cursorbutton_Click(null, null);
        }

        private void runDiagnostics()
        {
            PreLoader.Loader();
            ALoader.TimeIt(this, 1913);
        }

        void _gridVIew_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();

        }
        private void arraybutton_Click(object sender, EventArgs e)
        {
            CreateCursor();
            CanYouPictureThat();
        }

        private void cursorbutton_Click(object sender, EventArgs e)
        {
            //CanYouPictureThat();
            CreateCursor();
            _gridView.Adapter = new CursorImageAdapter(this, _imagecursor);
        }

        private void CanYouPictureThat()
        {
            string orderBy = CreateCursor();

            Console.WriteLine("Getting column index");
            int image_column_index = _imagecursor.GetColumnIndex(orderBy);

            var count = _imagecursor.Count;
            Console.WriteLine("Found {0} photos", count);

            this.thumbnails = new Bitmap[count];
            var arrPath = new string[count];
            this.thumbnailsselection = new bool[count];

            for (int i = 0; i < count; i++)
            {
                _imagecursor.MoveToPosition(i);
                int id = _imagecursor.GetInt(image_column_index);
                int dataColumnIndex = _imagecursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Data);

                thumbnails[i] = MediaStore.Images.Thumbnails.GetThumbnail(ApplicationContext.ContentResolver, id, ThumbnailKind.MicroKind, null);
                arrPath[i] = _imagecursor.GetString(dataColumnIndex);
                if (i % 25 == 0)
                {
                    Console.WriteLine("Processing {0}th photo", i);
                }
            }

            Console.WriteLine("All photos processed, creating image adapter");

            var imageAdapter = new ImageAdapter(this)
            {
                thumbIds = thumbnails
            };

            Console.WriteLine("Assigning adapter to grid view");
            _gridView.Adapter = imageAdapter;

            Console.WriteLine("done");
        }

        private string CreateCursor()
        {
            string[] columns = { MediaStore.Images.Media.InterfaceConsts.Data, MediaStore.Images.Media.InterfaceConsts.Id };

            string orderBy = MediaStore.Images.Media.InterfaceConsts.Id;

            Console.WriteLine("Creating cursor");
            //_imagecursor = ManagedQuery(MediaStore.Images.Media.ExternalContentUri, columns, null, null, orderBy + " DESC");


            var loader = new CursorLoader(this, MediaStore.Images.Media.ExternalContentUri, columns, null, null, orderBy + " DESC");
            _imagecursor = (ICursor)loader.LoadInBackground();

            return orderBy;
        }
    }
}