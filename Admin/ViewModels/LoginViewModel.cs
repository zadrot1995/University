using Client.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Client.ViewModels
{
    class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            CommandTapLogIn = new DelegateCommand<Window>(CommandLogIn);
			CommandTapForgot = new DelegateCommand<Window>(CommandForgot);
		}

		public DelegateCommand<Window> CommandTapLogIn { get; private set; }
        public DelegateCommand<Window> CommandTapForgot { get; private set; }

		private string _email = null;
		public string Email
		{
			get => _email;
			set => SetProperty<string>(ref _email, value);
		}

        
		private string _password = null;
		//public string Password
		//{
		//	get => _password;
		//	set => SetProperty<string>(ref _password, value);
		//}
		
        private void CommandLogIn(Window currentWindow)
		{
			if (Email == "123")
			{
				MainPage listDisciplines = new MainPage();
				listDisciplines.Show();

				currentWindow.Close();
			}
			else
			{
				//here will be message that email and password are incorect
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
