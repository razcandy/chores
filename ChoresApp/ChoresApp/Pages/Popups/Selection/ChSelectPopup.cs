using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectPopup<T> : ChPopupFloating
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private DataTemplate itemTemplate;
		private ListView selectView;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectPopup(ChSelectPopupVM<T> _vm) : base(_vm)
		{
			itemTemplate = new DataTemplate(() => new ChSelectViewCell<T>(_vm.IsMultiselect));

			if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
			{
				SelectView.WidthRequest = 300;
				SelectView.HeightRequest = 300;
				SelectView.HorizontalOptions = LayoutOptions.Center;
				SelectView.VerticalOptions = LayoutOptions.Center;
			}
			else
			{
				SelectView.VerticalOptions = LayoutOptions.Center;
			}

			Content = SelectView;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ListView SelectView
		{
			get
			{
				if (selectView != null) return selectView;

				selectView = new ListView
				{
					ItemTemplate = itemTemplate,
					SelectionMode = ListViewSelectionMode.None,
					HasUnevenRows = false,
				};
				selectView.SetBinding(ListView.ItemsSourceProperty, nameof(ChSelectPopupVM<T>.ItemSource));

				return selectView;
			}
		}

		protected override bool UseDividers => true;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	}
}
