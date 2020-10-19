using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public static class ResourceHelper
    {
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public static ResourceDictionary CurrentTheme
        {
            get
            {


                return LoadLightTheme();
            }
        }

        //~~ Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Color PrimaryColor => GetColor(nameof(PrimaryColor));
        public static Color SecondaryColor => GetColor(nameof(SecondaryColor));

        public static Color PrimaryTextColor => GetColor(nameof(PrimaryTextColor));


		//~~ Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static Style LabelFieldHelperTextStyle => GetStyle(nameof(LabelFieldHelperTextStyle));

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static Color GetColor(string _key) => GetResourceOrDefault<Color>(_key);

        private static T GetResourceOrDefault<T>(string _key)
		{
            var resource = default(T);

            if (_key.IsNullOrEmpty()) return resource;

            if (App.Current.Resources.TryGetValue(_key, out object value))
            {
                if (value is T)
                {
                    resource = (T)value;
                }
                else
                {
                    // log - key of "" does not match type ""
                }
            }
            else
            {
                // log - key not found
            }

            return resource;
		}

        private static Style GetStyle(string _key) => GetResourceOrDefault<Style>(_key);

        private static ResourceDictionary LoadLightTheme() => new ThemeLight().Load();
    }
}
