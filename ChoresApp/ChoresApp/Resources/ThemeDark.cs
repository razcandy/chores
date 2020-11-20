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
        protected override Color PrimaryColor => Color.FromHex("#43a047");
        protected override Color PrimaryLightColor => Color.FromHex("#76d275");
        protected override Color PrimaryDarkColor => Color.FromHex("#00701a");

        protected override Color SecondaryColor => Color.FromHex("#fdd835");
        protected override Color SecondaryLightColor => Color.FromHex("#ffff6b");
        protected override Color SecondaryDarkColor => Color.FromHex("#c6a700");

        protected override Color OnPrimaryColor => Color.FromHex("#000000");
        protected override Color OnSecondaryColor => Color.FromHex("#000000");
        protected override Color OnBackgroundColor => Color.FromHex("#FFFFFF");
        protected override Color OnSurfaceColor => Color.FromHex("#FFFFFF");
        protected override Color OnErrorColor => Color.FromHex("#000000");

        protected override Color BackgroundColor => Color.FromHex("#121212");
        //protected override Color SurfaceColor => Color.FromHex("#121212");
        protected override Color SurfaceColor => BackgroundColor.AddLuminosity(0.05);
        protected override Color ErrorColor => Color.FromHex("#CF6679");

        protected override Color DefaultTextColor => Color.FromHex("#FFFFFF");

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
