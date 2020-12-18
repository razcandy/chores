using ChoresApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectViewCellVM<T> : ChViewModelBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isSelected;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectViewCellVM(T _data, Func<T, string> _getTitleFunc)
		{
			Data = _data;
			GetTitleFunc = _getTitleFunc ?? GetTitleFallback;
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public T Data { get; private set; }

		public Func<T, string> GetTitleFunc { get; private set; }

		public bool IsSelected
		{
			get => isSelected;
			set
			{
				if (value != isSelected)
				{
					Set(ref isSelected, value);
					IsSelectedChanged?.Invoke(this, isSelected);
				}
			}
		}

		public string Title => GetTitleFunc?.Invoke(Data);

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public event EventHandler<bool> IsSelectedChanged;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static string GetTitleFallback(T _data) => "<title>";

		public void OnTapped()
		{
			IsSelected = !IsSelected;
		}
	}
}
