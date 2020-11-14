using ChoresApp.Controls.Images;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public class ChIconButton : ContentView
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChButtonBase button;
		private ChIcon icon;
		private Grid mainGrid;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChIconButton() : base()
		{
			Content = MainGrid;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChButtonBase Button
		{
			get
			{
				if (button != null) return button;

				button = new ChButtonBase();
				button.Clicked += Button_Clicked;

				return button;
			}
		}

		public ChIcon Icon
		{
			get
			{
				if (icon != null) return icon;

				icon = new ChIcon();

				return icon;
			}
		}

		private Grid MainGrid
		{
			get
			{
				if (mainGrid != null) return mainGrid;

				mainGrid = new Grid();
				mainGrid.Children.Add(Icon);
				mainGrid.Children.Add(Button);

				return mainGrid;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Button_Clicked(object sender, EventArgs e)
		{
			Button.IsSelected = !Button.IsSelected;
			Icon.IsSelected = !Icon.IsSelected;
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
