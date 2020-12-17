using ChoresApp.Helpers;
using ChoresApp.Helpers.Converters;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChTimePicker : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private TimePicker nativeTimePicker;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChTimePicker() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private TimePicker NativeTimePicker
		{
			get
			{
				if (nativeTimePicker != null) return nativeTimePicker;

				nativeTimePicker = new TimePicker
				{
					BindingContext = this,
					Opacity = 0,
				};
				nativeTimePicker.SetBinding(TimePicker.TimeProperty, nameof(Time), BindingMode.TwoWay);
				nativeTimePicker.Focused += NativeTimePicker_Focused;
				nativeTimePicker.Unfocused += NativeTimePicker_Unfocused;

				return nativeTimePicker;
			}
		}

		protected override bool ShowBigTitleLabel => false;
		protected override bool ShowValueLabel => true;
		protected override View NativeControl => NativeTimePicker;

		public TimeSpan Time
		{
			get => (TimeSpan)GetValue(TimeProperty);
			set => SetValue(TimeProperty, value);
		}

		public static readonly BindableProperty TimeProperty = BindableProperty.Create
		(
			propertyName: nameof(Time),
			returnType: typeof(TimeSpan),
			declaringType: typeof(ChTimePicker),
			defaultValue: DateTime.Now.TimeOfDay,
			propertyChanged: OnTimePropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeTimePicker_Focused(object sender, FocusEventArgs e)
		{
			NativeControlFocused();
		}

		private void NativeTimePicker_Unfocused(object sender, FocusEventArgs e)
		{
			NativeControlUnfocused();
		}

		private static void OnTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tp = (ChTimePicker)bindable;
			tp.ValueString = tp.Time.ToString(ResourceHelper.DefaultTimeSpanFormat);
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			NativeTimePicker.Focus();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			TrailingIconSource = ImageHelper.Clock;
			ValueString = Time.ToString(ResourceHelper.DefaultTimeSpanFormat);
		}

		protected override void Cleanup()
		{
			base.Cleanup();

			NativeTimePicker.Focused -= NativeTimePicker_Focused;
			NativeTimePicker.Unfocused -= NativeTimePicker_Unfocused;
		}
	}
}
