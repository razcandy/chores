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
		public ChEntry() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Entry NativeEntry
		{
			get
			{
				if (nativeEntry != null) return nativeEntry;

				nativeEntry = new Entry
				{
					BindingContext = this,
					BackgroundColor = Color.Transparent,
				};
				nativeEntry.SetBinding(Entry.TextProperty, nameof(Text), BindingMode.TwoWay);

				nativeEntry.Focused += NativeEntry_Focused;
				nativeEntry.Unfocused += NativeEntry_Unfocused;
				nativeEntry.TextChanged += NativeEntry_TextChanged;

				return nativeEntry;
			}
		}

		protected override View NativeControl => NativeEntry;

		public bool IsPassword
		{
			get => NativeEntry.IsPassword;
			set => NativeEntry.IsPassword = value;
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public static readonly BindableProperty TextProperty = BindableProperty.Create
		(
			propertyName: nameof(Text),
			returnType: typeof(string),
			declaringType: typeof(ChEntry),
			defaultValue: null,
			propertyChanged: OnTextPropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeEntry_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		private void NativeEntry_TextChanged(object sender, TextChangedEventArgs e)
		{
			//ValueString = NativeEntry.Text;
		}

		private void NativeEntry_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var e = (ChEntry)bindable;
			e.ValueString = e.Text;
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init() { }
	}
}
