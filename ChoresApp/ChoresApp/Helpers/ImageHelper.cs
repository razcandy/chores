using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Helpers
{
	public static class ImageHelper
	{
		/// <summary>
		/// Icons will primarily be sources from https://material.io/
		/// UWP icons are saved as the hdpi-48 flavor
		/// Android icons will use the .xml flavor
		/// </summary>

		// Leaving jic iOS needs something special
		//private static string directory;

		//public static string Directory
		//{
		//	get
		//	{
		//		if (directory.IsNullOrEmpty())
		//		{
		//			try
		//			{
		//				directory = Device.RuntimePlatform.Equals(Device.iOS) ? "Images/" : "Resources/Images/";
		//				//directory = "";
		//			}
		//			catch (InvalidOperationException e)
		//			{
		//				directory = string.Empty;
		//			}
		//		}

		//		return directory;
		//	}
		//}

		//public static string Test => Directory + "test.jpg";
		//public static string Test => "test.png";
		public static string Test => "test.png";

		//public static string Eco => "round_eco_24.xml";
		public static string Eco => "round_eco.png";

		public static string EcoSvg => "eco-black-48dp.svg";


		//public static ChImageSource EcoTest = new ChImageSource("round_eco.png");
		public static ChImageSource EcoTest = new ChImageSource("round_eco_test.png");


		private static ChImageSource calendar;

		public static ChImageSource Calendar
		{
			get
			{
				if (calendar != null) return calendar;

				calendar = new ChImageSource("calendar.png");

				return calendar;
			}
		}

		public static string Clock => GetImage("clock.png");


		public static string GetImage(string _imageKey)
		{
			return _imageKey + (IsDarkTheme ? "_dark" : string.Empty);
		}

		public static string Rawr(string _imageKey)
		{
			string source = _imageKey;

			if (IsDarkTheme)
			{
				source += darkSuffix;
			}

			return source;
		}

		private const string darkSuffix = "_dark";

		private static bool IsDarkTheme;

		public static string NotFound = "notFound.png";
	}

	/// <summary>
	/// Class is not intended to change when the theme does
	/// </summary>
	public class ChImageSource
	{
		//private const IEnumerable<string> validFileExtensions = new { "", "" };

		private static string[] validFileExtensions = new string[] { ".png", ".jpg", ".jpeg" };

		private const string SELECTED = "_selected";
		private const string DARKTHEME = "_dark";
		private const string ERRORED = "_errored";

		private bool erroredExists;
		private bool selectedExists;

		//public ChImageSource(string _source)
		//{
		//	var uri = new Uri(_source);

			
		//}

		public ChImageSource(string _source, bool _selectedExists = false, bool _erroredExists = false)
		{
			if (_source.IsNullOrEmpty())
			{
				// log - Cannot reference an image with an empty string

				_source = ImageHelper.NotFound;
				_selectedExists = false;
				_erroredExists = false;
			}

			// check source valid

			var sourceArray = _source.Split('.');

			FileName = sourceArray[0];
			FileType = "." + sourceArray[1];

			lightSource = FileName + FileType;
			darkSource = FileName + DARKTHEME + FileType;

			selectedExists = _selectedExists;
			erroredExists = _erroredExists;

			if (_selectedExists)
			{
				lightSelectedSource = FileName + SELECTED + FileType;
				darkSelectedSource = FileName + DARKTHEME + SELECTED + FileType;
			}
			else
			{
				lightSelectedSource = lightSource;
				darkSelectedSource = darkSource;
			}

			if (_erroredExists)
			{
				lightErroredSource = FileName + ERRORED + FileType;
				darkErroredSource = FileName + DARKTHEME + ERRORED + FileType;
			}
			else
			{
				lightErroredSource = lightSource;
				darkErroredSource = darkSource;
			}
		}

		private string lightSource;
		private string lightSelectedSource;
		private string lightErroredSource;

		private string darkSource;
		private string darkSelectedSource;
		private string darkErroredSource;

		public string FileName { get; private set; }
		public string FileType { get; private set; }

		public string AsErrored()
		{
			if (!erroredExists)
			{
				// log - image does not exist
			}

			return ResourceHelper.IsLightTheme() ? lightErroredSource : darkErroredSource;
		}

		public string AsSelected()
		{
			if (!selectedExists)
			{
				// log - image does not exist
			}

			return ResourceHelper.IsLightTheme() ? lightSelectedSource : darkSelectedSource;
		}

		public static implicit operator string(ChImageSource _imgSource)
		{
			return ResourceHelper.IsLightTheme() ? _imgSource.lightSource : _imgSource.darkSource;
		}

		public static implicit operator ImageSource(ChImageSource _imgSource)
		{
			//return ResourceHelper.IsLightTheme() ? _imgSource.lightSource : _imgSource.darkSource;

			return _imgSource.lightSource;
		}
	}
}
