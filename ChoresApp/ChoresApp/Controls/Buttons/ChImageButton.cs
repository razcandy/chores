using ChoresApp.Controls.Images;
using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public class ChImageButton : ChButtonBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ImageSource selectedSource;
		private ImageSource unselectedSourceCache;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChImageButton() : base()
		{
			BackgroundColor = Color.Transparent;

			Clicked += OnClicked;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		//private Image tmpImage;

		//protected override View MainContent => tmpImage;

		private Image icon;

		public Image Icon
		{
			get
			{
				if (icon != null) return icon;

				icon = new Image
				{
					Aspect = Aspect.AspectFit,
					Source = ImageHelper.Eco,
				};

				return icon;
			}
		}

		public ImageSource SelectedSource
		{
			get => selectedSource;
			set
			{
				if (selectedSource != value)
				{
					selectedSource = value;
				}
			}
		}


		private ChImageSource chImageSource;

		public ChImageSource ChImageSource
		{
			get => chImageSource;
			set
			{
				if (value != null)
				{
					chImageSource = value;

					ImageSource = chImageSource;
					//SelectedSource = chImageSource./*sele*/
				}
			}
		}


		/// <summary>
		/// Hide the text property, so it can't be set externally
		/// </summary>
		public new string Text { get; set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void OnClicked(object sender, EventArgs e)
		{
			ToggleSelected();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected override void OnIsSelectedChanged()
		{
			if (ImageSource != null && SelectedSource != null)
			{
				if (IsSelected)
				{
					unselectedSourceCache = ImageSource;
					ImageSource = SelectedSource;
				}
				else
				{
					ImageSource = unselectedSourceCache;
					unselectedSourceCache = null;
				}
			}
		}
	}
}
