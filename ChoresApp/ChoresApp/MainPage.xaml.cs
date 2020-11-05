﻿using ChoresApp.Controls;
using ChoresApp.Controls.Fields;
using ChoresApp.Controls.Images;
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
                //Source = ImageHelper.Eco,

                Source = ImageHelper.Eco,

                WidthRequest = dimension,
                HeightRequest = 100,
                BackgroundColor = Color.Blue,
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

            icon = new ChIcon
            {
                IconSource = ImageHelper.NotFound,
            };

            sl.Children.Add(icon);


            var testButton = new Button
            {
                Text = "rawr",
                ImageSource = ImageHelper.Eco,
                WidthRequest = 120,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                Style = ResourceHelper.ButtonEmptyStyle,
            };
			testButton.Clicked += TestButton_Clicked;

            sl.Children.Add(testButton);
        }

        private ChIcon icon;
        private int iconStateCount = 0;

        private void TestButton_Clicked(object sender, EventArgs e)
		{
			// 0 reg
			// 1 selected
			// 2 selected & errored
			// 3 errored
			// 4 reg

			switch (iconStateCount)
			{
                case 0:
                    icon.IsSelected = true;
                    break;

                case 1:
                    icon.IsErrored = true;
                    break;

                case 2:
                    icon.IsSelected = false;
                    break;

                case 3:
                    icon.IsErrored = false;
                    iconStateCount = 0;
                    return;

				default:
					break;
			}

            iconStateCount++;
        }
	}
}
