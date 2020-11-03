using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Navbar
{
	public class ChNavbar : ContentView
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChNavbar() : base()
		{
			BackgroundColor = ResourceHelper.PrimaryColor;
			Content = MainGrid;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid MainGrid
		{
			get
			{
				if (mainGrid != null) return mainGrid;

				mainGrid = new Grid
				{
					ColumnSpacing = 0,
					ColumnDefinitions =
					{
						UIHelper.MakeStarColumn(), // home
						UIHelper.MakeStarColumn(),
						UIHelper.MakeStarColumn(),
						UIHelper.MakeStarColumn(),
					},
				};

				return mainGrid;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	}
}
