using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChoresApp.Helpers
{
	public static class Extensions
	{
		// Enum Extensions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static string ToUpper(this Enum _source)
		{
			return _source.ToString().ToUpper();
		}

		// String Extensions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static bool IsNullOrEmpty(this string _value)
		{
			return string.IsNullOrEmpty(_value);
		}

		// IEnumerable Extensions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		
		public static IEnumerable<T> Except<T>(this IEnumerable<T> _source, T _exception)
		{
			//if (_source == null) return _source;

			//if (_exception == null) return _source;

			return _source.Except(new List<T> { _exception });
		}

		public static void ForEach<T>(this IEnumerable<T> _source, Action<T> _action)
		{
			if (_source == null || _action == null) return;

			foreach (var item in _source)
			{
				_action.Invoke(item);
			}
		}

		public static bool HasItems<T>(this IEnumerable<T> _source)
		{
			return _source != null && _source.Count() > 0;
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> _source)
		{
			return _source == null || _source.Count() == 0;
		}
	}
}
