using ChoresApp.Controls.Buttons;
using ChoresApp.UWP.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ChImageButton), typeof(ChImageButtonCustomRenderer))]

namespace ChoresApp.UWP.CustomRenderers
{
	public class ChImageButtonCustomRenderer : ButtonRenderer
    {
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			//if (e.)

			var rawr = Control;

			;

			try
			{
				var customButton = (ChImageButton)e.NewElement;

				Control.Content = customButton.Icon;

				var stack = new Windows.UI.Xaml.Controls.StackPanel();

				var bit = new Windows.UI.Xaml.Media.Imaging.BitmapImage
				{
					UriSource = new Uri("/Assets/round_eco.png", UriKind.Absolute)
				};

				//{ms-appx:///Assets/round_eco.png}

				var img = new Windows.UI.Xaml.Controls.Image
				{
					Source = bit,
				};

				//var stack = (Windows.UI.Xaml.Controls.StackPanel)Control.Content;
			}
			catch (Exception ex)
			{
				;
			}
		}
	}
}
