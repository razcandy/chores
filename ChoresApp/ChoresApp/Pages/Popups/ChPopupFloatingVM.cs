using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Popups
{
	public class ChPopupFloatingVM : ChPopupVM
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private TitleTransKeyEnum subtitleTransKey;
		private TitleTransKeyEnum titleTransKey;
		private ButtonTransKeyEnum primaryButtonTransKey = ButtonTransKeyEnum.OK;
		private ButtonTransKeyEnum secondaryButtonTransKey;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChPopupFloatingVM() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public TitleTransKeyEnum SubtitleTransKey
		{
			get => subtitleTransKey;
			set => Set(ref subtitleTransKey, value);
		}

		public TitleTransKeyEnum TitleTransKey
		{
			get => titleTransKey;
			set => Set(ref titleTransKey, value);
		}

		public RelayCommand PrimaryButtonCommand { get; private set; }

		public ButtonTransKeyEnum PrimaryButtonTransKey
		{
			get => primaryButtonTransKey;
			set => Set(ref primaryButtonTransKey, value);
		}

		public RelayCommand SecondaryButtonCommand { get; private set; }

		public ButtonTransKeyEnum SecondaryButtonTransKey
		{
			get => secondaryButtonTransKey;
			set => Set(ref secondaryButtonTransKey, value);
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			PrimaryButtonCommand = new RelayCommand(PrimaryButtonAction);
			SecondaryButtonCommand = new RelayCommand(SecondaryButtonAction);
		}

		protected virtual void PrimaryButtonAction() { }
		protected virtual void SecondaryButtonAction() { }
	}
}
