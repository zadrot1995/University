using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAdmin.ViewModels
{
    class ShellViewModel : BindableBase
    {
        public ShellViewModel()
        {
        }
        public string Title { get; set; } = "Shell window";
    }
}
