using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AreWeThereYet.Pages;
using Xamarin.Forms;

namespace AreWeThereYet
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new MapPage();
        }
    }
}
