using Client.ViewModels;
using Client.Views;
using Client_WPF_Teachers.Dialogs;
using Client_WPF_Teachers.Services;
using Client_WPF_Teachers.ViewModels;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<StudentsPage>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.Register<ICustomerStore, DbCustomerStore>();
            containerRegistry.RegisterForNavigation<StudentsPage, StudentsViewModel>();


        }
    }
}
