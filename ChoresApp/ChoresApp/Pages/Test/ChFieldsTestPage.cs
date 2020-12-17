using ChoresApp.Controls.Buttons;
using ChoresApp.Controls.Fields;
using ChoresApp.Helpers;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages.Test
{
	public class ChFieldsTestPage : ChContentPage
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private ChDatePicker datePicker;
        private ChEditor editor;
        private ChEntry entry;
        private ChPicker picker;
        private ChTimePicker timePicker;
        private Grid buttonGrid;

        private ChButton inactiveButton;
        private ChButton focusButton;
        private ChButton activatedButton;
        private ChButton errorButton;
        private ChButton disabledButton;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ChFieldsTestPage() : base()
		{
            var spacer = new BoxView
            {
                BackgroundColor = Color.Transparent,
                HeightRequest = 25,
            };

            var sl = new StackLayout
            {
                Spacing = 20,
                Orientation = StackOrientation.Vertical,
                Children =
				{
                    DatePicker,
                    Editor,
                    Entry,
                    Picker,
                    TimePicker,
                    spacer,
                    ButtonGrid,
                },
            };

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                Content = sl,
            };
		}

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private ChDatePicker DatePicker
		{
            get
			{
                if (datePicker != null) return datePicker;

                datePicker = new ChDatePicker
                {
                    Title = "Date Picker",
                    HelperText = "help me",
                };

                return datePicker;
            }
		}

        private ChEditor Editor
		{
            get
			{
                if (editor != null) return editor;

                editor = new ChEditor
                {
                    Title = "Editor",
                    HelperText = "help me",
                };

                return editor;
            }
		}

        private ChEntry Entry
		{
            get
			{
                if (entry != null) return entry;

                entry = new ChEntry
                {
                    Title = "Entry",
                    //HelperText = "help me",
                };

                return entry;
            }
		}

        private ChPicker Picker
		{
            get
			{
                if (picker != null) return picker;

                picker = new ChPicker
                {
                    Title = "Picker",
                    HelperText = "help me",
                };

                return picker;
            }
        }

        private ChTimePicker TimePicker
		{
            get
			{
                if (timePicker != null) return timePicker;

                timePicker = new ChTimePicker
                {
                    Title = "TimePicker",
                    HelperText = "help me",
                };

                return timePicker;
            }
		}

        private Grid ButtonGrid
		{
            get
			{
                if (buttonGrid != null) return buttonGrid;

                InitButtons();

                buttonGrid = new Grid
                {
                    ColumnDefinitions =
					{
                        UIHelper.MakeStarColumn(),
                        UIHelper.MakeStarColumn(),
                        UIHelper.MakeStarColumn(),
                    },
                    RowDefinitions =
					{
                        UIHelper.MakeStarRow(),
                        UIHelper.MakeStarRow(),
                        UIHelper.MakeStarRow(),
                    },
                };
                buttonGrid.Children.Add(inactiveButton, 0, 0);
                buttonGrid.Children.Add(focusButton, 1, 0);
                buttonGrid.Children.Add(activatedButton, 2, 0);
                buttonGrid.Children.Add(errorButton, 0, 1);
                buttonGrid.Children.Add(disabledButton, 1, 1);

                return buttonGrid;
            }
		}

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void InitButtons()
        {
            inactiveButton = new ChButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                Text = "Set Inactive",
                Command = new Command(SetInactive),
            };

            focusButton = new ChButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                Text = "Set Focused",
                Command = new Command(SetFocused),
            };

            activatedButton = new ChButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                Text = "Set Activated",
                Command = new Command(SetActivated),
            };

            errorButton = new ChButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                Text = "Set Errored",
                Command = new Command(SetErrored),
            };

            disabledButton = new ChButton
            {
                Style = ResourceHelper.ButtonContainedStyle,
                Text = "Set Disabled",
                Command = new Command(SetDisabled),
            };
        }

        private void SetInactive()
		{
            SetEnabled();
            //_SetErrored(false);
            SetStates(ChFieldState.Inactive);
        }

        private void SetFocused()
		{
            SetEnabled();
            //_SetErrored(false);
            SetStates(ChFieldState.Focused);
        }

        private void SetActivated()
		{
            SetEnabled();
            //_SetErrored(false);
            SetStates(ChFieldState.Activated);
        }

        private void SetErrored()
		{
            SetEnabled();
            //_SetErrored();
            SetStates(ChFieldState.Errored);
        }

        private void SetDisabled()
		{
            //_SetErrored(false);
            //SetEnabled(false);
            SetStates(ChFieldState.Disabled);
        }



        private void SetEnabled(bool _enabled = true)
		{
            DatePicker.IsEnabled = _enabled;
            Editor.IsEnabled = _enabled;
            Entry.IsEnabled = _enabled;
            Picker.IsEnabled = _enabled;
            TimePicker.IsEnabled = _enabled;
        }

        private void _SetErrored(bool _errored = true)
        {
            DatePicker.IsErrored = _errored;
            Editor.IsErrored = _errored;
            Entry.IsErrored = _errored;
            Picker.IsErrored = _errored;
            TimePicker.IsErrored = _errored;
        }

        private void SetStates(ChFieldState _state)
		{
            DatePicker.State = _state;
            Editor.State = _state;
            Entry.State = _state;
            Picker.State = _state;
            TimePicker.State = _state;
        }
    }
}
