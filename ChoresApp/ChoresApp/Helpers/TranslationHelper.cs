using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Helpers
{
	public static class TranslationHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static Dictionary<string, string> buttonsTransCache = new Dictionary<string, string>();
		private static Dictionary<string, string> titlesTransCache = new Dictionary<string, string>();
		private static Dictionary<string, string> messagesTransCache = new Dictionary<string, string>();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static void InitTest()
		{
			buttonsTransCache = new Dictionary<string, string>();
			titlesTransCache = new Dictionary<string, string>();
			messagesTransCache = new Dictionary<string, string>();

			buttonsTransCache.Add(ButtonTransKeyEnum.Save.ToUpper(), "SAVE~");
			buttonsTransCache.Add(ButtonTransKeyEnum.Cancel.ToUpper(), "CANCEL~");
			buttonsTransCache.Add(ButtonTransKeyEnum.Back.ToUpper(), "BACK~");
		}
		
		private static string GetTranslationOrDefault(Enum _enumKey, Dictionary<string, string> _cache)
		{
			string trans;

			if (_cache.TryGetValue(_enumKey.ToUpper(), out string value))
			{
				trans = value;
			}
			else
			{
				var error = string.Format(LogMessages.BrokenTranslation, _enumKey);
				LogHelper.LogError(error, _enumKey.GetType(), LogErrorSeverity.Medium);

				trans = "<" + _enumKey.ToUpper() + ">";
			}

			return trans;
		}

		public static string GetTranslationOrDefault(ButtonTransKeyEnum _key)
			=> GetTranslationOrDefault(_key, buttonsTransCache);

		public static string GetTranslationOrDefault(TitleTransKeyEnum _key)
			=> GetTranslationOrDefault(_key, titlesTransCache);

		public static string GetTranslationOrDefault(MessageTransKeyEnum _key)
			=> GetTranslationOrDefault(_key, messagesTransCache);
	}

	public enum ButtonTransKeyEnum
	{
		EnumDefault,
		Save,
		Cancel,
		Back,
	}

	public enum TitleTransKeyEnum
	{
		EnumDefault,
	}

	public enum MessageTransKeyEnum
	{
		EnumDefault,
	}
}
