using ChoresApp.Data;
using ChoresApp.Data.Models;
using ChoresApp.Helpers;
using ChoresApp.Pages;
using ChoresApp.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;
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

			SessionModel = new SessionModel();

			FileHelper.AppStartup();

			StartAsync();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public SessionModel SessionModel { get; private set; }

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
		private async Task GetSetGlobalModel()
		{
			var dir = FileHelper.Directory + DatabaseKeys.Global;

			var res = await DatabaseHelper.GetNFor<GlobalModel>(1, dir);

			var globalModel = new GlobalModel();

			if (res.IsNullOrEmpty())
			{
				await DatabaseHelper.Upsert(globalModel, dir);
			}
			else
			{
				globalModel = res.First();
			}

			GlobalData.GlobalModel = globalModel;
		}

		private async void StartAsync()
		{
			await GetSetGlobalModel();

			LoginHelper.CreateDefaultUser();
			await LoginHelper.TryAutoLogIn();

			//var mainPage = new MainPage();
			//MainPage = mainPage;

			var mainPage = new MainPage();
			MainPage = new NavigationPage(mainPage);

			NavigationHelper.InitStacks(mainPage);

			// Events
			//Current.RequestedThemeChanged += OnRequestedThemeChanged;

			LogHelper.LogInfo("App Launched", typeof(App).ToString());
		}

		protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
