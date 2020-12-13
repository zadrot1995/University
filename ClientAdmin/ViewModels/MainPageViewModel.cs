using ClientAdmin.Common.Services;
using ClientAdmin.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ClientAdmin.ViewModels
{
    class MainPageViewModel
    {
		//LoginService _loginService;

		public MainPageViewModel()
		{
			//_loginService = loginService;
			CommandTapTeachers = new DelegateCommand<Window>(CommandTeachers);
			CommandTapGroups = new DelegateCommand<Window>(CommandGroups);
		}

		public DelegateCommand<Window> CommandTapTeachers { get; private set; }
		public DelegateCommand<Window> CommandTapGroups { get; private set; }





		private void CommandTeachers(Window currentWindow)
		{
			TeachersPage teachersPage = new TeachersPage();
			teachersPage.Show();

			currentWindow.Close();
		}
		private void CommandGroups(Window currentWindow)
		{
			GroupsPage groupsPage = new GroupsPage();
			groupsPage.Show();

			currentWindow.Close();
		}
	}
}
