using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Buttons
{
	//public abstract class ChButtonBase : Button
	public class ChButtonBase : Button
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isSelectable;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChButtonBase() : base()
		{
			Init();
		}

		private void Init()
		{
			Clicked += OnThisClicked;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public bool IsSelectable
		{
			get => isSelectable;
			set
			{
				isSelectable = value;
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
			declaringType: typeof(ChButtonBase),
			defaultValue: false,
			propertyChanged: OnIsSelectedPropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			// do I need to check if the values are diff?

			((ChButtonBase)bindable).OnIsSelectedChanged();
		}

		private void OnThisClicked(object sender, EventArgs e)
		{
			if (IsSelectable)
			{
				IsSelected = !IsSelected;
				IsSelectedChanged?.Invoke(this, IsSelected);
			}
		}

		public event EventHandler<bool> IsSelectedChanged;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		protected virtual void OnIsSelectedChanged() { }

		protected void ToggleSelected()
		{
			IsSelected = !IsSelected;
		}
	}
}
