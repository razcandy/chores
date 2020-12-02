using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Controls.Fields
{
	public class ChPasswordEntry : ChEntry
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPasswordEntry() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void TrailingIcon_Tapped(object sender, EventArgs e)
		{
			if (TrailingIconSource == ImageHelper.Visibility)
			{
				TrailingIconSource = ImageHelper.VisibilityOff;
			}
			else
			{
				TrailingIconSource = ImageHelper.Visibility;
			}
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			NativeEntry.IsPassword = true;
			TrailingIcon.InputTransparent = false;
			TrailingIconSource = ImageHelper.Visibility;
		}
	}
}
