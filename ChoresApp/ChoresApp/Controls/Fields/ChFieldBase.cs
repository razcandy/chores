using ChoresApp.Controls.Images;
using ChoresApp.Helpers;
using ChoresApp.Helpers.Converters;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
    public abstract class ChFieldBase : ContentView
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private const double iconSize = 24 * multiplier;
        private const double multiplier = 1;

        protected const double MainContentDefaultHeight = 28 * multiplier;
        //protected const int MainContentRowIndex = 2;

        private static Color underlineDefaultColor = Color.DarkGray;

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Grid mainGrid;
        private Frame backgroundFrame;
        private Label helperTextLabel;
        private RowDefinition mainContentRow;
        private ChFieldState state;
        private Label titleLabel;
        private Label titleLabelSmall;
        private ChIcon trailingIcon;
        private BoxView underline;
        private Label valueLabel;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChFieldBase()
        {
            Init();
            //Test();
        }

        public ChFieldBase(ChFieldState _startingState)
        {

        }

        private void Init()
        {
            Content = MainGrid;
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
                    RowDefinitions =
					{
                        UIHelper.MakeStaticRow(8 * multiplier), // top space
                        UIHelper.MakeStaticRow(8 * multiplier), // top space
                        MainContentRow, // main content
                        UIHelper.MakeStaticRow(16 * multiplier), // bottom space
                        UIHelper.MakeStaticRow(16 * multiplier), // helper text
                    },
                    ColumnDefinitions =
					{
                        UIHelper.MakeStaticColomn(16 * multiplier), // leading space
                        UIHelper.MakeStarColumn(), // native field
                        UIHelper.MakeAutoColumn(), // trailing icon
                        UIHelper.MakeStaticColomn(12 * multiplier), // trailing space
                    },
                };

                var numColumns = mainGrid.ColumnDefinitions.Count;
                var numRows = mainGrid.RowDefinitions.Count;

                // Children
                mainGrid.Children.Add(BackgroundFrame, 0, numColumns, 1, numRows - 1);
                mainGrid.Children.Add(TrailingIcon, 2, 3, 1, 4);
                mainGrid.Children.Add(TitleLabelSmall, 1, 2, 0, 2);
                mainGrid.Children.Add(NativeControl, 1, 2, 2, 3);
                mainGrid.Children.Add(TitleLabel, 1, 2, 1, 4);
                mainGrid.Children.Add(HelperTextLabel, 1, numColumns, numRows - 1, numRows);

                if (ShowValueLabel)
                {
                    mainGrid.Children.Add(ValueLabel, 1, 2, 2, 3);
                }

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
                    BackgroundColor = Color.Transparent,
                    BorderColor = underlineDefaultColor,
                    Padding = 0,
                    Margin = 0,
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
                    Style = ResourceHelper.LabelFieldHelperTextStyle,
                };

                return helperTextLabel;
            }
        }

        private Label TitleLabel
        {
            get
            {
                if (titleLabel != null) return titleLabel;

                titleLabel = new Label
                {
					BindingContext = this,
					FontSize = 20,
                    InputTransparent = true,
                };
                titleLabel.SetBinding(Label.TextProperty, nameof(Title));

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
					BindingContext = this,
                    InputTransparent = true,
                    FontSize = 10,
                    BackgroundColor = ResourceHelper.SurfaceColor,
                    VerticalOptions = LayoutOptions.Start,
                    VerticalTextAlignment = TextAlignment.Center,

                    HorizontalOptions = LayoutOptions.Start,
                    Padding = new Thickness(4, 0, 4, 0),

                    IsVisible = false,
                };
                titleLabelSmall.SetBinding(Label.TextProperty, nameof(Title));

                return titleLabelSmall;
            }
        }

        private ChIcon TrailingIcon
        {
            get
            {
                if (trailingIcon != null) return trailingIcon;

                trailingIcon = new ChIcon
                {
                    Margin = new Thickness(8, 0, 0, 0),
                    WidthRequest = iconSize,
                    VerticalOptions = LayoutOptions.Center,
                };

				trailingIcon.SetBinding(ChIcon.IsVisibleProperty, new Binding(nameof(Image.Source), source: TrailingIcon,
					converter: InlineConverter<ImageSource, bool>.Select(x =>
					{
                        return x == null ? false : !x.IsEmpty;
					})));

                return trailingIcon;
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

        protected RowDefinition MainContentRow
        {
            get
            {
                if (mainContentRow != null) return mainContentRow;
                mainContentRow = UIHelper.MakeStaticRow(MainContentDefaultHeight);
                return mainContentRow;
            }
        }

        protected abstract View NativeControl { get; }

        protected virtual bool ShowValueLabel => false;

        /// <summary>
        /// Label to be used if the natived control is hidden
        /// </summary>
        protected Label ValueLabel
		{
            get
			{
                if (valueLabel != null) return valueLabel;

                valueLabel = new Label
                {
                    BindingContext = this,
                    FontSize = 20,
                    InputTransparent = true,
                    VerticalOptions = LayoutOptions.End,
                    VerticalTextAlignment = TextAlignment.End,
                };

                return valueLabel;
            }
		}

        protected string ValueString { get; set; } // make abstract

        public bool IsErrored
        {
            get => (bool)GetValue(IsErroredProperty);
            set => SetValue(IsErroredProperty, value);
        }

        public static readonly BindableProperty IsErroredProperty = BindableProperty.Create
        (
            propertyName: nameof(IsErrored),
            returnType: typeof(bool),
            declaringType: typeof(ChFieldBase),
            defaultValue: false,
            propertyChanged: OnIsErroredPropertyChanged
        );

        public bool IsValidated
        {
            get => (bool)GetValue(IsValidatedProperty);
            set => SetValue(IsValidatedProperty, value);
        }

        public static readonly BindableProperty IsValidatedProperty = BindableProperty.Create
        (
            propertyName: nameof(IsValidated),
            returnType: typeof(bool),
            declaringType: typeof(ChFieldBase),
            defaultValue: false,
            propertyChanged: IsValidatedPropertyChanged
        );

        public string HelperText
        {
            get => (string)GetValue(HelperTextProperty);
            set => SetValue(HelperTextProperty, value);
        }

        public static readonly BindableProperty HelperTextProperty = BindableProperty.Create
        (
            propertyName: nameof(HelperText),
            returnType: typeof(string),
            declaringType: typeof(ChFieldBase),
            defaultValue: null
        );

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

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create
        (
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(ChFieldBase),
            defaultValue: null
        );

        public ChImageSource TrailingIconSource
		{
            get => TrailingIcon.IconSource;
            set => TrailingIcon.IconSource = value;
		}

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void OnIsErroredPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var field = (ChFieldBase)bindable;
            var newValueBool = (bool)newValue;
            field.ResolveTrailingIconSources();

            if (newValueBool)
            {
                field.State = ChFieldState.Errored;
            }
            else if (field.ValueString.IsNullOrEmpty())
			{
                field.State = ChFieldState.Inactive;
			}
            else
			{
                field.State = ChFieldState.Activated;
			}
		}

        private static void IsValidatedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ChFieldBase)bindable).ResolveTrailingIconSources();
        }

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void BoldUnderline(Color _color) => UpdateUnderline(2, _color);
        private void UnBoldUnderline() => UpdateUnderline(1, underlineDefaultColor);

  //      private void UpdateUnderline(double _height, Color _color)
		//{
  //          if (Underline.Height != _height)
  //          {
  //              Underline.HeightRequest = _height;
  //          }

  //          if (Underline.BackgroundColor != _color)
  //          {
  //              Underline.BackgroundColor = _color;
  //          }
  //      }

        private void UpdateUnderline(double _height, Color _color)
		{
            // to do - add a border width prop
            BackgroundFrame.BorderColor = _color;
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

        private void ResolveTrailingIconSources()
		{
            if (IsErrored)
			{
                TrailingIcon.TempIconSource = ImageHelper.Error;
            }
            else if (IsValidated)
			{
                TrailingIcon.TempIconSource = ImageHelper.Check;
            }
            else if (TrailingIcon.TempIconSource != null)
			{
                TrailingIcon.TempIconSource = null;
            }
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
            UpdateLabelColor(ResourceHelper.DefaultTextColor);
            HideNativeField();
            UnBoldUnderline();
        }

        protected virtual void OnActivated()
		{
            UpdateLabelColor(ResourceHelper.PrimaryColor);
            SetActive();
            BoldUnderline(ResourceHelper.PrimaryColor);
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

            UpdateLabelColor(ResourceHelper.PrimaryColor);
            SetActive();
            BoldUnderline(ResourceHelper.PrimaryColor);

            //State = CHFieldState.Focused;
            state = ChFieldState.Focused;
        }

        protected virtual void OnUnFocused()
        {
            if (State == ChFieldState.Errored) return;

            UpdateLabelColor(ResourceHelper.DefaultTextColor);

            if (string.IsNullOrEmpty(ValueString))
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
