using ClientAdmin.Common.Services;
using ClientAdmin.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ClientAdmin.ViewModels
{
	public class LoginViewModel : BindableBase
	{
		LoginService _loginService;

		public LoginViewModel(LoginService loginService)
		{
			_loginService = loginService;
			CommandTapLogIn = new DelegateCommand<object>(CommandLogIn);
			CommandTapForgot = new DelegateCommand<Window>(CommandForgot);
			//Email = "admin@nltu.edu.ua";
		}

		public DelegateCommand<object> CommandTapLogIn { get; private set; }
		public DelegateCommand<Window> CommandTapForgot { get; private set; }

		private string _email = null;

		public string Email
		{
			get => _email;
			set => SetProperty<string>(ref _email, value);
		}

		private string _password = null;
		public string Password
		{
			get => _password;
			set => SetProperty<string>(ref _password, value);
		}

		private async void CommandLogIn(object parameter)
		{
			var pswBoxes = parameter as object[];
			PasswordBox passwordBox;

			passwordBox = pswBoxes[0] as PasswordBox;
			Password = passwordBox.Password;

			Window currentWindow = pswBoxes[1] as Window;

			if (Email == null || Password == null || Email == "" || Password == "")
				MessageBox.Show("Please, try again and enter correct!");
			else
			{
				bool result = await _loginService.AuthAsync(Email, Password);

				if (result)
				{
					MainPage showListDisciplines = new MainPage();
					showListDisciplines.Show();
					currentWindow.Close();
				}
				else
					MessageBox.Show("Something is wrong!\nPlease, try again!");
			}
		}

		private void CommandForgot(Window currentWindow)
		{
			ForgotPassword confirmEmail = new ForgotPassword();
			confirmEmail.Show();

			currentWindow.Close();
		}
	}
}
