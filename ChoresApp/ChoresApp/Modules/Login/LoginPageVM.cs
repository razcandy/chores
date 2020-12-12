using ChoresApp.Data.Models;
using ChoresApp.Helpers;
using ChoresApp.Pages;
using ChoresApp.Pages.Popups;
using ChoresApp.Pages.Popups.Alert;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoresApp.Modules.Login
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

		private SessionModel sessionModel;

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
				ResolveIsPrimaryActionEnabled();
				sessionModel.Name = name;
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
				sessionModel.Password = password;
			}
		}

		public string PasswordHelperText
		{
			get => passwordHelperText;
			private set => Set(ref passwordHelperText, value);
		}

		public RelayCommand PrimaryActionCommand { get; private set; }

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
				sessionModel.Username = username;
			}
		}

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private void Init()
		{
			sessionModel = new SessionModel();
			BackCommand = new RelayCommand(Back);
			SwitchCommand = new RelayCommand(SwitchAction);
			PrimaryActionCommand = new RelayCommand(PrimaryAction);
		}

		private void Back()
		{

		}

		private async void PrimaryAction()
		{
			if (!IsPrimaryActionEnabled) return;

			var sm = new SuccessMessage();

			if (IsLoginMode)
			{
				sm = await LoginHelper.TryLogIn(sessionModel);
			}
			else
			{
				sm = await LoginHelper.TryCreateUser(sessionModel);
			}

			if (sm.IsSuccess)
			{
				await NavigationHelper.PushHomePage();
			}
			else
			{
				var alertVM = new ChPopupAlertVM
				{
					MessageTransKey = sm.TranslationKey,
				};

				NavigationHelper.PushAlert(alertVM);
			}
		}

		private void ResolveIsPrimaryActionEnabled()
		{
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

			if (Password != null && !LoginHelper.IsPasswordValid(Password))
			{
				isErrored = true;
			}

			PasswordHelperText = isErrored ? "Invalid password" : null;
			IsPasswordErrored = isErrored;
		}

		private void ValidateUsername()
		{
			var isErrored = false;

			if (Username != null && !LoginHelper.IsUsernameValid(Username))
			{
				isErrored = true;
			}

			IsUsernameErrored = isErrored;
		}
	}
}
