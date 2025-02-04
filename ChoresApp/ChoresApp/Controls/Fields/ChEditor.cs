﻿using ChoresApp.Controls.Natives;
using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public class ChEditor : ChFieldBase
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private const double expandedMainContentHeight = 80;

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private XEditor nativeEditor;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChEditor() : base() => Init();

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private XEditor NativeEditor
		{
            get
			{
                if (nativeEditor != null) return nativeEditor;

                nativeEditor = new XEditor
                {
                    BindingContext = this,
                    BackgroundColor = Color.Transparent,
                };
                nativeEditor.SetBinding(Editor.TextProperty, nameof(Text), BindingMode.TwoWay);

				nativeEditor.Focused += NativeEditor_Focused;
				nativeEditor.Unfocused += NativeEditor_Unfocused;

                return nativeEditor;
            }
        }

		protected override View NativeControl => NativeEditor;

        public bool AutoSize
		{
            get => NativeEditor.AutoSize == EditorAutoSizeOption.TextChanges;
            set
			{
                if (value)
				{
                    NativeEditor.AutoSize = EditorAutoSizeOption.TextChanges;
                    MainContentRow.Height = new GridLength(1, GridUnitType.Auto);
                    TitleLabel.VerticalOptions = LayoutOptions.FillAndExpand;
                }
                else
				{
                    NativeEditor.AutoSize = EditorAutoSizeOption.Disabled;
                    MainContentRow.Height = expandedMainContentHeight;
                    TitleLabel.VerticalOptions = LayoutOptions.Start;
                }
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create
        (
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ChEditor),
            defaultValue: null,
            propertyChanged: OnTextPropertyChanged
        );

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void NativeEditor_Focused(object sender, FocusEventArgs e)
        {
            NativeControlFocused();
        }

        private void NativeEditor_Unfocused(object sender, FocusEventArgs e)
        {
            NativeControlUnfocused();
        }
        
        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var e = (ChEditor)bindable;
            e.ValueString = e.Text;
		}

		protected override void TouchCaptured(object sender, EventArgs e)
		{
            NativeEditor.Focus();
		}

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
            AutoSize = false;
        }

		protected override void Cleanup()
		{
			base.Cleanup();

            NativeEditor.Focused -= NativeEditor_Focused;
            NativeEditor.Unfocused -= NativeEditor_Unfocused;
        }
	}
}
