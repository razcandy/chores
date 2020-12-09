using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Resources
{
	public class Constants
	{
		public const string DefaultUsername = "default";
	}

	public static class DatabaseKeys
	{
		public const string Global = "global.db";
		public const string Session = "session.db";
	}

	public static class FileKeys
	{
		public const string UserDataFolderName = "userdata";
	}

	public static class FontKeys
	{
		public const string Roboto_Black = "Roboto_Black";
		public const string Roboto_Black_Italic = "Roboto_Black_Italic";
		public const string Roboto_Bold = "Roboto_Bold";
		public const string Roboto_Bold_Italic = "Roboto_Bold_Italic";
		public const string Roboto_Italic = "Roboto_Italic";
		public const string Roboto_Light = "Roboto_Light";
		public const string Roboto_Light_Italic = "Roboto_Light_Italic";
		public const string Roboto_Medium = "Roboto_Medium";
		public const string Roboto_Medium_Italic = "Roboto_Medium_Italic";
		public const string Roboto = "Roboto";
		public const string Roboto_Thin = "Roboto_Thin";
		public const string Roboto_Thin_Italic = "Roboto_Thin_Italic";
	}

	public static class RegexPatterns
	{
		public const string AlphanumericOnly = @"^[\w]";
	}
}
