using ChoresApp.Controls.Buttons;
using ChoresApp.Data.Models;
using ChoresApp.Helpers;
using ChoresApp.Pages;
using ChoresApp.Pages.Test;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Debug
{
	public class DebugPage : ChContentPage
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ScrollView mainScroll;
		private StackLayout mainLayout;
		private ChButton button0;
		private ChButton button1;
		private ChButton button2;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public DebugPage() : base()
		{
			Content = MainScroll;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ScrollView MainScroll
		{
			get
			{
				if (mainScroll != null) return mainScroll;

				mainScroll = new ScrollView
				{
					Orientation = ScrollOrientation.Vertical,
					Content = MainLayout,
				};

				return mainScroll;
			}
		}

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
						Button0,
						Button1,
						Button2,
					},
				};

				return mainLayout;
			}
		}
		
		private ChButton Button0
		{
			get
			{
				if (button0 != null) return button0;

				button0 = new ChButton
				{
					HorizontalOptions = LayoutOptions.Center,
					Text = "Push here",
					Style = ResourceHelper.ButtonOutlinedStyle,
				};
				button0.Clicked += delegate
				{
					NavigationHelper.PushToCurrentStack(new TestPage());
				};

				return button0;
			}
		}

		private ChButton Button1
		{
			get
			{
				if (button1 != null) return button1;

				button1 = new ChButton
				{
					HorizontalOptions = LayoutOptions.Center,
					Text = "Push to 3",
					Style = ResourceHelper.ButtonOutlinedStyle,
				};
				button1.Clicked += delegate
				{
					NavigationHelper.PushToStack(NavStackEnum.Nav3, new TestPage());
				};

				return button1;
			}
		}

		private ChButton Button2
		{
			get
			{
				if (button2 != null) return button2;

				button2 = new ChButton
				{
					HorizontalOptions = LayoutOptions.Center,
					Text = "Upsert Doc",
					Style = ResourceHelper.ButtonOutlinedStyle,
				};
				button2.Clicked += delegate
				{
					var session = new SessionModel
					{
						Username = "razcandy",
					};

					ChDatabaseHelper.Upsert(session);
				};

				return button2;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
