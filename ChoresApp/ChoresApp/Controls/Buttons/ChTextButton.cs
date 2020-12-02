using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public class ChTextButton : ChButtonBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChTextButton() : base() => Init();

		public ChTextButton(ButtonTransKeyEnum _transKey) : base()
		{
			TranslationKey = _transKey;
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ButtonTransKeyEnum TranslationKey
		{
			get => (ButtonTransKeyEnum)GetValue(TranslationKeyProperty);
			set => SetValue(TranslationKeyProperty, value);
		}

		public static readonly BindableProperty TranslationKeyProperty = BindableProperty.Create
		(
			propertyName: nameof(TranslationKey),
			returnType: typeof(ButtonTransKeyEnum),
			declaringType: typeof(ChTextButton),
			defaultValue: ButtonTransKeyEnum.EnumDefault,
			propertyChanged: OnTranslationKeyPropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnTranslationKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var button = (ChTextButton)bindable;
			button.Text = TranslationHelper.GetTranslationOrDefault((ButtonTransKeyEnum)newValue);
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
		}
	}
}
