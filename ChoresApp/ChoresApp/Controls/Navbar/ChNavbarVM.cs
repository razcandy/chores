using ChoresApp.Data;
using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Controls.Navbar
{
	public class ChNavbarVM : ChViewModelBase
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public ChNavbarVM() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public RelayCommand HomeCommand { get; private set; }
		public RelayCommand Nav1Command { get; private set; }
		public RelayCommand Nav2Command { get; private set; }
		public RelayCommand Nav3Command { get; private set; }
		public RelayCommand DebugCommand { get; private set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			HomeCommand = new RelayCommand(HomeAction);
			Nav1Command = new RelayCommand(Nav1Action);
			Nav2Command = new RelayCommand(Nav2Action);
			Nav3Command = new RelayCommand(Nav3Action);
			DebugCommand = new RelayCommand(DebugAction);
		}

		private void HomeAction()
		{
			NavigationHelper.NavToStack(NavStackEnum.Home);
		}

		private void Nav1Action()
		{
			NavigationHelper.NavToStack(NavStackEnum.Nav1);
		}

		private void Nav2Action()
		{
			NavigationHelper.NavToStack(NavStackEnum.Nav2);
		}

		private void Nav3Action()
		{
			NavigationHelper.NavToStack(NavStackEnum.Nav3);
		}

		private void DebugAction()
		{
			NavigationHelper.NavToStack(NavStackEnum.Debug);
		}
	}
}
