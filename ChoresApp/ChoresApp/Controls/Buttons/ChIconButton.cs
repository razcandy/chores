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
		private bool isSelectable;

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

				icon = new ChIcon
				{
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};

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

		public bool IsSelectable
		{
			get => isSelectable;
			set
			{
				if (isSelectable == value) return;

				isSelectable = value;
				Button.IsSelectable = true;

				Button.IsSelectedChanged -= Button_IsSelectedChanged;

				if (isSelectable)
				{
					Button.IsSelectedChanged += Button_IsSelectedChanged;
				}
			}
		}

		public ChImageSource IconSource
		{
			get => Icon.IconSource;
			set => Icon.IconSource = value;
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Button_Clicked(object sender, EventArgs e)
		{
			Clicked?.Invoke(this, e);
		}

		private void Button_IsSelectedChanged(object sender, bool e)
		{
			Icon.IsSelected = e;
		}

		public event EventHandler Clicked;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
