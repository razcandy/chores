using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public abstract class ThemeBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public virtual double IconDefaultOpacity { get; } = 1.0;
        public virtual double IconSelectedOpacity { get; } = 1.0;

        // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public abstract Color PrimaryColor { get; }
        public abstract Color PrimaryLightColor { get; }
        public abstract Color PrimaryDarkColor { get; }

        public abstract Color SecondaryColor { get; }
        public abstract Color SecondaryLightColor { get; }
        public abstract Color SecondaryDarkColor { get; }

        public abstract Color OnPrimaryColor { get; }
        public abstract Color OnSecondaryColor { get; }
        public abstract Color OnBackgroundColor { get; }
        public abstract Color OnSurfaceColor { get; }
        public abstract Color OnErrorColor { get; }

        public abstract Color BackgroundColor { get; }
        public abstract Color SurfaceColor { get; }
        public abstract Color ErrorColor { get; }

        public abstract Color DefaultTextColor { get; }

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~ Button Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected Style ButtonBaseStyle
		{
            get
			{
                return new Style(typeof(Button))
                {
                    Setters =
					{
                        new Setter { Property = Button.HeightRequestProperty, Value = ResourceHelper.DefaultButtonHeight },
                        new Setter { Property = Button.CornerRadiusProperty, Value = ResourceHelper.DefaultCornerRadius },
                        new Setter { Property = Button.FontFamilyProperty, Value = FontKeys.Roboto_Medium },
                        new Setter { Property = Button.FontSizeProperty, Value = 14 },
                    },
                };
			}
		}

        public Style ButtonContainedStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    BasedOn = ButtonBaseStyle,
                    Setters =
                    {
                        new Setter { Property = Button.BackgroundColorProperty, Value = PrimaryColor },
                        new Setter { Property = Button.TextColorProperty, Value = OnPrimaryColor },
                    },
                };
            }
        }

        public Style ButtonEmptyStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent },
                        new Setter { Property = Button.BorderColorProperty, Value = Color.Transparent },
                        new Setter { Property = Button.TextColorProperty, Value = Color.Transparent },
                    },
                };
            }
        }

        public Style ButtonOutlinedStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    BasedOn = ButtonBaseStyle,
                    Setters =
                    {
                        new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent },
                        new Setter { Property = Button.TextColorProperty, Value = PrimaryColor },
                        new Setter { Property = Button.BorderColorProperty, Value = PrimaryColor },
                    },
                };
            }
        }

        public Style ButtonTextStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    BasedOn = ButtonBaseStyle,
                    Setters =
                    {
                        new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent },
                        new Setter { Property = Button.TextColorProperty, Value = PrimaryColor },
                    },
                };
            }
        }

        //~~ Label Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Style LabelH1Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 96 },
                        new Setter { Property = Label.FontFamilyProperty, Value = FontKeys.Roboto_Light },
                    },
                };
            }
        }

        public Style LabelH2Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 60 },
                        new Setter { Property = Label.FontFamilyProperty, Value = FontKeys.Roboto_Light },
                    },
                };
            }
        }

        public Style LabelH3Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 48 },
                    },
                };
            }
        }

        public Style LabelH4Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 34 },
                    },
                };
            }
        }

        public Style LabelH5Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 24 },
                    },
                };
            }
        }

        public Style LabelH6Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontFamilyProperty, Value = FontKeys.Roboto_Medium },
                        new Setter { Property = Label.FontSizeProperty, Value = 20 },
                    },
                };
            }
        }

        public Style LabelSubtitle1Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 16 },
                    },
                };
            }
        }

        public Style LabelSubtitle2Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontFamilyProperty, Value = FontKeys.Roboto_Medium },
                        new Setter { Property = Label.FontSizeProperty, Value = 14 },
                    },
                };
            }
        }

        /// <summary>
        /// Larger font size than body 2
        /// </summary>
        public Style LabelBody1Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 16 },
                    },
                };
            }
        }

        /// <summary>
        /// Smaller font size than body 1
        /// </summary>
        public Style LabelBody2Style
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 14 },
                    },
                };
            }
        }

        public Style LabelCaptionStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 12 },
                    },
                };
            }
        }

        public Style LabelOverlineStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelDefaultStyle,
                    Setters =
                    {
                        new Setter { Property = Label.FontSizeProperty, Value = 10 },
                    },
                };
            }
        }

        public Style LabelWidgetTitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        public Style LabelWidgetSubtitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        public Style LabelWidgetSubSubtitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        //~~ Other Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public virtual Style FrameCardStyle
		{
            get
			{
                return new Style(typeof(Frame))
                {
                    BasedOn = FrameDefaultStyle,
                    Setters =
					{
                        new Setter { Property = Frame.BackgroundColorProperty, Value = SurfaceColor },
                    },
                };
			}
		}

        //~~ Default Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected Style LabelDefaultStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    ApplyToDerivedTypes = true,
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = DefaultTextColor },
						new Setter { Property = Label.FontFamilyProperty, Value = FontKeys.Roboto },
					},
                };
            }
        }

        protected Style PageDefaultStyle
        {
            get
            {
                return new Style(typeof(Page))
                {
                    ApplyToDerivedTypes = true,
                    Setters =
                    {
                        new Setter { Property = Page.BackgroundColorProperty, Value = BackgroundColor },
                    }
                };
            }
        }

        protected Style ButtonDefaultStyle
		{
            get
			{
                var defaultStyle = ButtonTextStyle;
                defaultStyle.ApplyToDerivedTypes = true;
                return defaultStyle;
			}
		}

        protected Style FrameDefaultStyle
		{
            get
			{
                return new Style(typeof(Frame))
                {
                    Setters =
					{
                        new Setter { Property = Frame.CornerRadiusProperty, Value = ResourceHelper.DefaultCornerRadius },
                        new Setter { Property = Frame.BackgroundColorProperty, Value = SurfaceColor },
                    },
                };
			}
		}

        protected Style ImageDefaultStyle
		{
            get
			{
                return new Style(typeof(Image))
                {
                    Setters =
					{
                        new Setter { Property = Image.AspectProperty, Value = Aspect.AspectFit },
					},
                };
			}
		}

        protected Style FieldIconStyle
		{
            get
			{
                return new Style(typeof(Image))
                {
                    Setters =
					{
                        new Setter { Property = Image.AspectProperty, Value = Aspect.AspectFit },
                    },
                };
			}
		}

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ResourceDictionary Load()
        {
            var rd = new ResourceDictionary();

            // Numbers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(IconDefaultOpacity), IconDefaultOpacity);
            rd.Add(nameof(IconSelectedOpacity), IconSelectedOpacity);

            // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(PrimaryColor), PrimaryColor);
            rd.Add(nameof(PrimaryLightColor), PrimaryLightColor);
            rd.Add(nameof(PrimaryDarkColor), PrimaryDarkColor);
            rd.Add(nameof(SecondaryColor), SecondaryColor);
            rd.Add(nameof(SecondaryLightColor), SecondaryLightColor);
            rd.Add(nameof(SecondaryDarkColor), SecondaryDarkColor);

            rd.Add(nameof(OnPrimaryColor), OnPrimaryColor);
            rd.Add(nameof(OnSecondaryColor), OnSecondaryColor);
            rd.Add(nameof(OnBackgroundColor), OnBackgroundColor);
            rd.Add(nameof(OnSurfaceColor), OnSurfaceColor);
            rd.Add(nameof(OnErrorColor), OnErrorColor);

            rd.Add(nameof(BackgroundColor), BackgroundColor);
            rd.Add(nameof(SurfaceColor), SurfaceColor);
            rd.Add(nameof(ErrorColor), ErrorColor);

            rd.Add(nameof(DefaultTextColor), DefaultTextColor);

            // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(LabelH1Style), LabelH1Style);
            rd.Add(nameof(LabelH2Style), LabelH2Style);
            rd.Add(nameof(LabelH3Style), LabelH3Style);
            rd.Add(nameof(LabelH4Style), LabelH4Style);
            rd.Add(nameof(LabelH5Style), LabelH5Style);
            rd.Add(nameof(LabelH6Style), LabelH6Style);
            rd.Add(nameof(LabelSubtitle1Style), LabelSubtitle1Style);
            rd.Add(nameof(LabelSubtitle2Style), LabelSubtitle2Style);
            rd.Add(nameof(LabelBody1Style), LabelBody1Style);
            rd.Add(nameof(LabelBody2Style), LabelBody2Style);
            rd.Add(nameof(LabelCaptionStyle), LabelCaptionStyle);
            rd.Add(nameof(LabelOverlineStyle), LabelOverlineStyle);

            rd.Add(nameof(ButtonContainedStyle), ButtonContainedStyle);
            rd.Add(nameof(ButtonEmptyStyle), ButtonEmptyStyle);
            rd.Add(nameof(ButtonOutlinedStyle), ButtonOutlinedStyle);
            rd.Add(nameof(ButtonTextStyle), ButtonTextStyle);

            rd.Add(nameof(FrameCardStyle), FrameCardStyle);

            // Default styles
            rd.Add(LabelDefaultStyle);
            rd.Add(PageDefaultStyle);
            rd.Add(ButtonDefaultStyle);
            rd.Add(FrameDefaultStyle);
            rd.Add(ImageDefaultStyle);

            return rd;
        }
    }
}
