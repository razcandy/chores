using ChoresApp.Data.Messaging;
using ChoresApp.Resources;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace ChoresApp.Controls.Images
{
	public class ChIcon : Image
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ChImageSource iconSource;
		private ChImageSource tempIconSource;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChIcon() => Init();

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

		public bool IsErrored
		{
			get => (bool)GetValue(IsErroredProperty);
			set => SetValue(IsErroredProperty, value);
		}

		public static readonly BindableProperty IsErroredProperty = BindableProperty.Create
		(
			propertyName: nameof(IsErrored),
			returnType: typeof(bool),
			declaringType: typeof(ChIcon),
			defaultValue: false,
			propertyChanged: OnIsErroredPropertyChanged
		);

		public bool IsSelected
		{
			get => (bool)GetValue(IsSelectedProperty);
			set => SetValue(IsSelectedProperty, value);
		}

		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create
		(
			propertyName: nameof(IsSelected),
			returnType: typeof(bool),
			declaringType: typeof(ChIcon),
			defaultValue: false,
			propertyChanged: OnIsSelectedPropertyChanged
		);

		public new ImageSource Source
		{
			get => base.Source;
			private set => base.Source = value;
		}

		public ChImageSource TempIconSource
		{
			get => tempIconSource;
			set
			{
				tempIconSource = value;
				ResolveSource();
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static void OnIsErroredPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((ChIcon)bindable).ResolveSource();
		}

		private static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			//var oldValueBool = (bool)oldValue;
			//var newValueBool = (bool)newValue;

			((ChIcon)bindable).ResolveSource();
		}
		
		private void OnThemeChanged(ThemeChangedMessage _message)
		{
			if (_message == null) return;

			ResolveSource();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			//IconSource = ImageHelper.NotFound;
			HeightRequest = ResourceHelper.DefaultIconSize;
			WidthRequest = ResourceHelper.DefaultIconSize;

			Messenger.Default.Register<ThemeChangedMessage>(this, OnThemeChanged);
		}

		private void ResolveSource()
		{
			if (IconSource == null && TempIconSource == null)
			{
				Source = null;
				return;
			}

			var currentSource = TempIconSource == null ? IconSource : TempIconSource;
			var isLightTheme = ResourceHelper.IsLightTheme();

			if (IsErrored)
			{
				Source = isLightTheme ? currentSource.LightErroredSource : currentSource.DarkErroredSource;
			}
			else if (IsSelected)
			{
				Source = isLightTheme ? currentSource.LightSelectedSource : currentSource.DarkSelectedSource;
			}
			else
			{
				Source = isLightTheme ? currentSource.LightSource : currentSource.DarkSource;
			}
		}
	}
}
