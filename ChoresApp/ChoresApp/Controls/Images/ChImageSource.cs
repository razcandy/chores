using ChoresApp.Helpers;
using Xamarin.Forms;

namespace ChoresApp.Controls.Images
{
	public class ChImageSource
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChImageSource(string _source, bool _darkExists = true, bool _erroredExists = false, bool _selectedExists = false)
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
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public bool DarkThemeExists { get; }
		public bool ErroredExists { get; }
		public string Source { get; }
		public bool SelectedExists { get; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static implicit operator ImageSource(ChImageSource _source) => _source.Source;
		public static implicit operator string(ChImageSource _source) => _source.Source;
	}
}
