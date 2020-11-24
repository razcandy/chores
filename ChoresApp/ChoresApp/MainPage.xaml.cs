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
	{
        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid mainGrid;

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

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Rawr()
        {
            var sl = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Vertical,
            };

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

            var entry = new ChEntry
            {
                Title = "Entry Title",
            };
            sl.Children.Add(entry);

            var datePicker = new ChDatePicker
            {
                Title = "Date Picker Title",
            };
			sl.Children.Add(datePicker);

			var timePicker = new ChTimePicker
            {
                Title = "Time Picker Title",
            };
			sl.Children.Add(timePicker);

			var pick = new ChPicker
            {
                Title = "Picker Title",
            };
            sl.Children.Add(pick);

            var edit = new ChEditor
            {
                Title = "Editor Title",
				AutoSize = true,
			};
            sl.Children.Add(edit);

            var but2 = new Button
            {
                Text = "Change icon source",
            };
            but2.Clicked += delegate
			{
				if (entry.IsErrored)
				{
                    entry.IsErrored = false;
                    entry.IsValidated = false;
				}
                else if (entry.IsValidated)
				{
                    entry.IsErrored = true;
				}
                else
				{
                    entry.IsValidated = true;
                }
			};

            sl.Children.Add(but2);

            // ~~~~~~~~~~~~~~~~~~~~

            var g = new Grid();
            g.Children.Add(sl);

			var frame = new Frame
			{
				BackgroundColor = ResourceHelper.SurfaceColor,
				VerticalOptions = LayoutOptions.Start,
				Content = g,
			};

			var sv = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
				Content = new ContentView
				{
					VerticalOptions = LayoutOptions.Start,
					Content = frame,
				},
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
