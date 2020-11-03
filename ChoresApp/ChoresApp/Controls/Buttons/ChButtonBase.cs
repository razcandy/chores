using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public abstract class ChButtonBase : ContentView
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Grid mainGrid;
		private Button nativeButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChButtonBase() : base()
		{
			Init();
		}

		private void Init()
		{
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

				};

				mainGrid.Children.Add(MainContent, 0, 0);
				mainGrid.Children.Add(NativeButton, 0, 0);

				return mainGrid;
			}
		}

		protected abstract View MainContent { get; }

		protected Button NativeButton
		{
			get
			{
				if (nativeButton != null) return nativeButton;

				nativeButton = new Button
				{

				};
				nativeButton.Clicked += NativeButton_Clicked;

				return nativeButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void NativeButton_Clicked(object sender, EventArgs e)
		{
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		protected virtual void AnimateOnClick()
		{

		}
	}
}
