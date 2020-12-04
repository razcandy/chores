using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Login
{
	public class LandingPageVM : ChContentPageVM
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LandingPageVM() : base() => Init();

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public RelayCommand InfoCommand { get; private set; }
		public RelayCommand LoginCommand { get; private set; }
		public RelayCommand SignUpCommand { get; private set; }

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			InfoCommand = new RelayCommand(InfoAction);
			LoginCommand = new RelayCommand(LoginAction);
			SignUpCommand = new RelayCommand(SignUpAction);
		}

		private void InfoAction()
		{

		}

		private void LoginAction()
		{
			NavigationHelper.PushPage(new LoginPage(true));
		}

		private void SignUpAction()
		{
			NavigationHelper.PushPage(new LoginPage(false));
		}
	}
}
