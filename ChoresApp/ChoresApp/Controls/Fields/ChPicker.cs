using ChoresApp.Controls.Buttons;
using ChoresApp.Helpers;
using ChoresApp.Pages.Popups;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChPicker : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		private Picker nativePicker;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPicker() : base()
		{
			TrailingIconSource = ImageHelper.PickerArrow;

			// test

			NativePicker.ItemsSource = new List<string> { "Rawr", "Grr", "Mrowr" };
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Picker NativePicker
		{
			get
			{
				if (nativePicker != null) return nativePicker;

				nativePicker = new Picker
				{

				};

				//nativePicker.Focused += NativePicker_Focused;
				//nativePicker.Unfocused += NativePicker_Unfocused;

				return nativePicker;
			}
		}

		private ChButton rawr;

		private ChButton Rawr
		{
			get
			{
				if (rawr != null) return rawr;

				rawr = new ChButton
				{
					Style = ResourceHelper.ButtonEmptyStyle,
				};
				rawr.Focused += NativePicker_Focused;
				rawr.Unfocused += NativePicker_Unfocused;
				rawr.Clicked += Rawr_Clicked;

				return rawr;
			}
		}

		private void Rawr_Clicked(object sender, EventArgs e)
		{
			OpenPopup();
		}

		protected override View NativeControl => Rawr;
		protected override bool ShowBigTitleLabel => false;
		protected override bool ShowValueLabel => true;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativePicker_Focused(object sender, FocusEventArgs e)
		{
			NativeControlFocused();
		}

		private void NativePicker_Unfocused(object sender, FocusEventArgs e)
		{
			NativeControlUnfocused();
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			NativePicker.Focus();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		private void OpenPopup()
		{
			var popupVM = new ChPickerPopupVM
			{
				//TitleTransKey = TitleTransKeyEnum,
			};

			NavigationHelper.PushPopup(new ChPickerPopup(popupVM));
		}
	}
}
