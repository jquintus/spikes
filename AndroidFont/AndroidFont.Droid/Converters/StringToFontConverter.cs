using Android.App;
using Android.Graphics;
using Cirrious.CrossCore.Converters;
using System;

namespace AndroidFont.Droid.Converters
{
    public class StringToFontConverter : MvxValueConverter<string, Typeface>
    {
        protected override Typeface Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Typeface.CreateFromAsset(Application.Context.Assets, "font/Fontin-Italic.ttf");
        }
    }
}