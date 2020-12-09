using ChoresApp.Data.Models;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChoresApp.Helpers
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

			if (!GlobalData.GlobalModel.AutoLogin || username.IsNullOrEmpty())
			{
				return false;
			}

			if (!FileHelper.DoesUserDirectoryExist(username))
			{
				return false;
			}

			var connectionString = FileHelper.UserDataDirectory + username + "\\" + DatabaseKeys.Session;

			var user = await DatabaseHelper.QueryOnPrimaryKey<SessionModel>(username, connectionString);

			if (user != null)
			{
				await GlobalData.SetUserSession(user);
				GlobalData.IsUserLoggedIn = true;
			}

			return true;
		}

		public static async Task<(bool Success, string Message)> TryCreateUser(SessionModel _session)
		{
			if (_session == null || !IsPasswordValid(_session.Password)
				|| !IsUsernameValid(_session.Username)
				|| _session.Name.IsNullOrEmpty()) return (false, "Invalid");

			if (FileHelper.DoesUserDirectoryExist(_session))
			{
				return (false, "User already exists");
			}

			FileHelper.CreateUserDirectory(_session.Username);
			await DatabaseHelper.Upsert(_session);
			await GlobalData.SetUserSession(_session);
			GlobalData.IsUserLoggedIn = true;

			return (true, string.Empty);
		}

		public static async Task<(bool Success, string Message)> TryLogIn(SessionModel _session)
		{
			if (_session == null || !IsPasswordValid(_session.Password)
				|| !IsUsernameValid(_session.Username)) return (false, "Invalid");

			if (!FileHelper.DoesUserDirectoryExist(_session)) return (false, "No user found");

			// query database and match password

			GlobalData.IsUserLoggedIn = true;

			return (true, string.Empty);
		}
	}
}
