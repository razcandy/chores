using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Helpers
{
	public static class LogMessages
	{
		public static string BrokenTranslation
			=> "Translation with key '{0}' could not be found";

		public static string ResourceNotFound
			=> "Resource value with key '{0}' not found";

		public static string ResourceTypeMismatch
			=> "Resource '{0}' is not of type '{1}'";
	}
}
