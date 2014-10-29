using Cirrious.MvvmCross.ViewModels;

namespace AndroidFont.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        public string FontName { get { return "Fontin-Regular"; } }
        public string FontNameItalic { get { return "Fontin-Italic"; } }

    }
}
