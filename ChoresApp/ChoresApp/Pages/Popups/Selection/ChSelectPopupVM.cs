using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectPopupVM<T> : ChPopupFloatingVM 
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ObservableCollection<ChSelectViewCellVM<T>> itemSource = new ObservableCollection<ChSelectViewCellVM<T>>();

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectPopupVM(IEnumerable<T> _dataSource, IEnumerable<T> _selectedItems,
			Func<T, string> _getItemTitleFunc) : base()
		{
			GetItemTitleFunc = _getItemTitleFunc;

			if (_dataSource.HasItems())
			{
				var vms = _dataSource.Select(x => new ChSelectViewCellVM<T>(x, GetItemTitleFunc));
				ItemSource = new ObservableCollection<ChSelectViewCellVM<T>>(vms);

				if (_selectedItems.HasItems())
				{
					ItemSource.ForEach(i => {
						if (_selectedItems.Contains(i.Data))
						{
							i.IsSelected = true;
						}
					});
				}
			}

			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public Func<T, string> GetItemTitleFunc { get; private set; }

		public bool IsMultiselect { get; set; }

		public ObservableCollection<ChSelectViewCellVM<T>> ItemSource
		{
			get => itemSource;
			private set => Set(ref itemSource, value);
		}

		public Action<IEnumerable<T>> SelectionConfirmedAction;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void ItemIsSelectedChanged(object sender, bool e)
		{
			if (!(sender is ChSelectViewCellVM<T> cellVM)) return;

			if (!IsMultiselect && cellVM.IsSelected)
			{
				ItemSource.Except(cellVM).ForEach(i =>
				{
					if (i.IsSelected) i.IsSelected = false;
				});
			}
		}

		public event EventHandler<IEnumerable<T>> SelectionConfirmed;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			ItemSource.ForEach(i => i.IsSelectedChanged += ItemIsSelectedChanged);
			SecondaryButtonTransKey = Helpers.ButtonTransKeyEnum.Cancel;
		}

		private void Cleanup()
		{
			ItemSource.ForEach(i => i.IsSelectedChanged -= ItemIsSelectedChanged);
		}

		protected override void PrimaryButtonAction()
		{
			var selected = ItemSource.Where(i => i.IsSelected)?.Select(i => i.Data)
				?? new List<T>();

			SelectionConfirmed?.Invoke(this, selected);
			SelectionConfirmedAction?.Invoke(selected);
		}
	}
}
