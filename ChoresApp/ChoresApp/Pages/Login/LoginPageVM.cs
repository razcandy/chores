using ChoresApp.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Pages.Login
{
	public class LoginPageVM : ChPageBaseVM
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private bool isLoginMode = true;
		private bool isNameErrored;
		private bool isPasswordErrored;
		private bool isPrimaryActionEnabled;
		private bool isUsernameErrored;
		private string name;
		private string password;
		private string passwordHelperText;
		private string username;

		// Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public LoginPageVM() : base() => Init();

		public LoginPageVM(bool _inLoginMode) : base()
		{
			isLoginMode = _inLoginMode;
			Init();
		}

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		public RelayCommand BackCommand { get; private set; }

		public bool IsLoginMode
		{
			get => isLoginMode;
			set
			{
				if (isLoginMode != value)
				{
					Set(ref isLoginMode, value);
				}
			}
		}

		public bool IsNameErrored
		{
			get => isNameErrored;
			private set => Set(ref isNameErrored, value);
		}

		public bool IsPasswordErrored
		{
			get => isPasswordErrored;
			private set => Set(ref isPasswordErrored, value);
		}

		public bool IsPrimaryActionEnabled
		{
			get => isPrimaryActionEnabled;
			private set
			{
				if (isPrimaryActionEnabled != value)
				{
					Set(ref isPrimaryActionEnabled, value);
				}
			}
		}

		public bool IsUsernameErrored
		{
			get => isUsernameErrored;
			private set => Set(ref isUsernameErrored, value);
		}

		public string Name
		{
			get => name;
			set
			{
				Set(ref name, value);
				ValidateName();
			}
		}

		public TitleTransKeyEnum PageTitleTransKey
			=> IsLoginMode ? TitleTransKeyEnum.LogIn : TitleTransKeyEnum.SignUp;

		public string Password
		{
			get => password;
			set
			{
				Set(ref password, value);
				ValidatePassword();
				ResolveIsPrimaryActionEnabled();
			}
		}

		public string PasswordHelperText
		{
			get => passwordHelperText;
			private set => Set(ref passwordHelperText, value);
		}

		public ButtonTransKeyEnum PrimaryActionTransKey
		{
			get => IsLoginMode ? ButtonTransKeyEnum.LogIn : ButtonTransKeyEnum.SignUp;
		}

		public ButtonTransKeyEnum SwitchButtonTransKey
		{
			get => IsLoginMode ? ButtonTransKeyEnum.SignUp : ButtonTransKeyEnum.LogIn;
		}

		public MessageTransKeyEnum SwitchLabelTransKey
		{
			get => IsLoginMode ? MessageTransKeyEnum.NeedToSignUp : MessageTransKeyEnum.NeedToLogin;
		}

		public RelayCommand SwitchCommand { get; private set; }

		public string Username
		{
			get => username;
			set
			{
				Set(ref username, value);
				ValidateUsername();
				ResolveIsPrimaryActionEnabled();
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			BackCommand = new RelayCommand(Back);
			SwitchCommand = new RelayCommand(SwitchAction);
		}

		private void Back()
		{

		}

		private void ResolveIsPrimaryActionEnabled()
		{
			//if (IsLoginMode)
			//{
			//	IsPrimaryActionEnabled = !IsUsernameErrored && !IsPasswordErrored
			//		&& Username != null && Password != null;
			//}
			//else
			//{
			//	IsPrimaryActionEnabled = !IsUsernameErrored && !IsPasswordErrored
			//		&& Username != null && Password != null
			//		&& !IsNameErrored && Name != null;
			//}

			var isEnabled = !IsUsernameErrored && !IsPasswordErrored
					&& Username != null && Password != null;

			if (!IsLoginMode)
			{
				isEnabled &= (!IsNameErrored && Name != null);
			}

			IsPrimaryActionEnabled = isEnabled;
		}

		private void SwitchAction()
		{
			IsPrimaryActionEnabled = false;
			Username = null;
			Password = null;
			Name = null;

			IsLoginMode = !IsLoginMode;
			RaisePropertyChanged(nameof(PrimaryActionTransKey));
			RaisePropertyChanged(nameof(SwitchButtonTransKey));
			RaisePropertyChanged(nameof(SwitchLabelTransKey));
			RaisePropertyChanged(nameof(PageTitleTransKey));
		}

		private void ValidateName()
		{
			var isErrored = false;

			if (Name != null && Name == string.Empty)
			{
				isErrored = true;
			}

			IsNameErrored = isErrored;
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
