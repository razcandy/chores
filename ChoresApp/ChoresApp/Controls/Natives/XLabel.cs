using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Natives
{
    /// <summary>
    /// Class to provide additional functionality through custom renderers for Label
    /// </summary>
	public class XLabel : Label
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public XLabel() : base() { }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Set FontFamily to bold/italic version instead
        /// </summary>
        [Obsolete]
        public new FontAttributes FontAttributes { get; set; }

        public Enum TranslationKey
        {
            get => (Enum)GetValue(TranslationKeyProperty);
            set => SetValue(TranslationKeyProperty, value);
        }

        public static readonly BindableProperty TranslationKeyProperty = BindableProperty.Create
        (
            propertyName: nameof(TranslationKey),
            returnType: typeof(Enum),
            declaringType: typeof(XLabel),
            defaultValue: null,
            propertyChanged: OnTranslationKeyPropertyChanged
        );

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void OnTranslationKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (XLabel)bindable;

            if (newValue is TitleTransKeyEnum titleKey)
			{
                label.Text = TranslationHelper.GetTranslationOrDefault(titleKey);
            }
            else if (newValue is MessageTransKeyEnum messageKey)
			{
                label.Text = TranslationHelper.GetTranslationOrDefault(messageKey);
            }
            else if (newValue == null)
			{
                label.Text = string.Empty;
			}
            else
			{
                string newValueString = null;

                try
				{
                    newValueString = (string)newValue;
                }
                catch (Exception e) { }

                LogHelper.LogWarning("Incorrect Enum type set", typeof(XLabel), newValueString);
			}
        }

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
