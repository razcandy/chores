using ChoresApp.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChoresApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Resources = ResourceHelper.CurrentTheme;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
