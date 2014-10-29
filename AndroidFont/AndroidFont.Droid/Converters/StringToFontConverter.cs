using Android.App;
using Android.Graphics;
using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;

namespace AndroidFont.Droid.Converters
{
    public class StringToFontConverter : MvxValueConverter<string, Typeface>
    {
        private static Dictionary<string, Typeface> _cache = new Dictionary<string, Typeface>();

        protected override Typeface Convert(string fontName, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (!fontName.StartsWith(@"font/")) fontName = @"font/" + fontName;
                if (!fontName.EndsWith(".ttf")) fontName += ".ttf";

                if (!_cache.ContainsKey(fontName))
                {
                    _cache[fontName] = Typeface.CreateFromAsset(Application.Context.Assets, fontName);
                }

                return _cache[fontName];
            }
            catch (Exception e)
            {
                Android.Util.Log.Error("AndroidFont", e.ToString());

                return Typeface.Default;
            }
        }
    }
}