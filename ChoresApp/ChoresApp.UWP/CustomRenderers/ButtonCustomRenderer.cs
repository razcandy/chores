using ChoresApp.UWP.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonCustomRenderer))]

namespace ChoresApp.UWP.CustomRenderers
{
	public class ButtonCustomRenderer : ButtonRenderer
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
				var stack = (Windows.UI.Xaml.Controls.StackPanel)Control.Content;

				var img = (Windows.UI.Xaml.Controls.Image)stack.Children[1];

				//img.Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill;

				//img.Height = 5;

				//img.Source = null;
			}
			catch (Exception ex)
			{
				;
			}

			try
			{
				var img = (Windows.UI.Xaml.Controls.Image)Control.Content;

				img.Height = 100;

				;
			}
			catch (Exception ex)
			{
				;
			}

		}
	}
}
