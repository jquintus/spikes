using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ActionProvider.Providers
{
    public class MyActionProvider : Android.Support.V4.View.ActionProvider
    {
        private Context _context;


        public MyActionProvider(Context context)
            : base(context)
        {

            _context = context;
        }

        public override View OnCreateActionView()
        {
            LayoutInflater layoutInflater = LayoutInflater.From(_context);

            var view = layoutInflater.Inflate(Resource.Layout.myactionlayout, null);
            return view;
        }
    }
}