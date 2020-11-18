using ChoresApp.Controls.Buttons;
using ChoresApp.Data.Messaging;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using GalaSoft.MvvmLight.Messaging;
using System;
using Xamarin.Forms;

namespace ChoresApp.Controls.Navbar
{
	public class ChNavbar : ContentView
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private ChNavbarButton homeButton;
		private ChNavbarButton nav1;
		private ChNavbarButton nav2;
		private ChNavbarButton nav3;
		private ChNavbarButton debugButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChNavbar() : base()
		{
			BindingContext = new ChNavbarVM();
			BackgroundColor = ResourceHelper.BackgroundColor;
			Content = MainGrid;

			Messenger.Default.Register<ThemeChangedMessage>(this, OnThemeChanged);
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid MainGrid
		{
			get
			{
				if (mainGrid != null) return mainGrid;

				mainGrid = new Grid
				{
					HeightRequest = ResourceHelper.FooterHeight,
					ColumnSpacing = 0,
					ColumnDefinitions =
					{
						UIHelper.MakeStarColumn(), // home
						UIHelper.MakeStarColumn(),
						UIHelper.MakeStarColumn(),
						UIHelper.MakeStarColumn(),
					},
				};

				mainGrid.Children.Add(HomeButton, 0, 0);
				mainGrid.Children.Add(Nav1, 1, 0);
				mainGrid.Children.Add(Nav2, 2, 0);
				mainGrid.Children.Add(Nav3, 3, 0);

#if DEBUG
				mainGrid.ColumnDefinitions.Add(UIHelper.MakeStarColumn());
				mainGrid.Children.Add(DebugButton, 4, 0);
#endif

				return mainGrid;
			}
		}

		private ChNavbarButton HomeButton
		{
			get
			{
				if (homeButton != null) return homeButton;

				homeButton = new ChNavbarButton
				{
					IconSource = ImageHelper.Home,
					IsSelected = true,
				};
				homeButton.Clicked += Button_Clicked;
				homeButton.Button.SetBinding(ChButtonBase.CommandProperty, nameof(ChNavbarVM.HomeCommand));

				return homeButton;
			}
		}

		

		private ChNavbarButton Nav1
		{
			get
			{
				if (nav1 != null) return nav1;

				nav1 = new ChNavbarButton
				{
					IconSource = ImageHelper.NotFound,
				};
				nav1.Clicked += Button_Clicked;
				nav1.Button.SetBinding(ChButtonBase.CommandProperty, nameof(ChNavbarVM.Nav1Command));

				return nav1;
			}
		}

		private ChNavbarButton Nav2
		{
			get
			{
				if (nav2 != null) return nav2;

				nav2 = new ChNavbarButton
				{
					IconSource = ImageHelper.NotFound,
				};
				nav2.Clicked += Button_Clicked;
				nav2.Button.SetBinding(ChButtonBase.CommandProperty, nameof(ChNavbarVM.Nav2Command));

				return nav2;
			}
		}

		private ChNavbarButton Nav3
		{
			get
			{
				if (nav3 != null) return nav3;

				nav3 = new ChNavbarButton
				{
					IconSource = ImageHelper.NotFound,
				};
				nav3.Clicked += Button_Clicked;
				nav3.Button.SetBinding(ChButtonBase.CommandProperty, nameof(ChNavbarVM.Nav3Command));

				return nav3;
			}
		}

		private ChNavbarButton DebugButton
		{ 
			get
			{
				if (debugButton != null) return debugButton;

				debugButton = new ChNavbarButton
				{
					IconSource = ImageHelper.Debug,
				};
				debugButton.Clicked += Button_Clicked;
				debugButton.Button.SetBinding(ChButtonBase.CommandProperty, nameof(ChNavbarVM.DebugCommand));

				return debugButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Button_Clicked(object sender, EventArgs e)
		{
			var navButton = (ChNavbarButton)sender;

			if (navButton.IsSelected) return;

			if (navButton == HomeButton)
			{
				Nav1.IsSelected = false;
				Nav2.IsSelected = false;
				Nav3.IsSelected = false;
				HomeButton.IsSelected = true;
			}
			else if (navButton == Nav1)
			{
				HomeButton.IsSelected = false;
				Nav2.IsSelected = false;
				Nav3.IsSelected = false;
				Nav1.IsSelected = true;
			}
			else if (navButton == Nav2)
			{
				HomeButton.IsSelected = false;
				Nav1.IsSelected = false;
				Nav3.IsSelected = false;
				Nav2.IsSelected = true;
			}
			else if (navButton == Nav3)
			{
				HomeButton.IsSelected = false;
				Nav1.IsSelected = false;
				Nav2.IsSelected = false;
				Nav3.IsSelected = true;
			}

#if DEBUG
			if (navButton == DebugButton)
			{
				HomeButton.IsSelected = false;
				Nav1.IsSelected = false;
				Nav2.IsSelected = false;
				Nav3.IsSelected = false;
				DebugButton.IsSelected = true;
			}
			else
			{
				DebugButton.IsSelected = false;
			}
#endif
		}

		private void OnThemeChanged(ThemeChangedMessage _message)
		{
			if (_message == null) return;

			BackgroundColor = ResourceHelper.BackgroundColor;
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
