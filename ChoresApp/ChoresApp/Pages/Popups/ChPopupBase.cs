using ChoresApp.Helpers;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Popups
{
	public class ChPopupBase : PopupPage
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupBase() : base()
		{
			//BackgroundInputTransparent = false;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		protected override bool OnBackButtonPressed()
		{
			return base.OnBackButtonPressed();
		}

		/// <summary>
		/// Pop this popup
		/// </summary>
		/// <param name="_animate"></param>
		protected void Pop(bool _animate = true)
		{
			NavigationHelper.PopPopup(_animate);
		}
	}
}
