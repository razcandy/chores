using ChoresApp.Controls.Images;

namespace ChoresApp.Helpers
{
	public static class ImageHelper
	{
		/// <summary>
		/// Icons will primarily be sources from https://material.io/
		/// UWP icons are saved as the hdpi-48 flavor
		/// Android icons will use the .xml flavor
		/// </summary>

		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public const string SELECTED_KEY = "-selected";
		public const string DARKTHEME_KEY = "-dark";
		public const string ERRORED_KEY = "-errored";

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static ChImageSource Eco { get; } = new ChImageSource("round_eco.png", false, false, false);

		public static ChImageSource Clock { get; } = new ChImageSource("clock.png");

		public static ChImageSource Home { get; } = new ChImageSource("home.png", true, false, true);

		public static ChImageSource NotFound { get; } = new ChImageSource("broken_image.png", true, true, true);
	}
}
