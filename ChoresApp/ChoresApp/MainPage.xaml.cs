using ChoresApp.Controls.Fields;
using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChoresApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var grr = new Entry();
            sl.Children.Add(grr);

            var rawr = new ChEntry();
            sl.Children.Add(rawr);

            var img = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageHelper.Test,
            };

            sl.Children.Add(img);
        }
    }
}
