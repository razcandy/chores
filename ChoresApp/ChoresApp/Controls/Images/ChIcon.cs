using ChoresApp.Data.Messaging;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Images
{
	public class ChIcon : Image
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private string lightSource;
		private string lightSelectedSource;
		private string lightErroredSource;

		private string darkSource;
		private string darkSelectedSource;
		private string darkErroredSource;

		private string fileName;
		private string fileType;
		private ChImageSource iconSource;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChIcon() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public ChImageSource IconSource
		{
			get => iconSource;
			set
			{
				iconSource = value;
				ParseSource();
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
			//Source = ImageHelper.NotFound;
			IconSource = ImageHelper.NotFound;
			HeightRequest = ResourceHelper.DefaultIconSize;
			WidthRequest = ResourceHelper.DefaultIconSize;

			Messenger.Default.Register<ThemeChangedMessage>(this, OnThemeChanged);
		}

		private void ParseSource()
		{
			// check source valid
			// check dark theme version exists

			var sourceArray = IconSource.Source.Split('.');

			fileName = sourceArray[0];
			fileType = "." + sourceArray[1];

			if (Device.RuntimePlatform == Device.Android)
			{
				ParseSourceAndroid();
			}
			else if (Device.RuntimePlatform == Device.UWP)
			{
				ParseSourceUWP();
			}
		}

		private void ParseSourceAndroid()
		{
			lightSource = fileName + fileType;
			darkSource = lightSource;

			if (IconSource.SelectedExists)
			{
				lightSelectedSource = fileName + ImageHelper.SELECTED_KEY + fileType;
				darkSelectedSource = lightSelectedSource;
			}
			else
			{
				lightSelectedSource = lightSource;
				darkSelectedSource = lightSelectedSource;
			}

			if (IconSource.ErroredExists)
			{
				lightErroredSource = fileName + ImageHelper.ERRORED_KEY + fileType;
				darkErroredSource = lightErroredSource;
			}
			else
			{
				lightErroredSource = lightSource;
				darkErroredSource = lightErroredSource;
			}
		}

		private void ParseSourceUWP()
		{
			lightSource = fileName + fileType;
			darkSource = fileName + ImageHelper.DARKTHEME_KEY + fileType;

			if (IconSource.SelectedExists)
			{
				lightSelectedSource = fileName + ImageHelper.SELECTED_KEY + fileType;
				darkSelectedSource = fileName + ImageHelper.DARKTHEME_KEY + ImageHelper.SELECTED_KEY + fileType;
			}
			else
			{
				lightSelectedSource = lightSource;
				darkSelectedSource = darkSource;
			}

			if (IconSource.ErroredExists)
			{
				lightErroredSource = fileName + ImageHelper.ERRORED_KEY + fileType;
				darkErroredSource = fileName + ImageHelper.DARKTHEME_KEY + ImageHelper.ERRORED_KEY + fileType;
			}
			else
			{
				lightErroredSource = lightSource;
				darkErroredSource = darkSource;
			}
		}

		private void ResolveSource()
		{
			if (IsErrored)
			{
				Source = ResourceHelper.IsLightTheme() ? lightErroredSource : darkErroredSource;
			}
			else if (IsSelected)
			{
				Source = ResourceHelper.IsLightTheme() ? lightSelectedSource : darkSelectedSource;
			}
			else
			{
				Source = ResourceHelper.IsLightTheme() ? lightSource : darkSource;
			}
		}
	}
}
