using Xamarin.Forms;

namespace ChoresApp.Controls
{
    public class TestCV : ContentView
    {
        private Grid mainGrid;

        public TestCV() : base()
        {
            Content = MainGrid;
        }

        private Grid MainGrid
        {
            get
            {
                if (mainGrid != null) return mainGrid;

                mainGrid = new Grid
                {
                    ColumnDefinitions =
                    {

                    },
                    ColumnSpacing = 8,
                };

                return mainGrid;
            }
        }
    }
}
