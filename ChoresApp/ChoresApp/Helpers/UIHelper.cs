using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Helpers
{
    public static class UIHelper
    {
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static BoxView MakeHorizontalDivider(double _thickness = 1)
        {
            return new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 1,
                Margin = 0,
                HeightRequest = _thickness,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
            };
        }

        public static BoxView MakeVerticalDivider(double _thickness = 1)
        {
            return new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 1,
                Margin = 0,
                WidthRequest = _thickness,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
        }

        public static ColumnDefinition MakeAutoColumn() => new ColumnDefinition { Width = GridLength.Auto };
        public static RowDefinition MakeAutoRow() => new RowDefinition { Height = GridLength.Auto };

        public static ColumnDefinition MakeStarColumn(double _multiplier = 1)
		{
            return new ColumnDefinition
            {
                Width = new GridLength(_multiplier, GridUnitType.Star),
            };
        }

        public static RowDefinition MakeStarRow(double _multiplier = 1)
        {
            return new RowDefinition
            {
                Height = new GridLength(_multiplier, GridUnitType.Star),
            };
        }

        public static ColumnDefinition MakeStaticColomn(double _width)
		{
            return new ColumnDefinition
            {
				Width = _width,
			};
		}

        public static RowDefinition MakeStaticRow(double _height)
		{
            return new RowDefinition
            {
                Height = _height,
            };
		}

        public static Color RandomColor()
		{
            var r = new Random();
            return Color.FromRgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
		}
    }
}
