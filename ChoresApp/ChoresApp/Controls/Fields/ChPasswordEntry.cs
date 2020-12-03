using ChoresApp.Helpers;
using System;

namespace ChoresApp.Controls.Fields
{
	public class ChPasswordEntry : ChEntry
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isPasswordVisible;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPasswordEntry() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void TrailingIcon_Tapped(object sender, EventArgs e)
		{
			if (isPasswordVisible)
			{
				TrailingIconSource = ImageHelper.Visibility;
				NativeEntry.IsPassword = true;
				
			}
			else
			{
				TrailingIconSource = ImageHelper.VisibilityOff;
				NativeEntry.IsPassword = false;
			}

			isPasswordVisible = !isPasswordVisible;
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
