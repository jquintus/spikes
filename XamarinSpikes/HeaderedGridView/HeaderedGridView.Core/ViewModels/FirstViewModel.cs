using Cirrious.MvvmCross.ViewModels;
using HeaderedGridView.Core.Services;

namespace HeaderedGridView.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly IMessageService _message;
        public FirstViewModel(IMessageService message)
        {
            _message = message;
        }

        public MvxCommand ClickCommand
        {
            get { return new MvxCommand(() => _message.Show("Button pressed")); }
        }
    }
}
