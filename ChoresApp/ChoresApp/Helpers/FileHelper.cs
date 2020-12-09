using ChoresApp.Data;
using ChoresApp.Data.Models;
using ChoresApp.Resources;
using LiteDB;
using System;
using System.IO;

namespace ChoresApp.Helpers
{
	public static class FileHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string directory;

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static string Directory
		{
			get
			{
				if (!directory.IsNullOrEmpty()) return directory;
				directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\";
				return directory;
			}
		}

		public static string UserDataDirectory => Directory + FileKeys.UserDataFolderName + "\\";

		public static string UserDirectory { get; private set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static bool DoesFileExist(string _directory, string _filename)
		{
			if (_directory.IsNullOrEmpty() || _filename.IsNullOrEmpty()) return false;

			return File.Exists(_directory + _filename);
		}

		private static bool TryCreateFile(string _directory, string _filename)
		{
			if (_directory.IsNullOrEmpty() || _filename.IsNullOrEmpty()) return false;

			if (DoesFileExist(_directory, _filename)) return false;

			File.Create(_directory + _filename).Close();

			return true;
		}

		public static void AppStartup()
		{
			CreateDirectory(FileKeys.UserDataFolderName);
		}

		public static bool DoesFileExist(string _filename)
			=> DoesFileExist(Directory, _filename);

		public static void CreateDirectory(string _suffix)
		{
			if (_suffix.IsNullOrEmpty()) return;

			System.IO.Directory.CreateDirectory(Directory + _suffix);
		}

		public static void CreateUserDirectory(string _username, bool _setAsCurrentUser = true)
		{
			if (_username.IsNullOrEmpty()) return;

			var suffix = FileKeys.UserDataFolderName + "\\" + _username + "\\";
			CreateDirectory(suffix);

			if (_setAsCurrentUser)
			{
				UserDirectory = Directory + suffix;
			}
		}

		public static bool DoesUserDirectoryExist(string _username)
		{
			if (_username.IsNullOrEmpty()) return false;

			return System.IO.Directory.Exists(UserDataDirectory + _username);
		}

		public static bool DoesUserDirectoryExist(SessionModel _session)
			=> DoesUserDirectoryExist(_session.Username);

		public static bool TryCreateFile(string _filename)
			=> TryCreateFile(Directory, _filename);

		//public static bool TryCreateUserFile(string _filename)
		//	=> TryCreateFile(UserDirectory, _filename);

		/// <summary>
		/// Summary from System.IO.File.cs:
		///		Creates a System.IO.StreamWriter that appends UTF-8 encoded text to an existing
		///		file, or to a new file if the specified file does not exist.
		/// </summary>
		/// <param name="_text"></param>
		public static void WriteToFile(string _text, string _fileName)
		{
			if (_text.IsNullOrEmpty() || _fileName.IsNullOrEmpty()) return;

			var writer = File.AppendText(Directory + _fileName);
			writer.WriteLine(_text);
			writer.Close();
		}
	}
}
