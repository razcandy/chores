using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups
{
	public class ChPopupAlert : ChPopupFloating
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private XLabel messageLabel;
		private Action primaryAction;
		private ChButton primaryButton;
		private Action secondaryAction;
		private ChButton secondaryButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupAlert() : base() => Init();

		public ChPopupAlert(ChPopupAlertConfig _config) : base()
		{
			if (_config == null) return;

			MessageLabel.Text = _config.Message;
			PrimaryButton.TranslationKey = _config.PrimaryButtonTransKey;
			SecondaryButton.TranslationKey = _config.SecondaryButtonTransKey;
			primaryAction = _config.PrimaryAction;
			secondaryAction = _config.SecondaryAction;

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
						UIHelper.MakeStaticRow(40),
						UIHelper.MakeStaticRow(ResourceHelper.DefaultButtonHeight),
					},
					ColumnDefinitions =
					{
						UIHelper.MakeStarColumn(2),
						UIHelper.MakeStarColumn(1),
					},
				};
				mainGrid.Children.Add(MessageLabel, 0, 2, 0, 1);
				mainGrid.Children.Add(SecondaryButton, 0, 1);
				mainGrid.Children.Add(PrimaryButton, 1, 1);

				return mainGrid;
			}
		}

		private XLabel MessageLabel
		{
			get
			{
				if (messageLabel != null) return messageLabel;

				messageLabel = new XLabel
				{
					Style = ResourceHelper.LabelBody2Style,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Opacity = 0.9,
					Padding = new Thickness(24-8, 0, 24-8, 0),
				};

				return messageLabel;
			}
		}

		private ChButton PrimaryButton
		{
			get
			{
				if (primaryButton != null) return primaryButton;

				primaryButton = new ChButton
				{
					Style = ResourceHelper.ButtonTextStyle,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				};
				primaryButton.Clicked += PrimaryButton_Clicked;

				return primaryButton;
			}
		}

		private ChButton SecondaryButton
		{
			get
			{
				if (secondaryButton != null) return secondaryButton;

				secondaryButton = new ChButton
				{
					Style = ResourceHelper.ButtonTextStyle,
					HorizontalOptions = LayoutOptions.End,
				};
				secondaryButton.Clicked += SecondaryButton_Clicked;

				return secondaryButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void PrimaryButton_Clicked(object sender, EventArgs e)
		{
			Pop();
			primaryAction?.Invoke();
		}

		private void SecondaryButton_Clicked(object sender, EventArgs e)
		{
			Pop();
			secondaryAction?.Invoke();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			Content = MainGrid;
		}
	}

	public class ChPopupAlertConfig
	{
		public string Message { get; set; }
		public Action PrimaryAction { get; set; }
		public ButtonTransKeyEnum PrimaryButtonTransKey { get; set; }
		public Action SecondaryAction { get; set; }
		public ButtonTransKeyEnum SecondaryButtonTransKey { get; set; }
	}
}
