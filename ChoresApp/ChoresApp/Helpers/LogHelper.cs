using System;
using System.Collections.Generic;

namespace ChoresApp.Helpers
{
	public static class LogHelper
	{
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private const string logFilenamePattern = "log_{0}.txt";

		/// <summary>
		/// 0 - DateTime
		/// 1 - Log Type
		/// 2 - Object
		/// 3 - Message
		/// </summary>
		private const string logPattern = "{0} | {1} | {2}" + newLine + "{3}" + newLine + separator;

		/// <summary>
		/// 0 - DateTime
		/// 1 - Log Type
		/// 2 - Object
		/// 3 - Additional text
		/// 4 - Message
		/// </summary>
		private const string logPatternLong = "{0} | {1} | {2} | {3}" + newLine + "{4}" + separator;
		
		private const string newLine = "\n";
		private const string objectNotProvided = "<not provided>";
		private const string separator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string logFileName = string.Format(logFilenamePattern, DateTime.Now.ToString("yyyyMMdd"));

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string FormatDateTime() => DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss");

		private static void Log(string _message, string _object, LogTypeEnum _logType, string _additional = null)
		{
			if (_message.IsNullOrEmpty()) return;

			if (_object.IsNullOrEmpty())
			{
				_object = objectNotProvided;
			}

			string log;

			if (_additional.IsNullOrEmpty())
			{
				log = string.Format(logPattern, FormatDateTime(), _logType.ToUpper(), _object, _message);
			}
			else
			{
				log = string.Format(logPatternLong, FormatDateTime(), _logType.ToUpper(), _object, _message, _additional);
			}

			Console.WriteLine(log);
			FileHelper.WriteToFile(log, logFileName);
		}

		private static void Log(string _message, Type _source, LogTypeEnum _logType, string _additional = null)
			=> Log(_message, _source.ToString(), _logType, _additional);

		public static void LogError(string _messsage, string _object, LogErrorSeverity _severity = LogErrorSeverity.Low)
			=> Log(_messsage, _object, LogTypeEnum.Error, _severity.ToUpper());

		public static void LogError(string _messsage, Type _source, LogErrorSeverity _severity = LogErrorSeverity.Low)
			=> Log(_messsage, _source, LogTypeEnum.Error, _severity.ToUpper());

		public static void LogInfo(string _messsage, string _object, string _additional = null)
			=> Log(_messsage, _object, LogTypeEnum.Info, _additional);

		public static void LogInfo(string _messsage, Type _source, string _additional = null)
			=> Log(_messsage, _source, LogTypeEnum.Info, _additional);

		public static void LogWarning(string _message, string _object, string _additional = null)
			=> Log(_message, _object, LogTypeEnum.Warning, _additional);

		public static void LogWarning(string _message, Type _source, string _additional = null)
			=> Log(_message, _source, LogTypeEnum.Warning, _additional);
	}

    public enum LogErrorSeverity
	{
		Low,
		Medium,
		High,
		Fatal,
	}

	public enum LogTypeEnum
	{
		Info,
		Warning,
		Error,
	}
}
