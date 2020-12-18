using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectPopup : ChPopupFloating
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private DataTemplate itemTemplate;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectPopup(ChSelectPopupVM _vm) : base(_vm)
		{
			if (_vm.IsMultiselect)
			{
				itemTemplate = new DataTemplate(() => new ChSelectViewCell(true));

			}
			else
			{
				itemTemplate = new DataTemplate(() => new ChSelectViewCell(false));
			}

			if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			{
				TestView.WidthRequest = 300;
				TestView.HeightRequest = 300;
				TestView.HorizontalOptions = LayoutOptions.Center;
				TestView.VerticalOptions = LayoutOptions.Center;
			}
			else
			{
				TestView.VerticalOptions = LayoutOptions.Center;
			}

			Content = TestView;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		private ListView testView;

		private ListView TestView
		{
			get
			{
				if (testView != null) return testView;

				testView = new ListView
				{
					//ItemTemplate = new DataTemplate(typeof(ChSelectViewCell)),
					ItemTemplate = itemTemplate,
					SelectionMode = ListViewSelectionMode.None,
					HasUnevenRows = false,
				};
				testView.SetBinding(ListView.ItemsSourceProperty, nameof(ChSelectPopupVM.ItemSource));

				return testView;
			}
		}

		protected override bool UseDividers => true;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
