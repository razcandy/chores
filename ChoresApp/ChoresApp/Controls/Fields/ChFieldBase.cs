using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
    public abstract class ChFieldBase : ContentView
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static double iconSize => 24 * multiplier;
        //private static double iconSize = 24;
        private static double multiplier = 1;

        private static Color underlineDefaultColor = Color.DarkGray;
        private static Color accentColor = Color.Violet;
        private static Color defaultColor = Color.Black;

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid mainGrid;
        private Frame backgroundFrame;
        private Label helperTextLabel;
        private Image leadingIcon;
        private Label titleLabel;
        private Label titleLabelSmall;
        private BoxView underline;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChFieldBase()
        {
            Init();
            Test();
        }

        public ChFieldBase(ChFieldState _startingState)
        {

        }

        private void Init()
        {
            Content = MainGrid;
        }

        private void Test()
        {
            TitleLabel.Text = "Rawr";
            TitleLabelSmall.Text = "Rawr";
        }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private Grid MainGrid
        {
            get
            {
                if (mainGrid != null) return mainGrid;

                mainGrid = new Grid
                {
                    RowSpacing = 0,
                    ColumnSpacing = 0,
                };

                var numColumns = 5;
                var numRows = 5;
                bool useLeadingIcon = !string.IsNullOrEmpty(LeadingIconSource);

                mainGrid.ColumnDefinitions.Add(UIHelper.MakeStaticColomn(16 * multiplier)); // leading space
                mainGrid.ColumnDefinitions.Add(UIHelper.MakeStaticColomn(useLeadingIcon ? iconSize : 0)); // leading icon
                mainGrid.ColumnDefinitions.Add(UIHelper.MakeStarColumn()); // native field
                mainGrid.ColumnDefinitions.Add(UIHelper.MakeStaticColomn(iconSize)); // trailing icon
                mainGrid.ColumnDefinitions.Add(UIHelper.MakeStaticColomn(12 * multiplier)); // trailing space

                mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(8 * multiplier)); // top space
                mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(12 * multiplier)); // small title
                mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(20 * multiplier)); // native field
                mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(8 * multiplier)); // bottom space
                mainGrid.RowDefinitions.Add(UIHelper.MakeStaticRow(16 * multiplier)); // helper text

                // Children
                mainGrid.Children.Add(BackgroundFrame, 0, numColumns, 0, 4);

                if (useLeadingIcon)
                {
                    mainGrid.Children.Add(LeadingIcon, 1, 2, 1, 3);
                }

                mainGrid.Children.Add(TitleLabelSmall, 2, 3, 1, 2);
                mainGrid.Children.Add(NativeControl, 2, 3, 2, 3);
                mainGrid.Children.Add(TitleLabel, 2, 3, 1, 3);
                mainGrid.Children.Add(Underline, 0, numColumns, 3, 4);
                mainGrid.Children.Add(HelperTextLabel, 1, numColumns, numRows - 1, numRows);

                return mainGrid;
            }
        }

        private Frame BackgroundFrame
        {
            get
            {
                if (backgroundFrame != null) return backgroundFrame;

                backgroundFrame = new Frame
                {
                    BackgroundColor = Color.Gray,
                };

                return backgroundFrame;
            }
        }

        private Label HelperTextLabel
        {
            get
            {
                if (helperTextLabel != null) return helperTextLabel;

                helperTextLabel = new Label
                {
                    //HorizontalOptions = LayoutOptions.Start,
                    //HorizontalTextAlignment = TextAlignment.Start,
                    TextColor = Color.Purple,
                    FontSize = 12,
                    Text = "RAWR",
                    Padding = 0,
                };

                return helperTextLabel;
            }
        }

        private Image LeadingIcon
        {
            get
            {
                if (leadingIcon != null) return leadingIcon;

                leadingIcon = new Image
                {
                    Source = LeadingIconSource,
                    WidthRequest = iconSize,
                    HeightRequest = iconSize,
                    Aspect = Aspect.AspectFit,
                };

                return leadingIcon;
            }
        }

        private Label TitleLabel
        {
            get
            {
                if (titleLabel != null) return titleLabel;

                titleLabel = new Label
                {
                    //HorizontalOptions = LayoutOptions.Start,
                    //HorizontalTextAlignment = TextAlignment.Start,
                    TextColor = Color.White,
                    BackgroundColor = Color.Blue,
                    FontSize = 20,
                    InputTransparent = true,
                };

                return titleLabel;
            }
        }

        private Label TitleLabelSmall
        {
            get
            {
                if (titleLabelSmall != null) return titleLabelSmall;

                titleLabelSmall = new Label
                {
                    InputTransparent = true,
                    FontSize = 10,
                };

                return titleLabelSmall;
            }
        }

        private BoxView Underline
        {
            get
            {
                if (underline != null) return underline;
                underline = UIHelper.MakeHorizontalDivider();
                underline.BackgroundColor = underlineDefaultColor;
                underline.InputTransparent = true;
                return underline;
            }
        }

        protected virtual string LeadingIconSource => string.Empty;

        protected abstract View NativeControl { get; }

        protected string Value { get; set; }

        private ChFieldState state;

        public ChFieldState State
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state = value;
                    UpdateForState();
                }
            }
        }

        private bool isErrored;

        public bool IsErrored
        {
            get => isErrored;
            protected set => isErrored = value;
        }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void BoldUnderline(Color _color) => UpdateUnderline(2, _color);
        private void UnBoldUnderline() => UpdateUnderline(1, underlineDefaultColor);

        private void UpdateUnderline(double _height, Color _color)
		{
            if (Underline.Height != _height)
            {
                Underline.HeightRequest = _height;
            }

            if (Underline.BackgroundColor != _color)
            {
                Underline.BackgroundColor = _color;
            }
        }

        private void HideNativeField()
		{
            if (TitleLabel.IsVisible)
			{

			}
		}

        private void ShowNativeField()
		{

		}

        private void SetActive()
		{
            if (TitleLabel.IsVisible)
			{
                TitleLabel.IsVisible = false;
            }

            if (!TitleLabelSmall.IsVisible)
			{
                TitleLabelSmall.IsVisible = true;
            }

            //if (!NativeControl.IsVisible)
            //{
            //    NativeControl.IsVisible = true;
            //}
        }

        private void SetInactive()
		{
            if (TitleLabelSmall.IsVisible)
            {
                TitleLabelSmall.IsVisible = false;
            }

            //if (NativeControl.IsVisible)
            //{
            //    NativeControl.IsVisible = false;
            //}

            if (!TitleLabel.IsVisible)
            {
                TitleLabel.IsVisible = true;
            }
        }

        private void UpdateLabelColor(Color _color)
		{
            if (TitleLabel.TextColor != _color)
			{
                TitleLabel.TextColor = _color;
                TitleLabelSmall.TextColor = _color;
			}
		}

        

        protected void UpdateForState()
		{
			switch (State)
			{
                // not focused, but value is filled
				case ChFieldState.Activated:
                    OnActivated();
                    break;

				case ChFieldState.Errored:
                    OnErrored();
                    break;

				case ChFieldState.Focused:
                    OnFocused(); //?
                    break;
				
				case ChFieldState.Disabled:
                    OnDisabled();
                    break;

                case ChFieldState.Inactive:
                case ChFieldState.Hover: // to-do
                default:
                    OnInactivated();
                    break;
			}
		}

        protected virtual void OnInactivated()
		{
            UpdateLabelColor(defaultColor);
            HideNativeField();
            UnBoldUnderline();
        }

        protected virtual void OnActivated()
		{
            UpdateLabelColor(defaultColor);
            SetActive();
            BoldUnderline(underlineDefaultColor);
        }

        protected virtual void OnErrored()
		{
            UpdateLabelColor(Color.Red);
            //SetActive();
            BoldUnderline(Color.Red);
        }

        protected virtual void OnFocused()
        {
            if (State == ChFieldState.Errored) return;

            UpdateLabelColor(accentColor);
            SetActive();
            BoldUnderline(accentColor);

            //State = CHFieldState.Focused;
            state = ChFieldState.Focused;
        }

        protected virtual void OnUnFocused()
        {
            if (State == ChFieldState.Errored) return;

            UpdateLabelColor(defaultColor);

            if (string.IsNullOrEmpty(Value))
            {
                SetInactive();
            }

            UnBoldUnderline();
        }

        protected virtual void OnDisabled()
		{
            // think about disabled and empty & disabled and filled
            UnBoldUnderline();
        }
    }
}
