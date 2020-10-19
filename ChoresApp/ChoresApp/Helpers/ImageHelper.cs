using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Helpers
{
	public class ImageHelper
	{
		private static string directory;

		public static string Directory
		{
			get
			{
				if (directory.IsNullOrEmpty())
				{
					try
					{
						directory = Device.RuntimePlatform.Equals(Device.iOS) ? "Images/" : "Resources/Images/";
					}
					catch (InvalidOperationException e)
					{
						directory = string.Empty;
					}
				}

				return directory;
			}
		}

		public static string Test => Directory + "test.jpg";
	}
}
