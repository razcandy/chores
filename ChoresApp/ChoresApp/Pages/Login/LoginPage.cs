using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Fields;
using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Login
{
	public class LoginPage : ChPageBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private ScrollView mainScroll;
		private ChButton switchButton;
		private ChEntry usernameEntry;
		private ChPasswordEntry passwordEntry;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LoginPage() : base()
		{
			BindingContext = new LoginPageVM();
			Content = MainGrid;
		}

		public LoginPage(bool _inLoginMode) : base()
		{
			BindingContext = new LoginPageVM(_inLoginMode);
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
					RowSpacing = 0,
					RowDefinitions =
					{
						UIHelper.MakeStaticRow(30), // info
						UIHelper.MakeStarRow(),
						UIHelper.MakeStaticRow(50), // switch button
					},
				};
				mainGrid.Children.Add(BackButton, 0, 0);
				//mainGrid.Children.Add(TitleLabel, 0, 0);
				mainGrid.Children.Add(MainScroll, 0, 1);
				mainGrid.Children.Add(SwitchButton, 0, 2);

				return mainGrid;
			}
		}

		private ScrollView MainScroll
		{
			get
			{
				if (mainScroll != null) return mainScroll;

				mainScroll = new ScrollView
				{
					Orientation = ScrollOrientation.Vertical,
					Content = new StackLayout
					{
						Orientation = StackOrientation.Vertical,
						Children =
						{
							UsernameEntry,
							PasswordEntry,
							PrimaryActionButton,
						},
					},
				};

				return mainScroll;
			}
		}

		private ChImageButton backButton;
		private ChImageButton BackButton
		{
			get
			{
				if (backButton != null) return backButton;

				backButton = new ChImageButton
				{
					HeightRequest = 30,
					IconSource = ImageHelper.Back,
					HorizontalOptions = LayoutOptions.Start,
					IsSelectable = true,
				};

				return backButton;
			}
		}

		private XLabel titleLabel;
		private XLabel TitleLabel
		{
			get
			{
				if (titleLabel != null) return titleLabel;

				titleLabel = new XLabel
				{
					Style = ResourceHelper.LabelH5Style,
				};
				titleLabel.SetBinding(XLabel.TextProperty, nameof(LoginPageVM.PageTitle));

				return titleLabel;
			}
		}

		private ChButton SwitchButton
		{
			get
			{
				if (switchButton != null) return switchButton;

				switchButton = new ChButton
				{
					Style = ResourceHelper.ButtonTextStyle,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				};
				switchButton.SetBinding(ChButton.CommandProperty, nameof(LoginPageVM.SwitchCommand));
				switchButton.SetBinding(ChButton.TextProperty, nameof(LoginPageVM.SwitchButtonText));

				return switchButton;
			}
		}

		private XLabel switchLabel;
		private XLabel SwitchLabel
		{
			get
			{
				if (switchLabel != null) return switchLabel;

				switchLabel = new XLabel
				{
				};
				switchLabel.SetBinding(XLabel.TextProperty, nameof(LoginPageVM.SwitchLabelText));

				return switchLabel;
			}
		}

		private ChButton primaryActionButton;
		private ChButton PrimaryActionButton
		{
			get
			{
				if (primaryActionButton != null) return primaryActionButton;

				primaryActionButton = new ChButton
				{
					Style =	ResourceHelper.ButtonContainedStyle,
				};
				//primaryActionButton.SetBinding(ChTextButton.TextProperty, nameof(LoginPageVM.PrimaryActionButtonText));

				primaryActionButton.SetBinding(ChButton.TranslationKeyProperty, nameof(LoginPageVM.PrimaryActionTransKey));

				return primaryActionButton;
			}
		}
		
		private ChEntry UsernameEntry
		{
			get
			{
				if (usernameEntry != null) return usernameEntry;

				usernameEntry = new ChEntry
				{
					Title = "username",
				};
				usernameEntry.SetBinding(ChEntry.TextProperty, nameof(LoginPageVM.Username));
				usernameEntry.SetBinding(ChEntry.IsErroredProperty, nameof(LoginPageVM.IsUsernameErrored));

				return usernameEntry;
			}
		}

		private ChPasswordEntry PasswordEntry
		{
			get
			{
				if (passwordEntry != null) return passwordEntry;

				passwordEntry = new ChPasswordEntry
				{
					Title = "password",
				};
				passwordEntry.SetBinding(ChPasswordEntry.TextProperty, nameof(LoginPageVM.Password));
				passwordEntry.SetBinding(ChPasswordEntry.IsErroredProperty, nameof(LoginPageVM.IsPasswordErrored));
				passwordEntry.SetBinding(ChPasswordEntry.HelperTextProperty, nameof(LoginPageVM.PasswordHelperText));

				return passwordEntry;
			}
		}

		private XLabel disclaimerLabel;
		private XLabel DisclaimerLabel
		{
			get
			{
				if (disclaimerLabel != null) return disclaimerLabel;

				disclaimerLabel = new XLabel
				{
					Text = "Information given is only stored locally",
					Style = ResourceHelper.LabelCaptionStyle,
				};

				return disclaimerLabel;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
