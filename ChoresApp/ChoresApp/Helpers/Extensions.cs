using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoresApp.Helpers
{
	public static class Extensions
	{

		// String Extensions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static bool IsNullOrEmpty(this string _value)
		{
			return string.IsNullOrEmpty(_value);
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> _source)
		{
			return _source == null || _source.Count() == 0;
		}

		public static bool HasItems<T>(this IEnumerable<T> _source)
		{
			return _source != null && _source.Count() > 0;
		}
	}
}
