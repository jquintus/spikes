using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

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


        private string _selectedFont = "Fontin-Regular";

        public string SelectedFont
        {
            get { return _selectedFont; }
            set { _selectedFont = value; RaisePropertyChanged(() => SelectedFont); }
        }

        public string ItalicFont { get { return "Fontin-Italic"; } }

        public List<string> FontNames
        {
            get
            {
                return new List<string>(){
                    "Fontin-Regular",
                    "Fontin-Bold",
                    "Fontin-Italic",
                    "Fontin-SmallCaps"
                };
            }
        }
    }
}
