using ClientAdmin.Common.Services;
using ClientAdmin.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using University.Domain.Entities;

namespace ClientAdmin.ViewModels
{
    class TeachersViewModel : BindableBase, INotifyPropertyChanged
    {
        private TeacherService _teacherService = null;
        public ObservableCollection<Teacher> Teachers { get; set; }

        public TeachersViewModel(TeacherService teacherService)
        {
            _teacherService = teacherService;
            CommandTapAddTeacher = new DelegateCommand<Window>(CommandAddTeacher);
            LoadTeachers();
            //CommandTapRefresh = new DelegateCommand<object>(CommandRefresh);
            //CommandLoadExecute();
            //LoadDisciplines();
        }
        public DelegateCommand<Window> CommandTapAddTeacher { get; private set; }

        public async void LoadTeachers()
        {
            Teachers = new ObservableCollection<Teacher>();
            List<Teacher> teachers = await _teacherService.GetTeachersAsync();
            if (teachers != null)
            {
                foreach (Teacher t in teachers)
                {
                    Teachers.Add(t);
                }
            }

        }

        private void CommandAddTeacher(Window currentWindow)
        {
            AddTeacher teacherPage = new AddTeacher();
            teacherPage.Show();

            currentWindow.Close();
        }

        //public DelegateCommand<object> CommandTapRefresh { get; private set; }

        //public ObservableCollection<Teacher> Teachers { get; private set; } =
        //    new ObservableCollection<Teacher>();

        //private string _selectedDiscipline = null;
        //public string SelectedDiscipline
        //{
        //    get => _selectedDiscipline;
        //    set
        //    {
        //        if (SetProperty<string>(ref _selectedDiscipline, value))
        //        {
        //            //Debug.WriteLine(_selectedCustomer ?? "no customer selected");
        //        }
        //    }
        //}

        //private void LoadDisciplines()
        //{

        //}

        //private void CommandRefresh(object parameter)
        //{
        //    LoadDisciplines();
        //}

        //private async void CommandLoadExecute()
        //{
        //    Teachers.Clear();
        //    List<Teacher> list = await _teacherService.GetTeachersAsync();
        //    foreach(Teacher item in list)
        //        Teachers.Add(item);

        //    usersCollection = new CollectionViewSource();
        //    usersCollection.Source = Teachers;
        //    //usersCollection.Filter += usersCollection_Filter;
        //}

        //#region List filter

        //private string filterText;
        //private CollectionViewSource usersCollection;
        //public event PropertyChangedEventHandler PropertyChanged;

        //public string FilterText
        //{
        //    get
        //    {
        //        return filterText;
        //    }
        //    set
        //    {
        //        filterText = value;
        //        this.usersCollection.View.Refresh();
        //        RaisePropertyChanged("FilterText");
        //    }
        //}

        ///*
        //void usersCollection_Filter(object sender, FilterEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(FilterText))
        //    {
        //        e.Accepted = true;
        //        return;
        //    }

        //    //User usr = e.Item as User;
        //    if (usr.Name.ToUpper().Contains(FilterText.ToUpper()))
        //    {
        //        e.Accepted = true;
        //    }
        //    else
        //    {
        //        e.Accepted = false;
        //    }
        //}
        //*/

        //public void RaisePropertyChanged(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}


        //#endregion
    }
}
