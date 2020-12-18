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
	public class ChPopupFloating : ChPopupBase
	{
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private Frame mainFrame;
		private XLabel subtitleLabel;
		private XLabel titleLabel;

		protected static Thickness mainFramePadding = new Thickness(8, 0);

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupFloating() : base() => Init();

		public ChPopupFloating(ChPopupFloatingVM _vm) : base()
		{
			if (_vm == null) return;

			BindingContext = _vm;
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
				};

				int rowCount = 0, colCount = 0;

				// title
				mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(40)); 
				mainGrid.Children.Add(TitleLabel, 0, rowCount);
				rowCount++;

				if (ShowSubtitle)
				{
					mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(30)); 
					mainGrid.Children.Add(SubtitleLabel, 0, rowCount);
					rowCount++;
				}

				// main content
				mainGrid.RowDefinitions.Add(UIHelper.MakeStarRow());
				mainGrid.Children.Add(MainContentWrapper, 0, rowCount);
				rowCount++;

				if (UseDividers)
				{
					var top = UIHelper.MakeHorizontalDivider();
					top.VerticalOptions = LayoutOptions.Start;
					top.Margin = new Thickness(-mainFramePadding.HorizontalThickness, 0);

					var bottom = UIHelper.MakeHorizontalDivider();
					bottom.VerticalOptions = LayoutOptions.End;
					bottom.Margin = new Thickness(-mainFramePadding.HorizontalThickness, 0);

					mainGrid.Children.Add(top, 0, rowCount-1);
					mainGrid.Children.Add(bottom, 0, rowCount-1);
				}

				// footer
				mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(ResourceHelper.DefaultButtonHeight));
				mainGrid.Children.Add(Footer, 0, rowCount);
				rowCount++;

				return mainGrid;
			}
		}

		private Grid footerGrid;
		private Grid FooterGrid
		{
			get
			{
				if (footerGrid != null) return footerGrid;

				footerGrid = new Grid
				{
					ColumnSpacing = 0,
					ColumnDefinitions =
					{
						UIHelper.MakeStarColumn(2),
						UIHelper.MakeStarColumn(1),
					},
				};
				footerGrid.Children.Add(SecondaryButton, 0, 0);
				footerGrid.Children.Add(PrimaryButton, 1, 0);

				return footerGrid;
			}
		}

		private ChButton primaryButton;
		private ChButton PrimaryButton
		{
			get
			{
				if (primaryButton != null) return primaryButton;

				primaryButton = new ChButton
				{
					Style = ResourceHelper.ButtonTextStyle,
				};
				primaryButton.SetBinding(ChButton.CommandProperty, nameof(ChPopupFloatingVM.PrimaryButtonCommand));
				primaryButton.SetBinding(ChButton.TranslationKeyProperty, nameof(ChPopupFloatingVM.PrimaryButtonTransKey));
				primaryButton.Clicked += PrimaryButton_Clicked;

				return primaryButton;
			}
		}

		private ChButton secondaryButton;
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
				secondaryButton.SetBinding(ChButton.CommandProperty, nameof(ChPopupFloatingVM.SecondaryButtonCommand));
				secondaryButton.SetBinding(ChButton.TranslationKeyProperty, nameof(ChPopupFloatingVM.SecondaryButtonTransKey));
				secondaryButton.Clicked += SecondaryButton_Clicked;

				return secondaryButton;
			}
		}

		private XLabel SubtitleLabel
		{
			get
			{
				if (subtitleLabel != null) return subtitleLabel;

				subtitleLabel = new XLabel
				{
					Style = ResourceHelper.LabelSubtitle1Style,
				};
				subtitleLabel.SetBinding(XLabel.TranslationKeyProperty, nameof(ChPopupFloatingVM.SubtitleTransKey));

				return subtitleLabel;
			}
		}

		private XLabel TitleLabel
		{
			get
			{
				if (titleLabel != null) return titleLabel;

				titleLabel = new XLabel
				{
					Style = ResourceHelper.LabelH6Style,
					VerticalTextAlignment = TextAlignment.Center,
				};
				titleLabel.SetBinding(XLabel.TranslationKeyProperty, nameof(ChPopupFloatingVM.TitleTransKey));

				return titleLabel;
			}
		}

		protected Frame MainFrame
		{
			get
			{
				if (mainFrame != null) return mainFrame;

				mainFrame = new Frame
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Margin = 20,
					Padding = mainFramePadding,
					Content = MainGrid,
				};

				return mainFrame;
			}
		}

		protected new View Content
		{
			get => MainContentWrapper.Content;
			set => MainContentWrapper.Content = value;
		}

		protected ContentView MainContentWrapper = new ContentView();

		protected virtual View Footer => FooterGrid;
		protected virtual bool ShowSubtitle => false;
		protected virtual bool UseDividers => false;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void PrimaryButton_Clicked(object sender, EventArgs e)
		{
			Pop();
		}

		private void SecondaryButton_Clicked(object sender, EventArgs e)
		{
			Pop();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			base.Content = MainFrame;
		}
	}
}
