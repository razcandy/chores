using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups
{
	public class ChPopupFloating : ChPopupBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Frame mainFrame;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupFloating() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected Frame MainFrame
		{
			get
			{
				if (mainFrame != null) return mainFrame;

				mainFrame = new Frame
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Margin = 20,
					//Padding = new Thickness(24, 8, 24, 8),
					Padding = 8,
					BackgroundColor = ResourceHelper.SurfaceColor,
				};

				return mainFrame;
			}
		}

		public new View Content
		{
			get => MainFrame.Content;
			set => MainFrame.Content = value;
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			base.Content = MainFrame;
		}
	}
}
