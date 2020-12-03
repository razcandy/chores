using ChoresApp.Data.Messaging;
using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public static class ResourceHelper
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public const double DefaultIconSize = 30;
        public const double HeaderHeight = 50;
        public const double FooterHeight = 50;
        public const int DefaultCornerRadius = 3;
        public const int DefaultButtonHeight = 50;

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static string DefaultDateTimeFormat = "yyyy/MM/dd";
        public static string DefaultTimeSpanFormat = @"hh\:mm";

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~ Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Color BackgroundColor => GetColor(nameof(ThemeBase.BackgroundColor));
        public static Color PrimaryColor => GetColor(nameof(ThemeBase.PrimaryColor));
        public static Color SecondaryColor => GetColor(nameof(ThemeBase.SecondaryColor));
        public static Color SurfaceColor => GetColor(nameof(ThemeBase.SurfaceColor));
        public static Color DefaultTextColor => GetColor(nameof(ThemeBase.DefaultTextColor));
        public static Color ErrorColor => GetColor(nameof(ThemeBase.ErrorColor));

        //~~ Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~ Button Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Style ButtonContainedStyle => GetStyle(nameof(ThemeBase.ButtonContainedStyle));
        public static Style ButtonOutlinedStyle => GetStyle(nameof(ThemeBase.ButtonOutlinedStyle));
        public static Style ButtonTextStyle => GetStyle(nameof(ThemeBase.ButtonTextStyle));

        //~~~~ Label Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //public static Style LabelFieldHelperTextStyle => GetStyle(nameof(ThemeBase.LabelFieldHelperTextStyle));

        public static Style LabelH5Style => GetStyle(nameof(ThemeBase.LabelH5Style));
        public static Style LabelH6Style => GetStyle(nameof(ThemeBase.LabelH6Style));
        public static Style LabelSubtitle1Style => GetStyle(nameof(ThemeBase.LabelSubtitle1Style));
        public static Style LabelSubtitle2Style => GetStyle(nameof(ThemeBase.LabelSubtitle2Style));
        public static Style LabelBody1Style => GetStyle(nameof(ThemeBase.LabelBody1Style));
        public static Style LabelBody2Style => GetStyle(nameof(ThemeBase.LabelBody2Style));
        public static Style LabelCaptionStyle => GetStyle(nameof(ThemeBase.LabelCaptionStyle));
        public static Style LabelOverlineStyle => GetStyle(nameof(ThemeBase.LabelOverlineStyle));

        //~~~~ Other Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static Style FrameCardStyle => GetStyle(nameof(ThemeBase.FrameCardStyle));

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
                    var message = string.Format(LogMessages.ResourceTypeMismatch, _key, typeof(T).ToString());
                    LogHelper.LogWarning(message, typeof(ResourceHelper));
                }
            }
            else
            {
                var message = string.Format(LogMessages.ResourceNotFound, _key);
                LogHelper.LogWarning(message, typeof(ResourceHelper));
            }

            return resource;
		}

        private static Style GetStyle(string _key) => GetResourceOrDefault<Style>(_key);

        public static bool IsDarkTheme() => CurrentAppTheme == AppTheme.Dark;
        public static bool IsLightTheme() => CurrentAppTheme == AppTheme.Light;

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

            Messenger.Default.Send(new ThemeChangedMessage(CurrentAppTheme));
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

            Messenger.Default.Send(new ThemeChangedMessage(CurrentAppTheme));
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
                ThemeChangeRequested(AppTheme.Dark);
			}
            else
			{
                ThemeChangeRequested(AppTheme.Light);
			}
		}
    }
}
