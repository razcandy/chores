using ChoresApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectViewCellVM : ChViewModelBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isSelected;
		private string title;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectViewCellVM() : base()
		{

		}
		
		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

		public string Title
		{
			get => title;
			set => Set(ref title, value);
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public event EventHandler<bool> IsSelectedChanged;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public void OnTapped()
		{
			IsSelected = !IsSelected;
		}
	}
}
