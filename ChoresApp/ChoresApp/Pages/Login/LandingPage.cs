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
		private ChButtonBase infoButton;
		private ChTextButton loginButton;
		private ChTextButton signupButton;

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

		private ChButtonBase InfoButton
		{
			get
			{
				if (infoButton != null) return infoButton;

				infoButton = new ChButtonBase
				{
					Text = "X",
					HorizontalOptions = LayoutOptions.Start,
				};
				infoButton.SetBinding(ChButtonBase.CommandProperty, nameof(LandingPageVM.InfoCommand));

				return infoButton;
			}
		}

		private ChTextButton LoginButton
		{
			get
			{
				if (loginButton != null) return loginButton;

				loginButton = new ChTextButton(ButtonTransKeyEnum.LogIn)
				{
					Style = ResourceHelper.ButtonContainedStyle,
				};

				return loginButton;
			}
		}

		private ChTextButton SignupButton
		{
			get
			{
				if (signupButton != null) return loginButton;

				signupButton = new ChTextButton(ButtonTransKeyEnum.SignUp)
				{
					Style = ResourceHelper.ButtonOutlinedStyle,
				};

				return signupButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
