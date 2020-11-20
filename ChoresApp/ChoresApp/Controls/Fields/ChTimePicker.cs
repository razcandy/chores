﻿using ChoresApp.Helpers;
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
			defaultValue: null,
			propertyChanged: OnTimePropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeTimePicker_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		private void NativeTimePicker_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		private static void OnTimePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tp = (ChTimePicker)bindable;
			tp.ValueString = tp.Time.ToString(ResourceHelper.DefaultTimeSpanFormat);
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			TrailingIconSource = ImageHelper.Clock;

			ValueLabel.SetBinding(Label.TextProperty, nameof(Time),
				converter: InlineConverter<TimeSpan, string>.Select((_time) =>
				{
					return _time.ToString(ResourceHelper.DefaultTimeSpanFormat);
				}
			));
		}
	}
}
