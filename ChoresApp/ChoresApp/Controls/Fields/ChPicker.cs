using ChoresApp.Helpers;
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

		protected override View NativeControl => NativePicker;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativePicker_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		private void NativePicker_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			NativePicker.Focus();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	}
}
