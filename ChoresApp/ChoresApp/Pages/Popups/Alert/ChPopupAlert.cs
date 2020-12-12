using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using Xamarin.Forms;

namespace ChoresApp.Pages.Popups.Alert
{
	public class ChPopupAlert : ChPopupFloating
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private XLabel messageLabel;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupAlert(ChPopupAlertVM _vm) : base(_vm)
		{
			Init();
		}

		public ChPopupAlert(MessageTransKeyEnum _translationKey) : base()
		{
			BindingContext = new ChPopupAlertVM
			{
				MessageTransKey = _translationKey,
			};
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private XLabel MessageLabel
		{
			get
			{
				if (messageLabel != null) return messageLabel;

				messageLabel = new XLabel
				{
					Style = ResourceHelper.LabelBody2Style,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Opacity = 0.9,
					Padding = new Thickness(24-MainFramePadding, 0, 24-MainFramePadding, 0),
				};
				messageLabel.SetBinding(XLabel.TranslationKeyProperty, nameof(ChPopupAlertVM.MessageTransKey));

				return messageLabel;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			Content = MessageLabel;
		}
	}
}
