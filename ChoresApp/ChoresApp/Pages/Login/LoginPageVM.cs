using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Login
{
	public class LoginPageVM : ChPageBaseVM
	{
		private static string needToLogin = "Have an account?";
		private static string needToSignup = "Don't have an account?";

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isPasswordErrored;
		private bool isUsernameErrored;
		private string password;
		private string passwordHelperText;
		private string switchButtonText = "Switch";
		private string switchLabelText;
		private string username;

		private bool inLoginMode = true;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LoginPageVM() : base() => Init();

		public LoginPageVM(bool _inLoginMode) : base()
		{
			inLoginMode = _inLoginMode;
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public RelayCommand InfoCommand { get; private set; }

		public bool IsPasswordErrored
		{
			get => isPasswordErrored;
			private set => Set(ref isPasswordErrored, value);
		}

		public bool IsUsernameErrored
		{
			get => isUsernameErrored;
			private set => Set(ref isUsernameErrored, value);
		}

		public string PageTitle => inLoginMode ? "Log In" : "Sign Up";

		public string Password
		{
			get => password;
			set
			{
				Set(ref password, value);
				ValidatePassword();
			}
		}

		public string PasswordHelperText
		{
			get => passwordHelperText;
			private set => Set(ref passwordHelperText, value);
		}

		public ButtonTransKeyEnum PrimaryActionTransKey
		{
			get => inLoginMode ? ButtonTransKeyEnum.LogIn : ButtonTransKeyEnum.SignUp;
		}

		public string SwitchButtonText
		{
			get => switchButtonText;
			private set
			{
				switchButtonText = value;
				RaisePropertyChanged();
			}
		}

		public string SwitchLabelText
		{
			get => inLoginMode ? needToSignup : needToLogin;
		}

		//public string SwitchLabelText
		//{
		//	get => switchLabelText;
		//	private set => Set(ref switchLabelText, value);
		//}

		public RelayCommand SwitchCommand { get; private set; }

		public string Username
		{
			get => username;
			set
			{
				Set(ref username, value);
				ValidateUsername();
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			InfoCommand = new RelayCommand(InfoAction);
			SwitchCommand = new RelayCommand(SwitchAction);
		}

		private void InfoAction()
		{

		}

		private void SwitchAction()
		{
			//Username = null;
			//Password = null;

			//inLoginMode = !inLoginMode;
			//RaisePropertyChanged(nameof(PrimaryActionTransKey));
			//RaisePropertyChanged(nameof(SwitchLabelText));
			//RaisePropertyChanged(nameof(PageTitle));

			NavigationHelper.PushPage(new LoginPage());
		}

		private void ValidatePassword()
		{
			var isErrored = false;

			if (Password != null && Password == string.Empty)
			{
				isErrored = true;
			}

			PasswordHelperText = isErrored ? "Invalid password" : null;

			IsPasswordErrored = isErrored;
		}

		private void ValidateUsername()
		{
			var isErrored = false;

			if (Username != null && Username == string.Empty)
			{
				isErrored = true;
			}

			IsUsernameErrored = isErrored;
		}
	}
}
