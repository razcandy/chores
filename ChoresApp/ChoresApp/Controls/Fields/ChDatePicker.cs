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
				//nativeDatePicker.SetBinding(DatePicker.DateProperty, nameof(Date), BindingMode.TwoWay);

				//nativeDatePicker.SetBinding(DatePicker.DateProperty, nameof(Date), BindingMode.TwoWay,
				//	converter: InlineConverter<DateTime?, DateTime>.Select((x) =>
				//	{
				//		if (x.HasValue)
				//		{
				//			return x.Value;
				//		}
				//		else
				//		{
				//			return null;
				//		}
				//	}));

				nativeDatePicker.Focused += NativeDatePicker_Focused;
				nativeDatePicker.Unfocused += NativeDatePicker_Unfocused;

				nativeDatePicker.DateSelected += NativeDatePicker_DateSelected;

				return nativeDatePicker;
			}
		}

		protected override bool ShowValueLabel => true;
		protected override View NativeControl => NativeDatePicker;

		public DateTime? Date
		{
			get => (DateTime?)GetValue(DateProperty);
			set => SetValue(DateProperty, value);
		}

		public static readonly BindableProperty DateProperty = BindableProperty.Create
		(
			propertyName: nameof(Date),
			returnType: typeof(DateTime?),
			declaringType: typeof(ChDatePicker),
			defaultValue: null,
			propertyChanged: OnDatePropertyChanged
		);

		private static void OnDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var dp = (ChDatePicker)bindable;

			if (dp.Date.HasValue)
			{
				dp.ValueString = dp.Date.Value.ToString(ResourceHelper.DefaultDateTimeFormat);
			}
			else
			{
				dp.ValueString = null;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeDatePicker_DateSelected(object sender, DateChangedEventArgs e)
		{
			if (e.OldDate == e.NewDate)
			{
				;
			}

			if (e.NewDate == DateTime.MinValue)
			{
				;
			}

			Date = e.NewDate;
		}

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

			//ValueLabel.SetBinding(Label.TextProperty, nameof(Date),
			//	converter: InlineConverter<DateTime, string>.Select((_date) =>
			//	{
			//		return _date.ToString(ResourceHelper.DefaultDateTimeFormat);
			//	}
			//));

			ValueLabel.SetBinding(Label.TextProperty, nameof(Date),
				converter: InlineConverter<DateTime?, string>.Select((_date) =>
				{
					if (!_date.HasValue) return null;

					return _date.Value.ToString(ResourceHelper.DefaultDateTimeFormat);
				}
			));
		}
	}
}
