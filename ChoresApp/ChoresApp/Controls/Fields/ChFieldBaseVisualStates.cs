using ChoresApp.Controls.Natives;
using ChoresApp.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Controls.Fields
{
	public static class ChFieldBaseVisualStates
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static Setter MakeSetter(BindableProperty _prop, object _value)
            => new Setter
            {
                Property = _prop,
                Value = _value,
            };

        public static VisualStateGroupList GetBackgroundFrameStates()
		{
            var group = new VisualStateGroup()
            {
                States =
                {
                    new VisualState
                    {
                        Name = ChFieldState.Inactive.ToString(),
                        Setters =
                        {
                            MakeSetter(Frame.BorderColorProperty, Color.DarkGray),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Activated.ToString(),
                        Setters =
                        {
                            MakeSetter(Frame.BorderColorProperty, Color.DarkGray),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Errored.ToString(),
                        Setters =
                        {
                            MakeSetter(Frame.BorderColorProperty, ResourceHelper.ErrorColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Focused.ToString(),
                        Setters =
                        {
                            MakeSetter(Frame.BorderColorProperty, ResourceHelper.PrimaryColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Disabled.ToString(),
                        Setters =
                        {
                            MakeSetter(VisualElement.OpacityProperty, 0.8),
                        },
                    },
                },
            };

            return new VisualStateGroupList { group };
        }

        public static VisualStateGroupList GetTitleLabelStates()
		{
            var group = new VisualStateGroup()
            {
                States =
                {
                    new VisualState
                    {
                        Name = ChFieldState.Inactive.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.DefaultTextColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Activated.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.DefaultTextColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Errored.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.ErrorColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Focused.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.PrimaryColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Disabled.ToString(),
                        Setters =
                        {
                            MakeSetter(VisualElement.OpacityProperty, 0.8),
                        },
                    },
                },
            };

            return new VisualStateGroupList { group };
        }

        public static VisualStateGroupList GetHelperTextLabelStates()
		{
            var group = new VisualStateGroup()
            {
                States =
                {
                    new VisualState
                    {
                        Name = ChFieldState.Inactive.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.DefaultTextColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Activated.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.DefaultTextColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Errored.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.ErrorColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Focused.ToString(),
                        Setters =
                        {
                            MakeSetter(XLabel.TextColorProperty, ResourceHelper.DefaultTextColor),
                        },
                    },
                    new VisualState
                    {
                        Name = ChFieldState.Disabled.ToString(),
                        Setters =
                        {
                            MakeSetter(VisualElement.OpacityProperty, 0.8),
                        },
                    },
                },
            };

            return new VisualStateGroupList { group };
        }
    }
}
