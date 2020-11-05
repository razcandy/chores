﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public abstract class ThemeBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected const int DefaultCornerRadius = 3;

        protected abstract double IconDefaultOpacity { get; }
        protected abstract double IconSelectedOpacity { get; }

        // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        protected abstract Color PrimaryColor { get; }
        protected abstract Color PrimaryLightColor { get; }
        protected abstract Color PrimaryDarkColor { get; }

        protected abstract Color SecondaryColor { get; }
        protected abstract Color SecondaryLightColor { get; }
        protected abstract Color SecondaryDarkColor { get; }

        protected abstract Color OnPrimaryColor { get; }
        protected abstract Color OnSecondaryColor { get; }
        protected abstract Color OnBackgroundColor { get; }
        protected abstract Color OnSurfaceColor { get; }
        protected abstract Color OnErrorColor { get; }

        protected abstract Color BackgroundColor { get; }
        protected abstract Color SurfaceColor { get; }
        protected abstract Color ErrorColor { get; }

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected Style ButtonEmptyStyle
		{
            get
			{
                return new Style(typeof(Button))
                {
                    Setters =
					{
                        new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent },
                    },
                };
			}
		}

        protected Style LabelPageHeaderStyle
        {
            get
            {
                var sty = new Style(typeof(Label))
                {

                };

                return sty;
            }
        }

        protected Style LabelWidgetTitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        protected Style LabelWidgetSubtitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        protected Style LabelWidgetSubSubtitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        protected Style LabelParagraphStyle
        {
            get
            {
                return new Style(typeof(Label))
                {

                };
            }
        }

        protected Style LabelFieldHelperTextStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = OnSurfaceColor },
                        new Setter { Property = Label.FontSizeProperty, Value = 12 },
                        new Setter { Property = Label.OpacityProperty, Value = 0.5 },
                    },
                };
            }
        }

        protected Style ButtonFilledStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter { Property = Button.BackgroundColorProperty, Value = SecondaryColor },
                        new Setter { Property = Button.TextColorProperty, Value = OnSecondaryColor },
                        new Setter { Property = Button.CornerRadiusProperty, Value = DefaultCornerRadius },
                    }
                };
            }
        }
        
        protected virtual Style FrameCardStyle
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

        // Default Styles

        protected Style LabelDefaultStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = OnBackgroundColor },
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

        protected Style ButtonDefaultStyle => ButtonFilledStyle;

        protected Style FrameDefaultStyle
		{
            get
			{
                return new Style(typeof(Frame))
                {
                    Setters =
					{
                        new Setter { Property = Frame.CornerRadiusProperty, Value = DefaultCornerRadius },
                    },
                };
			}
		}

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ResourceDictionary Load()
        {
            var rd = new ResourceDictionary();

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

            // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(LabelPageHeaderStyle), LabelPageHeaderStyle);
            rd.Add(nameof(LabelFieldHelperTextStyle), LabelFieldHelperTextStyle);

            rd.Add(nameof(ButtonFilledStyle), ButtonFilledStyle);
            rd.Add(nameof(ButtonEmptyStyle), ButtonEmptyStyle);

            rd.Add(nameof(FrameCardStyle), FrameCardStyle);

            // Default styles
            rd.Add(LabelDefaultStyle);
            rd.Add(PageDefaultStyle);
            rd.Add(ButtonDefaultStyle);
            rd.Add(FrameDefaultStyle);

            return rd;
        }
    }
}
