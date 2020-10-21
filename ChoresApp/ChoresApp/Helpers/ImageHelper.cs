using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Helpers
{
	public class ImageHelper
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
	}
}
