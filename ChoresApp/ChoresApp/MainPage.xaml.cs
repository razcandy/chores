using ChoresApp.Controls.Fields;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChoresApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var grr = new Entry();
            sl.Children.Add(grr);

            var rawr = new ChEntry();
            sl.Children.Add(rawr);

            var dimension = 48;

            var img = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageHelper.Eco,

                WidthRequest = dimension,
                HeightRequest = dimension,
                BackgroundColor = Color.Red,
            };

            sl.Children.Add(img);

            sl.Children.Add(new BoxView
            {
                BackgroundColor = Color.Orange,
                WidthRequest = dimension,
                HeightRequest = dimension,
                HorizontalOptions = LayoutOptions.Center,
            });

            sl.Children.Add(new Image
            {
                WidthRequest = dimension,
                HeightRequest = dimension,
                HorizontalOptions = LayoutOptions.Center,
                Source = "Assets\\eco-black-48dp.svg",
            });

            var but = new Button
            {
                Text = "Toggle Theme",
                WidthRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
            };

            but.Clicked += delegate
            {
                ResourceHelper.ToggleTheme();
            };

            sl.Children.Add(but);

            var f = new Frame
            {
                //BackgroundColor = ResourceHelper.SurfaceColor,
                Style = ResourceHelper.FrameCardStyle,

                //BackgroundColor = Color.Pink,
                //HasShadow = true,
            };

            sl.Children.Add(f);

            var testButton = new Button
            {
                Text = "rawr",
                ImageSource = ImageHelper.Eco,
                WidthRequest = 120,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                Style = ResourceHelper.ButtonEmptyStyle,
            };

            sl.Children.Add(testButton);
        }
    }
}
