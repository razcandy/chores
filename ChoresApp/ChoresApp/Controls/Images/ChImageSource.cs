using ChoresApp.Helpers;
using Xamarin.Forms;

namespace ChoresApp.Controls.Images
{
	public class ChImageSource
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChImageSource(string _source, bool _darkExists = true, bool _erroredExists = false,
			bool _selectedExists = false)
		{
			if (_source.IsNullOrEmpty())
			{
				Source = ImageHelper.NotFound;
				DarkThemeExists = false;
				ErroredExists = false;
				SelectedExists = false;
			}
			else
			{
				Source = _source;
				DarkThemeExists = _darkExists;
				ErroredExists = _erroredExists;
				SelectedExists = _selectedExists;
			}

			ParseSource();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public bool DarkThemeExists { get; }
		public bool ErroredExists { get; }
		public string Source { get; }
		public bool SelectedExists { get; }

		public string LightSource { get; private set; }
		public string LightSelectedSource { get; private set; }
		public string LightErroredSource { get; private set; }

		public string DarkSource { get; private set; }
		public string DarkSelectedSource { get; private set; }
		public string DarkErroredSource { get; private set; }

		public string FileName { get; private set; }
		public string FileType { get; private set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void ParseSource()
		{
			// check source valid
			// check dark theme version exists

			var sourceArray = Source.Split('.');

			FileName = sourceArray[0];
			FileType = "." + sourceArray[1];

			if (Device.RuntimePlatform == Device.Android)
			{
				ParseSourceAndroid();
			}
			else if (Device.RuntimePlatform == Device.UWP)
			{
				ParseSourceUWP();
			}
		}

		private void ParseSourceAndroid()
		{
			LightSource = FileName + FileType;
			DarkSource = LightSource;

			if (SelectedExists)
			{
				LightSelectedSource = FileName + ImageHelper.SELECTED_KEY + FileType;
				DarkSelectedSource = LightSelectedSource;
			}
			else
			{
				LightSelectedSource = LightSource;
				DarkSelectedSource = LightSelectedSource;
			}

			if (ErroredExists)
			{
				LightErroredSource = FileName + ImageHelper.ERRORED_KEY + FileType;
				DarkErroredSource = LightErroredSource;
			}
			else
			{
				LightErroredSource = LightSource;
				DarkErroredSource = LightErroredSource;
			}
		}

		private void ParseSourceUWP()
		{
			if (!DarkThemeExists)
			{
				ParseSourceAndroid();
				return;
			}

			LightSource = FileName + FileType;
			DarkSource = FileName + ImageHelper.DARKTHEME_KEY + FileType;

			if (SelectedExists)
			{
				LightSelectedSource = FileName + ImageHelper.SELECTED_KEY + FileType;
				DarkSelectedSource = FileName + ImageHelper.DARKTHEME_KEY + ImageHelper.SELECTED_KEY + FileType;
			}
			else
			{
				LightSelectedSource = LightSource;
				DarkSelectedSource = DarkSource;
			}

			if (ErroredExists)
			{
				LightErroredSource = FileName + ImageHelper.ERRORED_KEY + FileType;
				DarkErroredSource = FileName + ImageHelper.DARKTHEME_KEY + ImageHelper.ERRORED_KEY + FileType;
			}
			else
			{
				LightErroredSource = LightSource;
				DarkErroredSource = DarkSource;
			}
		}

		public static implicit operator ImageSource(ChImageSource _source) => _source.Source;
		public static implicit operator string(ChImageSource _source) => _source.Source;
	}
}
