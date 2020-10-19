using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Resources
{
    public abstract class ThemeBase
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected abstract Color PrimaryColor { get; }
        protected abstract Color PrimaryLightColor { get; }
        protected abstract Color PrimaryDarkColor { get; }

        protected abstract Color SecondaryColor { get; }
        protected abstract Color SecondaryLightColor { get; }
        protected abstract Color SecondaryDarkColor { get; }

        protected abstract Color PrimaryTextColor { get; }
        protected abstract Color PrimaryTextOnLightColor { get; }
        protected abstract Color PrimaryTextOnDarkColor { get; }

        protected abstract Color SecondaryTextColor { get; }
        protected abstract Color SecondaryTextOnLightColor { get; }
        protected abstract Color SecondaryTextOnDarkColor { get; }

        protected virtual Color ErrorTextColor => Color.FromHex("#FF0000");

        // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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

        protected Style LabelButtonFilledStyle
		{
            get
            {

                return new Style(typeof(Label))
                {

                };
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
                        new Setter { Property = Label.TextColorProperty, Value = PrimaryTextColor },
                        new Setter { Property = Label.FontSizeProperty, Value = 12 },
                        new Setter { Property = Label.OpacityProperty, Value = 0.5 },
					},
                };
            }
        }

        protected Style LabelDefaultStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = PrimaryTextColor },
                    },
                };
            }
        }

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //public virtual ResourceDictionary Load()
        public ResourceDictionary Load()
        {
            var rd = new ResourceDictionary();

            // Colors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(PrimaryTextColor), PrimaryTextColor);

            rd.Add(nameof(PrimaryColor), PrimaryColor);
            rd.Add(nameof(PrimaryLightColor), PrimaryLightColor);
            rd.Add(nameof(PrimaryDarkColor), PrimaryDarkColor);
            rd.Add(nameof(SecondaryColor), SecondaryColor);
            rd.Add(nameof(SecondaryLightColor), SecondaryLightColor);
            rd.Add(nameof(SecondaryDarkColor), SecondaryDarkColor);

            // Styles ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            rd.Add(nameof(LabelPageHeaderStyle), LabelPageHeaderStyle);
            rd.Add(nameof(LabelButtonFilledStyle), LabelButtonFilledStyle);

            rd.Add(nameof(LabelFieldHelperTextStyle), LabelFieldHelperTextStyle);

            rd.Add(LabelDefaultStyle);

            return rd;
        }

    }
}
