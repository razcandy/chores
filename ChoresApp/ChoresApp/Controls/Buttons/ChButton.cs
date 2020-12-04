using ChoresApp.Helpers;
using ChoresApp.Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public class ChButton : Button, ISelectable
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isSelectable;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChButton() : base() => Init();

		public ChButton(ButtonTransKeyEnum _transKey) : base()
		{
			TranslationKey = _transKey;
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public bool IsSelectable
		{
			get => isSelectable;
			set
			{
				isSelectable = value;

				if (!isSelectable)
				{
					IsSelected = false;
				}
			}
		}

		public bool IsSelected
		{
			get => (bool)GetValue(IsSelectedProperty);
			set => SetValue(IsSelectedProperty, value);
		}

		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create
		(
			propertyName: nameof(IsSelected),
			returnType: typeof(bool),
			declaringType: typeof(ChButton),
			defaultValue: false,
			propertyChanged: OnIsSelectedPropertyChanged
		);

		public ButtonTransKeyEnum TranslationKey
		{
			get => (ButtonTransKeyEnum)GetValue(TranslationKeyProperty);
			set => SetValue(TranslationKeyProperty, value);
		}

		public static readonly BindableProperty TranslationKeyProperty = BindableProperty.Create
		(
			propertyName: nameof(TranslationKey),
			returnType: typeof(ButtonTransKeyEnum),
			declaringType: typeof(ChButton),
			defaultValue: ButtonTransKeyEnum.EnumDefault,
			propertyChanged: OnTranslationKeyPropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var button = (ChButton)bindable;

			button.IsSelectedChanged?.Invoke(button, (bool)newValue);
		}

		private void OnThisClicked(object sender, EventArgs e)
		{
			if (IsSelectable)
			{
				IsSelected = !IsSelected;
				IsSelectedChanged?.Invoke(this, IsSelected);
			}
		}

		private static void OnTranslationKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var button = (ChButton)bindable;
			button.Text = TranslationHelper.GetTranslationOrDefault((ButtonTransKeyEnum)newValue);
		}

		public event EventHandler<bool> IsSelectedChanged;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			Clicked += OnThisClicked;
		}

		protected void ToggleSelected()
		{
			IsSelected = !IsSelected;
		}
	}
}
