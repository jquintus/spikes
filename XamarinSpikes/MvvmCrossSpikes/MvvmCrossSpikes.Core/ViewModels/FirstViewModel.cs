using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MvvmCrossSpikes.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public FirstViewModel()
        {

        }



        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }


        public List<string> Images { get; set; }
    }
}
