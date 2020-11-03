using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public static class ResourceHelper
    {
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //public static ResourceDictionary CurrentTheme
        //{
        //    get
        //    {
        //        App.Current.UserAppTheme = OSAppTheme.Light;
        //        return LoadLightTheme();
        //        //return LoadDarkTheme();
        //    }
        //}

        //~~ Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Color PrimaryColor => GetColor(nameof(PrimaryColor));
        public static Color SecondaryColor => GetColor(nameof(SecondaryColor));

        public static Color PrimaryTextColor => GetColor(nameof(PrimaryTextColor));

        public static Color SurfaceColor => GetColor(nameof(SurfaceColor));

        //~~ Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public static Style ButtonEmptyStyle => GetStyle(nameof(ButtonEmptyStyle));

        public static Style LabelFieldHelperTextStyle => GetStyle(nameof(LabelFieldHelperTextStyle));

        public static Style FrameCardStyle => GetStyle(nameof(FrameCardStyle));

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

        //private static ResourceDictionary LoadDarkTheme() => new ThemeDark().Load();
        //private static ResourceDictionary LoadLightTheme() => new ThemeLight().Load();
        
        private static void LoadDarkTheme()
		{
            LoadTheme(new ThemeDark().Load());
            CurrentTheme = OSAppTheme.Dark;

            CurrentAppTheme = AppTheme.Dark;
        }

        private static void LoadLightTheme()
		{
            LoadTheme(new ThemeLight().Load());
            CurrentTheme = OSAppTheme.Light;

            CurrentAppTheme = AppTheme.Light;
        }

        private static void LoadTheme(AppTheme _newTheme)
		{
            if (_newTheme == AppTheme.Light)
			{
                LoadLightTheme();
			}
            else
			{
                LoadDarkTheme();
            }
		}

        private static void LoadTheme(OSAppTheme _newTheme)
        {
            if (_newTheme == OSAppTheme.Light)
            {
                LoadLightTheme();
            }
            else
            {
                LoadDarkTheme();
            }
        }

        private static void LoadTheme(ResourceDictionary _newTheme)
        {
            if (App.Current.Resources != null)
            {
                App.Current.Resources.Clear();
            }

            App.Current.Resources = _newTheme ?? new ResourceDictionary();
        }

        public static OSAppTheme CurrentTheme { get; private set; }

        public static AppTheme CurrentAppTheme { get; private set; }

        public static void LoadStartupTheme()
		{
            App.Current.UserAppTheme = (AppInfo.RequestedTheme == AppTheme.Light) ?
                OSAppTheme.Light : OSAppTheme.Dark;

            if (App.Current.UserAppTheme == OSAppTheme.Light)
			{
                LoadLightTheme();
            }
            else
			{
                LoadDarkTheme();
            }
        }

        public static void ThemeChangeRequested(OSAppTheme _newTheme)
		{
            if (_newTheme == OSAppTheme.Unspecified) _newTheme = OSAppTheme.Dark;

            if (_newTheme != CurrentTheme)
			{
                LoadTheme(_newTheme);
            }
		}

        public static void ThemeChangeRequested(AppTheme _newTheme)
		{
            //Unspecified ?

            if (_newTheme != CurrentAppTheme)
			{
                LoadTheme(_newTheme);
			}
        }

        public static void ToggleTheme()
		{
            if (CurrentAppTheme == AppTheme.Light)
			{
                LoadDarkTheme();
			}
            else
			{
                LoadLightTheme();
			}
		}
    }
}
