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
		//private string primaryActionButtonText;
		private string switchButtonText = "Switch";
		private string switchLabelText;
		private string username;

		private bool inLoginMode = true;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LoginPageVM() : base() => Init();

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

		public string Password
		{
			get => password;
			//set => Set(ref password, value);
			set
			{
				Set(ref password, value);
				ValidatePassword();
			}
		}

		private string passwordHelperText;
		
		public string PasswordHelperText
		{
			get => passwordHelperText;
			private set => Set(ref passwordHelperText, value);
		}

		//public string PrimaryActionButtonText
		//{
		//	get => primaryActionButtonText;
		//	private set => Set(ref primaryActionButtonText, value);
		//}

		//private ButtonTransKeyEnum primaryActionTransKey = ButtonTransKeyEnum.LogIn;
		//public ButtonTransKeyEnum PrimaryActionTransKey
		//{
		//	get => primaryActionTransKey;
		//	private set => Set(ref primaryActionTransKey, value);
		//}

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
			if (inLoginMode)
			{

			}
			else
			{

			}

			Username = null;
			Password = null;

			inLoginMode = !inLoginMode;
			RaisePropertyChanged(nameof(PrimaryActionTransKey));
			RaisePropertyChanged(nameof(SwitchLabelText));
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
