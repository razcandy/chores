using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public class ThemeDark : ThemeBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override Color PrimaryColor => Color.FromHex("#43a047");
        public override Color PrimaryLightColor => Color.FromHex("#76d275");
        public override Color PrimaryDarkColor => Color.FromHex("#00701a");

        public override Color SecondaryColor => Color.FromHex("#fdd835");
        public override Color SecondaryLightColor => Color.FromHex("#ffff6b");
        public override Color SecondaryDarkColor => Color.FromHex("#c6a700");

        public override Color OnPrimaryColor => Color.FromHex("#000000");
        public override Color OnSecondaryColor => Color.FromHex("#000000");
        public override Color OnBackgroundColor => Color.FromHex("#FFFFFF");
        public override Color OnSurfaceColor => Color.FromHex("#FFFFFF");
        public override Color OnErrorColor => Color.FromHex("#000000");

        public override Color BackgroundColor => Color.FromHex("#121212");
        //protected override Color SurfaceColor => Color.FromHex("#121212");
        public override Color SurfaceColor => BackgroundColor.AddLuminosity(0.05);
        public override Color ErrorColor => Color.FromHex("#CF6679");

        public override Color DefaultTextColor => Color.FromHex("#FFFFFF");

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
