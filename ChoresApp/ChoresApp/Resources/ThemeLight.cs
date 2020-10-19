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
        protected override Color PrimaryColor => Color.FromHex("#f5f5f5");
        protected override Color PrimaryLightColor => Color.FromHex("#ffffff");
        protected override Color PrimaryDarkColor => Color.FromHex("#c2c2c2");

        protected override Color SecondaryColor => Color.FromHex("#9e9d24");
        protected override Color SecondaryLightColor => Color.FromHex("#d2ce56");
        protected override Color SecondaryDarkColor => Color.FromHex("#6c6f00");

        protected override Color PrimaryTextColor => Color.FromHex("#000000");
        protected override Color PrimaryTextOnLightColor => Color.FromHex("#000000");
        protected override Color PrimaryTextOnDarkColor => Color.FromHex("#000000");

        protected override Color SecondaryTextColor => Color.FromHex("#000000");
        protected override Color SecondaryTextOnLightColor => Color.FromHex("#000000");
        protected override Color SecondaryTextOnDarkColor => Color.FromHex("#FFFFFF");

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
