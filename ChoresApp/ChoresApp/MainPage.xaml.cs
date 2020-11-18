using ChoresApp.Controls;
using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Fields;
using ChoresApp.Controls.Images;
using ChoresApp.Controls.Navbar;
using ChoresApp.Helpers;
using ChoresApp.Pages;
using ChoresApp.Pages.Test;
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
	//public class MainPage : ContentPage
	{
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid mainGrid;
        private ChIcon icon;
        private int iconStateCount = 0;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public MainPage()
		{
            InitializeComponent();

            Content = MainGrid;

            Rawr();
            Grr();
        }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid MainGrid
        {
            get
			{
                if (mainGrid != null) return mainGrid;

                mainGrid = new Grid
                {
                    RowSpacing = 0,
                    RowDefinitions =
					{
                        UIHelper.MakeStarRow(),
                        UIHelper.MakeStaticRow(ResourceHelper.FooterHeight),
					},
                };

                mainGrid.Children.Add(PageContent, 0, 0);
                mainGrid.Children.Add(Navbar, 0, 1);

                return mainGrid;
            }
        }

        public ContentView PageContent { get; } = new ContentView();

        private ChNavbar navbar;
        private ChNavbar Navbar
		{
            get
			{
                if (navbar != null) return navbar;
                navbar = new ChNavbar();
                return navbar;
            }
		}

        public ChContentPage HomeContent { get; set; }
        public ChContentPage Nav1Content { get; set; }
        public ChContentPage Nav2Content { get; set; }
        public ChContentPage Nav3Content { get; set; }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Rawr()
        {
            var sl = new StackLayout();

            var rawr = new ChEntry
            {
                Title = "Entry Title",
            };
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


            var datePicker = new ChDatePicker
            {
                Title = "Date Pickerrr",
            };
            sl.Children.Add(datePicker);

            // ~~~~~~~~~~~~~~~~~~~~

            var sv = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                Content = sl,
            };

            HomeContent = new ChContentPage(sv);
        }

        private void Grr()
		{
            Nav1Content = new TestPage();
            Nav2Content = new TestPage();
            Nav3Content = new TestPage();
        }
	}
}
