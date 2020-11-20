using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public class ThemeLight : ThemeBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected override Color PrimaryColor => Color.FromHex("#43a047");
        protected override Color PrimaryLightColor => Color.FromHex("#76d275");
        protected override Color PrimaryDarkColor => Color.FromHex("#00701a");

        protected override Color SecondaryColor => Color.FromHex("#fdd835");
        protected override Color SecondaryLightColor => Color.FromHex("#ffff6b");
        protected override Color SecondaryDarkColor => Color.FromHex("#c6a700");

        protected override Color OnPrimaryColor => Color.FromHex("#FFFFFF");
        protected override Color OnSecondaryColor => Color.FromHex("#000000");
        protected override Color OnBackgroundColor => Color.FromHex("#000000");
        protected override Color OnSurfaceColor => Color.FromHex("#000000");
        protected override Color OnErrorColor => Color.FromHex("#FFFFFF");

        protected override Color BackgroundColor => Color.FromHex("#FFFFFF");
        protected override Color SurfaceColor => Color.FromHex("#DDDDDD");
        protected override Color ErrorColor => Color.FromHex("#B00020");

        protected override Color DefaultTextColor => Color.FromHex("#000000");

		// Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		protected override Style FrameCardStyle
		{
            get
			{
                var baseStyle = base.FrameCardStyle;

                baseStyle.Setters.Add(new Setter
                {
                    Property = Frame.HasShadowProperty, Value = true
                });

                return baseStyle;
			}
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
