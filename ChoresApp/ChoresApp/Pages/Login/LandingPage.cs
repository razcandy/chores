using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Natives;
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
		private XLabel disclaimerLabel;
		private XLabel iconLabel;
		private ChImageButton infoButton;
		private ChButton loginButton;
		private ChButton signupButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LandingPage() : base()
		{
			if (Device.Idiom == TargetIdiom.Desktop)
			{
				LoginButton.WidthRequest = ResourceHelper.DesktopFieldWidth;
				SignupButton.WidthRequest = ResourceHelper.DesktopFieldWidth;
			}
			else
			{
				LoginButton.WidthRequest = ResourceHelper.DefaultButtonWidth;
				SignupButton.WidthRequest = ResourceHelper.DefaultButtonWidth;
			}

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
					//BackgroundColor = ResourceHelper.PrimaryColor,
					RowSpacing = 16,
					RowDefinitions =
					{
						UIHelper.MakeStaticRow(30), // info
						UIHelper.MakeStarRow(), // app graphic
						UIHelper.MakeStaticRow(ResourceHelper.DefaultButtonHeight), // log in button
						UIHelper.MakeStaticRow(ResourceHelper.DefaultButtonHeight), // sign up button
						UIHelper.MakeStaticRow(50), // 
					},
				};
				mainGrid.Children.Add(InfoButton, 0, 0);
				mainGrid.Children.Add(IconLabel, 0, 1);
				mainGrid.Children.Add(LoginButton, 0, 2);
				mainGrid.Children.Add(SignupButton, 0, 3);
				mainGrid.Children.Add(DisclaimerLabel, 0, 4);

				return mainGrid;
			}
		}

		private XLabel DisclaimerLabel
		{
			get
			{
				if (disclaimerLabel != null) return disclaimerLabel;

				disclaimerLabel = new XLabel
				{
					Text = "Any information provided is only stored locally",
					Style = ResourceHelper.LabelCaptionStyle,
					VerticalTextAlignment = TextAlignment.Center,
					HorizontalTextAlignment = TextAlignment.Center,
				};

				return disclaimerLabel;
			}
		}

		/// <summary>
		/// Placeholder for an actual icon
		/// </summary>
		private XLabel IconLabel
		{
			get
			{
				if (iconLabel != null) return iconLabel;

				iconLabel = new XLabel
				{
					Style = ResourceHelper.LabelH3Style,
					Text = "Chores App",
					VerticalTextAlignment = TextAlignment.Center,
					HorizontalTextAlignment = TextAlignment.Center,
				};

				return iconLabel;
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
					HorizontalOptions = LayoutOptions.Center,
				};
				loginButton.SetBinding(ChButton.CommandProperty, nameof(LandingPageVM.LoginCommand));

				return loginButton;
			}
		}

		private ChButton SignupButton
		{
			get
			{
				if (signupButton != null) return signupButton;

				signupButton = new ChButton(ButtonTransKeyEnum.SignUp)
				{
					Style = ResourceHelper.ButtonOutlinedStyle,
					HorizontalOptions = LayoutOptions.Center,
				};
				signupButton.SetBinding(ChButton.CommandProperty, nameof(LandingPageVM.SignUpCommand));

				return signupButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
