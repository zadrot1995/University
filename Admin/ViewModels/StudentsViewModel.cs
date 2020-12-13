using Client_WPF_Teachers.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Client.ViewModels
{
    public class StudentsViewModel : BindableBase
    {
        private ICustomerStore _customerStore = null;

        public StudentsViewModel(ICustomerStore customerStore)
        {
            _customerStore = customerStore;
            CommandLoadExecute();
        }


        public ObservableCollection<string> Customers { get; private set; } =
            new ObservableCollection<string>();


        private string _selectedCustomer = null;
        public string SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetProperty<string>(ref _selectedCustomer, value))
                {
                    //Debug.WriteLine(_selectedCustomer ?? "no customer selected");
                }
            }
        }

        //private DelegateCommand _commandLoad = null;
        //public DelegateCommand CommandLoad =>
        //    _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));

        private void CommandLoadExecute()
        {
            Customers.Clear();
            List<string> list = _customerStore.GetAll();
            foreach (string item in list)
                Customers.Add(item);
        }
    }
}
