using ChoresApp.Resources;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace ChoresApp
{
    public partial class App : Xamarin.Forms.Application
	{
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public App()
        {
            InitializeComponent();

			ResourceHelper.LoadStartupTheme();

            Current.On<Windows>().SetImageDirectory("Assets");

            MainPage = new MainPage();

			// Events
			//Current.RequestedThemeChanged += OnRequestedThemeChanged;
        }

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		
		/// <summary>
		/// Yeah, so this never happens on UWP or Android
		/// to-do
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
		{
			ResourceHelper.ThemeChangeRequested(e.RequestedTheme);
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
