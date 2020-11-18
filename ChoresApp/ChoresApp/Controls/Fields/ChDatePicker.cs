using ChoresApp.Helpers;
using ChoresApp.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChDatePicker : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Label dateLabel;
		private DatePicker nativeDatePicker;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public ChDatePicker() : base()
		{
			TrailingIcon.IconSource = ImageHelper.Calendar;
		}

		private Grid rawr;

		private Grid Rawr
		{
			get
			{
				if (rawr != null) return rawr;

				rawr = new Grid();
				rawr.Children.Add(NativeDatePicker, 0, 0);
				rawr.Children.Add(DateLabel, 0, 0);

				return rawr;
			}
		}


		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Label DateLabel
		{
			get
			{
				if (dateLabel != null) return dateLabel;

				dateLabel = new Label
				{
					BindingContext = this,
					FontSize = 20,
					InputTransparent = true,
				};
				dateLabel.SetBinding(Label.TextProperty, nameof(Date),
					converter: InlineConverter<DateTime, string>.Select((_date) =>
					{
						return _date.ToString("yyyy/MM/dd");
					}
				));

				return dateLabel;
			}
		}

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

		private void NativeDatePicker_Unfocused(object sender, FocusEventArgs e)
		{
			OnUnFocused();
		}

		private void NativeDatePicker_Focused(object sender, FocusEventArgs e)
		{
			OnFocused();
		}

		//protected override View NativeControl => NativeDatePicker;
		protected override View NativeControl => Rawr;
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
			defaultValue: null
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	}
}
