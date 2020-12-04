using ChoresApp.Helpers;
using ChoresApp.Pages;
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

			TranslationHelper.InitTest();

			CheckFiles();

			//var mainPage = new MainPage();
			//MainPage = mainPage;

			var mainPage = new MainPage();
			MainPage = new NavigationPage(mainPage);

			NavigationHelper.InitStacks(mainPage);

			// Events
			//Current.RequestedThemeChanged += OnRequestedThemeChanged;

			LogHelper.LogInfo("App Launched", typeof(App).ToString());
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
		private void CheckFiles()
		{
			//FileHelper.TryCreateFile(FileHelper.LogFilename);
		}

		protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
