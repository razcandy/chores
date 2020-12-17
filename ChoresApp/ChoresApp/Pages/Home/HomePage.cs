using ChoresApp.Controls.Navbar;
using ChoresApp.Helpers;
using ChoresApp.Modules.Login;
using ChoresApp.Pages.Test;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Home
{
	public class HomePage : ContentPage
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid mainGrid;
        private ChNavbar navbar;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public HomePage() : base() => Init();

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid MainGrid
        {
            get
            {
                if (mainGrid != null) return mainGrid;

                mainGrid = new Grid
                {
                    RowSpacing = 0,
                    RowDefinitions =
                    {
                        UIHelper.MakeStarRow(),
                        UIHelper.MakeStaticRow(ResourceHelper.FooterHeight),
                    },
                };

                mainGrid.Children.Add(PageContent, 0, 0);
                mainGrid.Children.Add(Navbar, 0, 1);

                return mainGrid;
            }
        }

        public ContentView PageContent { get; } = new ContentView();

        private ChNavbar Navbar
        {
            get
            {
                if (navbar != null) return navbar;
                navbar = new ChNavbar();
                return navbar;
            }
        }

        public ChPageBase HomeContent { get; set; }
        public ChPageBase Nav1Content { get; set; }
        public ChPageBase Nav2Content { get; set; }
        public ChPageBase Nav3Content { get; set; }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void Init()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            HomeContent = new ChFieldsTestPage();
            Nav1Content = new LoginPage();
            Nav2Content = new LandingPage();
            Nav3Content = new TestPage();
            Content = MainGrid;
        }
    }
}
