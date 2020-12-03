using ChoresApp.Helpers;
using ChoresApp.Helpers.Converters;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChDatePicker : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private DatePicker nativeDatePicker;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChDatePicker() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private DatePicker NativeDatePicker
		{
			get
			{
				if (nativeDatePicker != null) return nativeDatePicker;

				nativeDatePicker = new DatePicker
				{
					BindingContext = this,
					Opacity = 0,
				};
				nativeDatePicker.SetBinding(DatePicker.DateProperty, nameof(Date), BindingMode.TwoWay);
				nativeDatePicker.Focused += NativeDatePicker_Focused;
				nativeDatePicker.Unfocused += NativeDatePicker_Unfocused;

				return nativeDatePicker;
			}
		}

		protected override bool ShowBigTitleLabel => false;
		protected override bool ShowValueLabel => true;
		protected override View NativeControl => NativeDatePicker;

		public DateTime Date
		{
			get => (DateTime)GetValue(DateProperty);
			set => SetValue(DateProperty, value);
		}

		public static readonly BindableProperty DateProperty = BindableProperty.Create
		(
			propertyName: nameof(Date),
			returnType: typeof(DateTime),
			declaringType: typeof(ChDatePicker),
			defaultValue: DateTime.Now,
			propertyChanged: OnDatePropertyChanged
		);

		private static void OnDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var dp = (ChDatePicker)bindable;
			dp.ValueString = dp.Date.ToString(ResourceHelper.DefaultDateTimeFormat);
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeDatePicker_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		private void NativeDatePicker_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			NativeDatePicker.Focus();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			TrailingIconSource = ImageHelper.Calendar;
			ValueString = Date.ToString(ResourceHelper.DefaultDateTimeFormat);
		}

		protected override void Cleanup()
		{
			base.Cleanup();

			NativeDatePicker.Focused -= NativeDatePicker_Focused;
			NativeDatePicker.Unfocused -= NativeDatePicker_Unfocused;
		}
	}
}
