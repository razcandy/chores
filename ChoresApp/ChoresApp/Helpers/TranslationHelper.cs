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

			buttonsTransCache.Add(ButtonTransKeyEnum.Save.ToUpper(), "SAVE");
			buttonsTransCache.Add(ButtonTransKeyEnum.Cancel.ToUpper(), "CANCEL");
			buttonsTransCache.Add(ButtonTransKeyEnum.Back.ToUpper(), "BACK");
			buttonsTransCache.Add(ButtonTransKeyEnum.LogIn.ToUpper(), "LOG IN");
			buttonsTransCache.Add(ButtonTransKeyEnum.SignUp.ToUpper(), "SIGN UP");
			buttonsTransCache.Add(ButtonTransKeyEnum.Continue.ToUpper(), "CONTINUE");
			buttonsTransCache.Add(ButtonTransKeyEnum.OK.ToUpper(), "OK");

			titlesTransCache.Add(TitleTransKeyEnum.Username.ToUpper(), "Username");
			titlesTransCache.Add(TitleTransKeyEnum.Password.ToUpper(), "Password");
			titlesTransCache.Add(TitleTransKeyEnum.Name.ToUpper(), "Name");
			titlesTransCache.Add(TitleTransKeyEnum.LogIn.ToUpper(), "Log In");
			titlesTransCache.Add(TitleTransKeyEnum.SignUp.ToUpper(), "Sign Up");
			titlesTransCache.Add(TitleTransKeyEnum.Error.ToUpper(), "Error");

			messagesTransCache.Add(MessageTransKeyEnum.NeedToLogin.ToUpper(), "Have an account?");
			messagesTransCache.Add(MessageTransKeyEnum.NeedToSignUp.ToUpper(), "Don't have an account?");
			messagesTransCache.Add(MessageTransKeyEnum.InvalidCred.ToUpper(), "Invalid credentials");
			messagesTransCache.Add(MessageTransKeyEnum.UserAlreadyExists.ToUpper(), "User with provided username already exists");
			messagesTransCache.Add(MessageTransKeyEnum.NoUserFound.ToUpper(), "No user found with provided username");
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
		LogIn,
		SignUp,
		Continue,
		OK,
	}

	public enum TitleTransKeyEnum
	{
		EnumDefault,
		Username,
		Password,
		Name,
		LogIn,
		SignUp,
		Error,
	}

	public enum MessageTransKeyEnum
	{
		EnumDefault,
		NeedToLogin,
		NeedToSignUp,
		InvalidCred,
		UserAlreadyExists,
		NoUserFound,
	}
}
