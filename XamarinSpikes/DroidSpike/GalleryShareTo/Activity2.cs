using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GalleryShareTo
{
    [Activity(Label = "My Activity")]
    [IntentFilter(new[] { Intent.ActionSend, Intent.ActionSendMultiple }
        , Categories = new[] { Intent.CategoryDefault}
        , DataMimeType = "image/*"
        )]
    public class Activity2 : Activity
    {
        private Button _button;

        public string Message
        {
            get { return _button.Text; }
            set { _button.Text = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _button = FindViewById<Button>(Resource.Id.MyButton);

            _button.Text = "Second View";

            if (Intent.Type == null) return;

            switch (Intent.Action)
            {
                case Intent.ActionSend:
                    HandleImage();
                    break;

                case Intent.ActionSendMultiple:
                    HandleMultipleImages();
                    break;
            }
        }

        private void HandleImage()
        {
            var imageUri = Intent.GetParcelableExtra(Intent.ExtraStream);
            if (imageUri != null)
            {
                Message = "Uri is:  " + imageUri.ToString();
            }
            else
            {
                Message = "null uri";
            }
        }

        private void HandleMultipleImages(  )
        {
            var imageUri = Intent.GetParcelableArrayListExtra(Intent.ExtraStream);
            if (imageUri != null)
            {
                Message = "MI:  Uri is:  " + imageUri.Count;
            }
            else
            {
                Message = "MI:  null uri";
            }
        }
    }
}