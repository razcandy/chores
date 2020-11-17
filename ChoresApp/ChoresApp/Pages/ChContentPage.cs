using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChoresApp.Pages
{
	public class ChContentPage : ContentView
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChContentPage() : base() => Init();

		public ChContentPage(View _content) : base()
		{
			Init();
			Content = _content;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public bool HasAppeared { get; private set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public event EventHandler Appearing;
		public event EventHandler Destructed;
		public event EventHandler Disappearing;
		public event EventHandler ReAppearing;
		public event EventHandler Refreshing;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			Padding = 10;
		}

		protected virtual void OnBackButtonPressed()
		{
			NavigationHelper.PopFromCurrentStack();
		}

		protected virtual void OnRefresh() { }

		public void Refresh()
		{
			Refreshing?.Invoke(this, EventArgs.Empty);
			OnRefresh();
		}

		public void SendAppearing()
		{
			if (HasAppeared)
			{
				ReAppearing?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				Appearing?.Invoke(this, EventArgs.Empty);
				HasAppeared = true;
			}
		}

		public void SendDestructed() => Destructed?.Invoke(this, EventArgs.Empty);
		public void SendDisappearing() => Disappearing?.Invoke(this, EventArgs.Empty);
		//public void SendReAppearing() => ReAppearing?.Invoke(this, EventArgs.Empty);
	}
}
