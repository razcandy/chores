using ChoresApp.Controls.Buttons;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using Xamarin.Forms;

namespace ChoresApp.Pages.Test
{
	public class TestPage : ChContentPage
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private StackLayout mainLayout;
		private BoxView box;
		private ChButtonBase backButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public TestPage() : base()
		{
			Content = MainLayout;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private StackLayout MainLayout
		{
			get
			{
				if (mainLayout != null) return mainLayout;

				mainLayout = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					Children =
					{
						Box,
						BackButton,
					},
				};

				return mainLayout;
			}
		}

		private BoxView Box
		{
			get
			{
				if (box != null) return box;

				box = new BoxView
				{
					WidthRequest = 100,
					HeightRequest = 100,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					BackgroundColor = UIHelper.RandomColor(),
				};

				return box;
			}
		}

		private ChButtonBase BackButton
		{
			get
			{
				if (backButton != null) return backButton;

				backButton = new ChButtonBase
				{
					Text = "BACK",
					HorizontalOptions = LayoutOptions.Center,
					Style = ResourceHelper.ButtonContainedStyle,
					VerticalOptions = LayoutOptions.Start,
				};
				backButton.Clicked += delegate
				{
					OnBackButtonPressed();
				};

				return backButton;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void OnRefresh()
		{
			Box.Color = UIHelper.RandomColor();
		}
	}
}
