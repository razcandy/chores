using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChEntry : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Entry nativeEntry;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChEntry() : base()
		{

		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Entry NativeEntry
		{
			get
			{
				if (nativeEntry != null) return nativeEntry;

				nativeEntry = new Entry
				{
					BackgroundColor = Color.Transparent,
				};
				nativeEntry.Focused += NativeEntry_Focused;
				nativeEntry.Unfocused += NativeEntry_Unfocused;
				nativeEntry.TextChanged += NativeEntry_TextChanged;

				//nativeEntry.SetBinding(Entry.TextProperty, nameof(ChEntry.Value), BindingMode.TwoWay);

				return nativeEntry;
			}
		}

		private void NativeEntry_TextChanged(object sender, TextChangedEventArgs e)
		{
			//Value = NativeEntry.Text;
		}

		protected override View NativeControl => NativeEntry;

		public bool IsPassword
		{
			get => NativeEntry.IsPassword;
			set => NativeEntry.IsPassword = value;
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeEntry_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		private void NativeEntry_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	}
}
