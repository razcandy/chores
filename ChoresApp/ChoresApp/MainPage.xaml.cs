using ChoresApp.Controls;
using ChoresApp.Controls.Buttons;
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
                //Text = "rawr",
                ImageSource = ImageHelper.Eco,
                WidthRequest = 120,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                //Style = ResourceHelper.ButtonEmptyStyle,

                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 6),
            };
			testButton.Clicked += TestButton_Clicked;

            //testButton.IsEnabled = false;

            sl.Children.Add(testButton);



            var rawrButton = new ChImageButton
            {
                BackgroundColor = Color.Green,
            };

            sl.Children.Add(rawrButton);

            var imgButton = new ImageButton
            {
                Aspect = Aspect.AspectFit,
                HeightRequest = 50,
                Source = ImageHelper.Eco,
                BackgroundColor = Color.Pink,
            };

            sl.Children.Add(imgButton);


            var test0 = new ChTextButton
            {
                Style = ResourceHelper.ButtonTextStyle,
                TranslationKey = ButtonTransKeyEnum.Back,
            };

            test0.Clicked += delegate
            {
                test0.Style = ResourceHelper.ButtonContainedStyle;
            };

            var test1 = new ChTextButton
            {
                Style = ResourceHelper.ButtonOutlinedStyle,
                TranslationKey = ButtonTransKeyEnum.Save,
            };

            var test2 = new ChTextButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                TranslationKey = ButtonTransKeyEnum.Cancel,
            };

            sl.Children.Add(test0);
            sl.Children.Add(test1);
            sl.Children.Add(test2);

            var home = new ChIconButton();
            home.Icon.IconSource = ImageHelper.Home;

            sl.Children.Add(home);
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
