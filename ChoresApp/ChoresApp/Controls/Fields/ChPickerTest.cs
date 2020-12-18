using ChoresApp.Controls.Buttons;
using ChoresApp.Helpers;
using ChoresApp.Pages.Popups;
using ChoresApp.Pages.Popups.Selection;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public abstract class ChPickerTest<T> : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChButton pickerButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPickerTest() : base()
		{
			TrailingIconSource = ImageHelper.PickerArrow;

			var rawr = new Picker();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChButton PickerButton
		{
			get
			{
				if (pickerButton != null) return pickerButton;

				pickerButton = new ChButton
				{
					Style = ResourceHelper.ButtonEmptyStyle,
				};
				pickerButton.Focused += PickerButton_Focused;
				pickerButton.Unfocused += PickerButton_Unfocused;
				pickerButton.Clicked += PickerButton_Clicked;

				return pickerButton;
			}
		}

		protected override View NativeControl => PickerButton;
		protected override bool ShowBigTitleLabel => false;
		protected override bool ShowValueLabel => true;

		public bool IsMultiSelect { get; set; }
		public IList<T> ItemsSource { get; set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void PickerButton_Clicked(object sender, EventArgs e)
		{
			OpenPopup();
		}

		private void PickerButton_Focused(object sender, FocusEventArgs e)
		{
			NativeControlFocused();
		}

		private void PickerButton_Unfocused(object sender, FocusEventArgs e)
		{
			NativeControlUnfocused();
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			OpenPopup();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void OpenPopup()
		{
			var popupVM = new ChSelectPopupVM
			{
				TitleTransKey = TitleTransKey,
				IsMultiselect = IsMultiSelect,
				SelectionConfirmedAction = ParseSelection,
			};

			NavigationHelper.PushPopup(new ChSelectPopup(popupVM));
		}

		private void ParseSelection(IEnumerable<ChSelectViewCellVM> _selected)
		{
			if (_selected.IsNullOrEmpty())
			{
				ValueString = string.Empty;
			}
			else
			{
				//_selected.ForEach()
			}
		}

		protected override void Cleanup()
		{
			base.Cleanup();

			pickerButton.Focused -= PickerButton_Focused;
			pickerButton.Unfocused -= PickerButton_Unfocused;
			pickerButton.Clicked -= PickerButton_Clicked;
		}

		protected abstract Func<T, string> GetTitleForItems { get; set; }
	}
}
