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

		public const string SELECTED_KEY = "_selected";
		public const string DARKTHEME_KEY = "_dark";
		public const string ERRORED_KEY = "_errored";

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static ChImageSource Back { get; } = new ChImageSource("arrow_back.png");

		public static ChImageSource Calendar { get; } = new ChImageSource("calendar.png");

		public static ChImageSource Check { get; } = new ChImageSource("check.png");

		public static ChImageSource Clock { get; } = new ChImageSource("clock.png");

		public static ChImageSource Close { get; } = new ChImageSource("close.png");

		public static ChImageSource Debug { get; } = new ChImageSource("debug.png", true, false, true);

		public static ChImageSource Eco { get; } = new ChImageSource("round_eco.png", false, false, false);
		
		public static ChImageSource Error { get; } = new ChImageSource("error.png", false, false, false);

		public static ChImageSource Home { get; } = new ChImageSource("home.png", true, false, true);

		public static ChImageSource NotFound { get; } = new ChImageSource("broken_image.png", true, true, true);

		public static ChImageSource PickerArrow { get; } = new ChImageSource("picker_arrow.png");

		public static ChImageSource Refresh { get; } = new ChImageSource("refresh.png");

		public static ChImageSource Visibility { get; } = new ChImageSource("visibility.png");

		public static ChImageSource VisibilityOff { get; } = new ChImageSource("visibility_off.png");
	}
}
