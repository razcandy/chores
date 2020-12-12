using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Fields;
using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using ChoresApp.Helpers.Converters;
using ChoresApp.Pages;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Modules.Login
{
	public class LoginPage : ChPageBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private ScrollView mainScroll;
		private ChEntry nameEntry;
		private ChButton switchButton;
		private XLabel switchLabel;
		private XLabel titleLabel;
		private ChButton primaryActionButton;
		private ChEntry usernameEntry;
		private ChPasswordEntry passwordEntry;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LoginPage() : base()
		{
			BindingContext = new LoginPageVM();
			Init();
		}

		public LoginPage(bool _inLoginMode) : base()
		{
			BindingContext = new LoginPageVM(_inLoginMode);
			Init();
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
					ColumnSpacing = 0,
					RowDefinitions =
					{
						UIHelper.MakeStarRow(),
						UIHelper.MakeStaticRow(50), // switch button
					},
					ColumnDefinitions =
					{
						UIHelper.MakeStarColumn(2),
						UIHelper.MakeStarColumn(1),
					},
				};
				mainGrid.Children.Add(MainScroll, 0, 2, 0, 1);
				mainGrid.Children.Add(BackButton, 0, 1, 0, 1);
				mainGrid.Children.Add(SwitchLabel, 0, 1, 1, 2);
				mainGrid.Children.Add(SwitchButton, 1, 2, 1, 2);

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
							TitleLabel,
							NameEntry,
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
					HeightRequest = ResourceHelper.DefaultIconSize,
					WidthRequest = ResourceHelper.DefaultIconSize,
					IconSource = ImageHelper.Back,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start,
					IsSelectable = true,
				};

				backButton.Clicked += delegate
				{
					NavigationHelper.TryPopPage(this);
				};

				return backButton;
			}
		}

		private ChEntry NameEntry
		{
			get
			{
				if (nameEntry != null) return nameEntry;

				nameEntry = new ChEntry
				{
					TitleTransKey = TitleTransKeyEnum.Name,
				};
				nameEntry.SetBinding(ChEntry.TextProperty, nameof(LoginPageVM.Name));
				nameEntry.SetBinding(ChEntry.IsErroredProperty, nameof(LoginPageVM.IsNameErrored));
				nameEntry.SetBinding(IsVisibleProperty, nameof(LoginPageVM.IsLoginMode),
					converter: new InverseBoolConverter());

				return nameEntry;
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
				switchButton.SetBinding(ChButton.TranslationKeyProperty, nameof(LoginPageVM.SwitchButtonTransKey));

				return switchButton;
			}
		}

		private XLabel SwitchLabel
		{
			get
			{
				if (switchLabel != null) return switchLabel;

				switchLabel = new XLabel
				{
					Style = ResourceHelper.LabelBody2Style,
					HorizontalTextAlignment = TextAlignment.End,
					VerticalTextAlignment = TextAlignment.Center,
				};
				switchLabel.SetBinding(XLabel.TranslationKeyProperty, nameof(LoginPageVM.SwitchLabelTransKey));

				return switchLabel;
			}
		}

		private XLabel TitleLabel
		{
			get
			{
				if (titleLabel != null) return titleLabel;

				titleLabel = new XLabel
				{
					Style = ResourceHelper.LabelH5Style,
					HorizontalOptions = LayoutOptions.Center,
				};
				titleLabel.SetBinding(XLabel.TranslationKeyProperty, nameof(LoginPageVM.PageTitleTransKey));

				return titleLabel;
			}
		}

		private ChButton PrimaryActionButton
		{
			get
			{
				if (primaryActionButton != null) return primaryActionButton;

				primaryActionButton = new ChButton
				{
					Style =	ResourceHelper.ButtonContainedStyle,
					IsEnabled = false,
				};
				primaryActionButton.SetBinding(ChButton.TranslationKeyProperty, nameof(LoginPageVM.PrimaryActionTransKey));
				primaryActionButton.SetBinding(ChButton.IsEnabledProperty, nameof(LoginPageVM.IsPrimaryActionEnabled));
				primaryActionButton.SetBinding(ChButton.CommandProperty, nameof(LoginPageVM.PrimaryActionCommand));

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
					TitleTransKey = TitleTransKeyEnum.Username,
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
					TitleTransKey = TitleTransKeyEnum.Password,
				};
				passwordEntry.SetBinding(ChPasswordEntry.TextProperty, nameof(LoginPageVM.Password));
				passwordEntry.SetBinding(ChPasswordEntry.IsErroredProperty, nameof(LoginPageVM.IsPasswordErrored));
				passwordEntry.SetBinding(ChPasswordEntry.HelperTextProperty, nameof(LoginPageVM.PasswordHelperText));

				return passwordEntry;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			if (Device.Idiom == TargetIdiom.Desktop)
			{
				MainScroll.WidthRequest = ResourceHelper.DesktopFieldWidth;
				MainScroll.HorizontalOptions = LayoutOptions.Center;
			}

			Content = MainGrid; // last
		}
	}
}
