using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace MvvmCrossSpikes.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public FirstViewModel()
        {
            MyCommand = new MvxCommand(() => Hello = "Command run", () => Hello.Length == 0);
        }

        public MvxCommand MyCommand { get; set; }



        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set
            {
                _hello = value;
                RaisePropertyChanged(() => Hello);
                MyCommand.RaiseCanExecuteChanged();
            }
        }


        public List<string> Images { get; set; }
    }
}
