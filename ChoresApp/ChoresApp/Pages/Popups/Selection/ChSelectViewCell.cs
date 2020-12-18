using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectViewCell : ViewCell
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private CheckBox checkBox;
		private XLabel titleLabel;
		private RadioButton radioButton;
		private bool isForMultiselect;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectViewCell() : base()
		{
			View = MainGrid;
		}

		public ChSelectViewCell(bool _isForMultiselect = false) : base()
		{
			isForMultiselect = _isForMultiselect;
			View = MainGrid;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid MainGrid
		{
			get
			{
				if (mainGrid != null) return mainGrid;

				mainGrid = new Grid
				{
					HeightRequest = 50,
					ColumnDefinitions =
					{
						UIHelper.MakeStaticColomn(50),
						UIHelper.MakeStarColumn(),
					},
				};

				if (isForMultiselect)
				{
					mainGrid.Children.Add(CheckBox, 0, 0);
				}
				else
				{
					mainGrid.Children.Add(RadioButton, 0, 0);
				}

				mainGrid.Children.Add(TitleLabel, 1, 0);

				return mainGrid;
			}
		}

		private CheckBox CheckBox
		{
			get
			{
				if (checkBox != null) return checkBox;

				checkBox = new CheckBox
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				};
				checkBox.SetBinding(CheckBox.IsCheckedProperty, nameof(ChSelectViewCellVM.IsSelected));

				return checkBox;
			}
		}

		private XLabel TitleLabel
		{
			get
			{
				if (titleLabel != null) return titleLabel;

				titleLabel = new XLabel
				{
					Style = ResourceHelper.LabelSubtitle1Style,
				};
				titleLabel.SetBinding(XLabel.TextProperty, nameof(ChSelectViewCellVM.Title));

				return titleLabel;
			}
		}

		private RadioButton RadioButton
		{
			get
			{
				if (radioButton != null) return radioButton;

				radioButton = new RadioButton
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				};
				radioButton.SetBinding(RadioButton.IsCheckedProperty, nameof(ChSelectViewCellVM.IsSelected));

				return radioButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void OnTapped()
		{
			base.OnTapped();

			if (BindingContext is ChSelectViewCellVM vm)
			{
				vm.OnTapped();
			}
		}
	}
}
