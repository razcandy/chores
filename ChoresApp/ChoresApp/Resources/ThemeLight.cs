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
        public override Color PrimaryColor => Color.FromHex("#43a047");
        public override Color PrimaryLightColor => Color.FromHex("#76d275");
        public override Color PrimaryDarkColor => Color.FromHex("#00701a");

        public override Color SecondaryColor => Color.FromHex("#fdd835");
        public override Color SecondaryLightColor => Color.FromHex("#ffff6b");
        public override Color SecondaryDarkColor => Color.FromHex("#c6a700");

        public override Color OnPrimaryColor => Color.FromHex("#FFFFFF");
        public override Color OnSecondaryColor => Color.FromHex("#000000");
        public override Color OnBackgroundColor => Color.FromHex("#000000");
        public override Color OnSurfaceColor => Color.FromHex("#000000");
        public override Color OnErrorColor => Color.FromHex("#FFFFFF");

        public override Color BackgroundColor => Color.FromHex("#FFFFFF");
        public override Color SurfaceColor => Color.FromHex("#DDDDDD");
        public override Color ErrorColor => Color.FromHex("#B00020");

        public override Color DefaultTextColor => Color.FromHex("#000000");

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public override Style FrameCardStyle
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
