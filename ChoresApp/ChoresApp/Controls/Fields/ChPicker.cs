using ChoresApp.Controls.Buttons;
using ChoresApp.Helpers;
using ChoresApp.Pages.Popups;
using ChoresApp.Pages.Popups.Selection;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChPicker<T> : ChFieldBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChButton pickerButton;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPicker() : base()
		{
			TrailingIconSource = ImageHelper.PickerArrow;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChButton PickerButton
		{
			get
			{
				if (pickerButton != null) return pickerButton;

				pickerButton = new ChButton
				{
					Style = ResourceHelper.ButtonEmptyStyle,
				};
				pickerButton.Clicked += PickerButton_Clicked;

				return pickerButton;
			}
		}

		protected override View NativeControl => PickerButton;
		protected override bool ShowBigTitleLabel => false;
		protected override bool ShowValueLabel => true;

		public Func<T, string> GetItemTitleFunc { get; set; } = (s) => "<title>";
		public bool IsMultiSelect { get; set; }

		public IList<T> ItemsSource
		{
			get => (IList<T>)GetValue(ItemsSourceProperty);
			set => SetValue(ItemsSourceProperty, value);
		}

		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create
		(
			propertyName: nameof(ItemsSource),
			returnType: typeof(IList<T>),
			declaringType: typeof(ChPicker<T>),
			defaultValue: null,
			defaultBindingMode: BindingMode.OneWay
		);

		public IList<T> SelectedItems
		{
			get => (IList<T>)GetValue(SelectedItemsProperty);
			set => SetValue(SelectedItemsProperty, value);
		}

		public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create
		(
			propertyName: nameof(SelectedItems),
			returnType: typeof(IList<T>),
			declaringType: typeof(ChPicker<T>),
			defaultValue: null,
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: SelectedItemsPropertyChanged
		);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void PickerButton_Clicked(object sender, EventArgs e)
		{
			NativeControlFocused();
			OpenPopup();
		}

		private void Popup_Disappearing(object sender, EventArgs e)
		{
			NativeControlUnfocused();
		}

		private static void SelectedItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var pick = (ChPicker<T>)bindable;
			pick.ResolveValueString();
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
			OpenPopup();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void OpenPopup()
		{
			var popupVM = new ChSelectPopupVM<T>(ItemsSource, SelectedItems, GetItemTitleFunc)
			{
				TitleTransKey = TitleTransKey,
				IsMultiselect = IsMultiSelect,
				SelectionConfirmedAction = SetSelected,
			};

			var popup = new ChSelectPopup<T>(popupVM);
			popup.Disappearing += Popup_Disappearing;

			NavigationHelper.PushPopup(popup);
		}

		private void ResolveValueString()
		{
			if (SelectedItems.HasItems())
			{
				ValueString = string.Join(", ", SelectedItems.Select(x => GetItemTitleFunc.Invoke(x)));
			}
			else
			{
				ValueString = string.Empty;
			}
		}

		private void SetSelected(IEnumerable<T> _selected)
		{
			if (_selected.IsNullOrEmpty())
			{
				SelectedItems = new List<T>();
			}
			else
			{
				SelectedItems = new List<T>(_selected);
			}
		}

		protected override void Cleanup()
		{
			base.Cleanup();

			pickerButton.Clicked -= PickerButton_Clicked;
		}
	}
}
