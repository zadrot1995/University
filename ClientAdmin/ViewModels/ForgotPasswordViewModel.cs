using ClientAdmin.Common.Services;
using ClientAdmin.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ClientAdmin.ViewModels
{
	public class ForgotPasswordViewModel : BindableBase
	{
		ForgotPasswordService _forgotPasswordService;

		public ForgotPasswordViewModel(ForgotPasswordService forgotPasswordService)
		{
			_forgotPasswordService = forgotPasswordService;
			CommandTapSubmitLogin = new DelegateCommand<object>(CommandSubmit);
			CommandTapUpdate = new DelegateCommand<object>(CommandUpdate);

			IsEnabledConfirm = true;
			IsEnabledUpdate = false;
		}

		public DelegateCommand<object> CommandTapSubmitLogin { get; private set; }
		public DelegateCommand<object> CommandTapUpdate { get; private set; }

		private string _email = null;
		public string Email
		{
			get => _email;
			set => SetProperty<string>(ref _email, value);
		}

		private string _token = null;
		public string Token
		{
			get => _token;
			set => SetProperty<string>(ref _token, value);
		}

		private bool _isEnabledUpdate;
		public bool IsEnabledUpdate
		{
			get => _isEnabledUpdate;
			set => SetProperty<bool>(ref _isEnabledUpdate, value);
		}

		private bool _isEnabledConfirm;
		public bool IsEnabledConfirm
		{
			get => _isEnabledConfirm;
			set => SetProperty<bool>(ref _isEnabledConfirm, value);
		}

		private async void CommandSubmit(object parameter)
		{
			bool result = await _forgotPasswordService.ForgotPasswordAsync(Email);

			if (result)
			{
				IsEnabledConfirm = false;
				IsEnabledUpdate = true;
			}
		}

		private async void CommandUpdate(object parameter)
		{
			var pswBoxes = parameter as object[];
			PasswordBox passwordBox;
			string password1;
			string password2;
			Window currentWindow = pswBoxes[2] as Window;

			try
			{
				passwordBox = pswBoxes[0] as PasswordBox;
				password1 = passwordBox.Password;
				passwordBox = pswBoxes[1] as PasswordBox;
				password2 = passwordBox.Password;

				if (string.IsNullOrEmpty(password1) || password1 != password2)
				{
					MessageBox.Show("Please, enter first and second passwords similarlt and try again!");
					return;
				}

				bool result = await _forgotPasswordService.UpdatePasswordAsync(password1, Token);

				if (result)
				{
					MessageBox.Show("Your password changed successfully!");

					LoginPage loginAuth = new LoginPage();
					loginAuth.Show();

					currentWindow.Close();
				}
				else
					MessageBox.Show("Something is wrong!\nPlease, try again!");

			}
			catch
			{
				return;
			}
		}
	}
}
