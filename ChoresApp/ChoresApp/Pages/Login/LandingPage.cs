using ChoresApp.Controls.Buttons;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Login
{
	public class LandingPage : ChContentPage
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private ChImageButton infoButton;
		private ChButton loginButton;
		private ChButton signupButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LandingPage() : base()
		{
			BindingContext = new LandingPageVM();
			Content = MainGrid;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid MainGrid
		{
			get
			{
				if (mainGrid != null) return mainGrid;

				mainGrid = new Grid
				{
					BackgroundColor = ResourceHelper.PrimaryColor,
					RowSpacing = 0,
					RowDefinitions =
					{
						UIHelper.MakeStaticRow(50), // info
						UIHelper.MakeStarRow(),
						UIHelper.MakeStaticRow(50), // log in button
						UIHelper.MakeStaticRow(50), // sign up button
						UIHelper.MakeStaticRow(50), // spacer
					},
				};
				mainGrid.Children.Add(InfoButton, 0, 0);

				mainGrid.Children.Add(LoginButton, 0, 2);
				mainGrid.Children.Add(SignupButton, 0, 3);

				return mainGrid;
			}
		}

		private ChImageButton InfoButton
		{
			get
			{
				if (infoButton != null) return infoButton;

				infoButton = new ChImageButton
				{
					HorizontalOptions = LayoutOptions.Start,
					IconSource = ImageHelper.Info,
				};
				infoButton.SetBinding(ChImageButton.CommandProperty, nameof(LandingPageVM.InfoCommand));

				return infoButton;
			}
		}

		private ChButton LoginButton
		{
			get
			{
				if (loginButton != null) return loginButton;

				loginButton = new ChButton(ButtonTransKeyEnum.LogIn)
				{
					Style = ResourceHelper.ButtonContainedStyle,
				};
				loginButton.SetBinding(ChButton.CommandProperty, nameof(LandingPageVM.LoginCommand));

				//loginButton.Clicked += delegate
				//{
				//	var page = new ChPageWrapper
				//	{
				//		Content = new LoginPage(true),
				//	};

				//	page.Nav();
				//};

				return loginButton;
			}
		}

		private ChButton SignupButton
		{
			get
			{
				if (signupButton != null) return loginButton;

				signupButton = new ChButton(ButtonTransKeyEnum.SignUp)
				{
					Style = ResourceHelper.ButtonOutlinedStyle,
				};
				signupButton.SetBinding(ChButton.CommandProperty, nameof(LandingPageVM.SignUpCommand));

				return signupButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
