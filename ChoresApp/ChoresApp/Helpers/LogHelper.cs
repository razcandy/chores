using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Helpers
{
	public class LogHelper
	{
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static string BrokenTranslation = "Translation with key '{0}' could not be found";

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static void Log(string _log, string _object)
		{

		}

        public static void LogError(string _log, string _object, LogErrorSeverity _severity = LogErrorSeverity.Low)
		{

		}
    }

    public enum LogErrorSeverity
	{
		Low,
		Medium,
		High,
		Fatal,
	}
}
