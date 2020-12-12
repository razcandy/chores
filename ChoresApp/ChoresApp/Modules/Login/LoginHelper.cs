using ChoresApp.Data.Models;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChoresApp.Modules.Login
{
	public static class LoginHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static bool IsPasswordValid(string _password)
		{
			if (_password.IsNullOrEmpty()) return false;

			return true;
		}

		public static bool IsUsernameValid(string _username)
		{
			if (_username.IsNullOrEmpty()) return false;

			var reg = new Regex(RegexPatterns.AlphanumericOnly);
			return reg.IsMatch(_username);
		}

		public static void CreateDefaultUser()
		{
			var defaultSessionModel = new SessionModel
			{
				Username = Constants.DefaultUsername,
				Password = Constants.DefaultUsername,
				Name = Constants.DefaultUsername,
			};

			TryCreateUser(defaultSessionModel);
		}

		public static async Task<bool> TryAutoLogIn()
		{
			var username = GlobalData.GlobalModel.LastUsername;

			if (!GlobalData.GlobalModel.AutoLogin || username.IsNullOrEmpty()
				|| !FileHelper.DoesUserDirectoryExist(username))
			{
				return false;
			}

			var connectionString = FileHelper.UserDataDirectory + username + FileHelper.Dir + DatabaseKeys.Session;
			var user = await DatabaseHelper.QueryOnPrimaryKey<SessionModel>(username, connectionString);

			if (user == null) return false;

			await GlobalData.SetUserSession(user);

			return true;
		}

		public static async Task<SuccessMessage> TryCreateUser(SessionModel _session)
		{
			var sm = new SuccessMessage();

			if (_session == null || !IsPasswordValid(_session.Password)
				|| !IsUsernameValid(_session.Username)
				|| _session.Name.IsNullOrEmpty())
			{
				sm.TranslationKey = MessageTransKeyEnum.InvalidCred;
				return sm;
			}

			if (FileHelper.DoesUserDirectoryExist(_session))
			{
				sm.TranslationKey = MessageTransKeyEnum.UserAlreadyExists;
				return sm;
			}

			FileHelper.CreateUserDirectory(_session.Username);
			await DatabaseHelper.Upsert(_session);
			await GlobalData.SetUserSession(_session);
			sm.IsSuccess = true;

			return sm;
		}

		public static async Task<SuccessMessage> TryLogIn(SessionModel _session)
		{
			var sm = new SuccessMessage();

			if (_session == null || !IsPasswordValid(_session.Password)
				|| !IsUsernameValid(_session.Username))
			{
				sm.TranslationKey = MessageTransKeyEnum.InvalidCred;
				return sm;
			}

			if (!FileHelper.DoesUserDirectoryExist(_session))
			{
				sm.TranslationKey = MessageTransKeyEnum.NoUserFound;
				return sm;
			}

			// query database and match password
			var connectionString = FileHelper.UserDataDirectory + _session.Username + FileHelper.Dir + DatabaseKeys.Session;
			var user = await DatabaseHelper.QueryOnPrimaryKey<SessionModel>(_session.Username, connectionString);

			if (user == null)
			{
				// this shouldn't happen
				return sm;
			}

			if (user.Password != _session.Password)
			{
				sm.TranslationKey = MessageTransKeyEnum.InvalidCred;
				return sm;
			}

			await GlobalData.SetUserSession(user);
			sm.IsSuccess = true;

			return sm;
		}
	}
}
