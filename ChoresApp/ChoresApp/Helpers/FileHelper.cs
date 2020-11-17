using System;
using System.IO;

namespace ChoresApp.Helpers
{
	public static class FileHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string directory;

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string Directory
		{
			get
			{
				if (!directory.IsNullOrEmpty()) return directory;
				directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\";
				return directory;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public static void CreateFile(string _filename)
		{
			if (_filename.IsNullOrEmpty()) return;

			File.Create(Directory + _filename).Close();
		}

		public static bool DoesFileExist(string _filename)
		{
			if (_filename.IsNullOrEmpty()) return false;

			var fullFilename = Directory + _filename;
			var tmp = File.Exists(fullFilename);

			return tmp;
		}

		public static bool TryCreateFile(string _filename)
		{
			if (_filename.IsNullOrEmpty()) return false;

			if (DoesFileExist(_filename)) return false;

			File.Create(Directory + _filename).Close();

			return true;
		}

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
