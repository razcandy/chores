using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ChoresApp.Pages.Popups.Selection
{
	public class ChSelectPopupVM : ChPopupFloatingVM
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private ObservableCollection<ChSelectViewCellVM> itemSource = new ObservableCollection<ChSelectViewCellVM>();

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChSelectPopupVM() : base()
		{
			Test();
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public bool IsMultiselect { get; set; }

		public ObservableCollection<ChSelectViewCellVM> ItemSource
		{
			get => itemSource;
			private set
			{
				Set(ref itemSource, value);
			}
		}

		public Action<IEnumerable<ChSelectViewCellVM>> SelectionConfirmedAction;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void ItemIsSelectedChanged(object sender, bool e)
		{
			if (!(sender is ChSelectViewCellVM cellVM)) return;

			if (!IsMultiselect && cellVM.IsSelected)
			{
				ItemSource.Except(cellVM).ForEach(i =>
				{
					if (i.IsSelected) i.IsSelected = false;
				});
			}
		}

		public event EventHandler<IEnumerable<ChSelectViewCellVM>> SelectionConfirmed;

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			ItemSource.ForEach(i => i.IsSelectedChanged += ItemIsSelectedChanged);
		}

		private void Cleanup()
		{
			ItemSource.ForEach(i => i.IsSelectedChanged -= ItemIsSelectedChanged);
		}

		private void Test()
		{
			SecondaryButtonTransKey = Helpers.ButtonTransKeyEnum.Cancel;

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 0",
			});

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 1",
			});

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 2",
			});

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 3",
			});

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 4",
			});

			ItemSource.Add(new ChSelectViewCellVM
			{
				Title = "Rawr 5",
			});
		}

		protected override void PrimaryButtonAction()
		{
			var selected = ItemSource.Where(i => i.IsSelected);

			SelectionConfirmed?.Invoke(this, ItemSource.Where(i => i.IsSelected));
			SelectionConfirmedAction?.Invoke(selected);
		}
	}
}
