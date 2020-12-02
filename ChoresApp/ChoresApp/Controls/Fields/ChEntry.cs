using ChoresApp.Controls.Natives;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChEntry : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private XEntry nativeEntry;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChEntry() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected XEntry NativeEntry
		{
			get
			{
				if (nativeEntry != null) return nativeEntry;

				nativeEntry = new XEntry
				{
					BindingContext = this,
					BackgroundColor = Color.Transparent,
					Padding = 0,
				};
				nativeEntry.SetBinding(Entry.TextProperty, nameof(Text), BindingMode.TwoWay);

				nativeEntry.Focused += NativeEntry_Focused;
				nativeEntry.Unfocused += NativeEntry_Unfocused;

				return nativeEntry;
			}
		}

		protected override View NativeControl => NativeEntry;

		public Keyboard Keyboard
		{
			get => NativeEntry.Keyboard;
			set => NativeEntry.Keyboard = value;
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
			propertyChanged: OnTextPropertyChanged,
			defaultBindingMode: BindingMode.TwoWay
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeEntry_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
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

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			if (!NativeEntry.IsFocused)
			{
				NativeEntry.Focus();
			}
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init() { }

		protected override void Cleanup()
		{
			base.Cleanup();

			NativeEntry.Focused -= NativeEntry_Focused;
			NativeEntry.Unfocused -= NativeEntry_Unfocused;
		}
	}
}
