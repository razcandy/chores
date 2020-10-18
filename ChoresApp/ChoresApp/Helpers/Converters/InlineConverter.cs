using System;
using System.Globalization;
using Xamarin.Forms;

namespace PGApollo.Helpers.Converters
{
	/// <typeparam name="T">The Output, the type of the property being bound to</typeparam>
	public class InlineConverter<T> : IValueConverter
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Func<T, T> ConvertForwards { get; set; }
		private Func<T, T> ConvertBackwards { get; set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (ConvertForwards == null) throw new NotImplementedException();
			return ConvertForwards((T)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (ConvertBackwards == null) throw new NotImplementedException();
			return ConvertBackwards((T)value);
		}

		public static InlineConverter<T> Select(Func<T,T> convert, Func<T,T> convertBack = null)
		{
			InlineConverter<T> lamda = new InlineConverter<T>()
			{
				ConvertForwards = convert,
				ConvertBackwards = convertBack
			};
			return lamda;
		}
	}

	/// <summary>
	/// For quick inline conversions without having to make a whole class
	/// </summary>
	/// <typeparam name="T">The Input, the variable bound</typeparam>
	/// <typeparam name="V">The Output, the type of the property being bound to</typeparam>
	public partial class InlineConverter<T,V>  : IValueConverter
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Func<T, V> ConvertForwards { get; set; }
		private Func<V, T> ConvertBackwards { get; set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (ConvertForwards == null) throw new NotImplementedException();
			return ConvertForwards((T)value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (ConvertBackwards == null) throw new NotImplementedException();
			return ConvertBackwards((V)value);
		}

		public static InlineConverter<T, V> Select(Func<T,V> convert, Func<V,T> convertBack = null)
		{
			InlineConverter<T, V> lamda = new InlineConverter<T, V>()
			{
				ConvertForwards = convert,
				ConvertBackwards = convertBack
			};
			return lamda;
		}
	}
}
