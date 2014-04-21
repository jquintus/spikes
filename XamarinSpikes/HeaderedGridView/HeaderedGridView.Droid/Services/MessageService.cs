using Android.Widget;
using Cirrious.CrossCore.Droid.Platform;
using HeaderedGridView.Core.Services;

namespace HeaderedGridView.Droid.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMvxAndroidCurrentTopActivity _currentActivity;

        public MessageService(IMvxAndroidCurrentTopActivity currentActivity)
        {
            _currentActivity = currentActivity;
        }

        public void Show(string message)
        {
            var toast = Toast.MakeText(_currentActivity.Activity, message, ToastLength.Short);
            toast.Show();
        }
    }
}