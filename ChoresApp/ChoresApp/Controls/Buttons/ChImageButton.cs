using ChoresApp.Controls.Images;
using ChoresApp.Resources;
using ChoresApp.Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	public class ChImageButton : ImageButton, ISelectable
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChImageSource iconSource;
		private bool isSelectable;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChImageButton() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChImageSource IconSource
		{
			get => iconSource;
			set
			{
				iconSource = value;
				ResolveSource();
			}
		}

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
			declaringType: typeof(ChImageButton),
			defaultValue: false,
			propertyChanged: OnIsSelectedPropertyChanged
		);

		protected virtual bool ToggleIsSelectedOnClick => true;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var button = (ChImageButton)bindable;

			button.IsSelectedChanged?.Invoke(button, (bool)newValue);
			button.ResolveSource();
		}

		private void OnThisClicked(object sender, EventArgs e)
		{
			if (IsSelectable && ToggleIsSelectedOnClick)
			{
				IsSelected = !IsSelected;
				IsSelectedChanged?.Invoke(this, IsSelected);
			}
		}

		public event EventHandler<bool> IsSelectedChanged;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			Aspect = Aspect.AspectFit;
			Clicked += OnThisClicked;
		}

		private void ResolveSource()
		{
			if (IconSource == null)
			{
				Source = null;
			}

			if (ResourceHelper.IsLightTheme())
			{
				if (IsSelected)
				{
					Source = IconSource.LightSelectedSource;
				}
				else
				{
					Source = IconSource.LightSource;
				}
			}
			else
			{
				if (IsSelected)
				{
					Source = IconSource.DarkSelectedSource;
				}
				else
				{
					Source = IconSource.DarkSource;
				}
			}
		}
	}
}
