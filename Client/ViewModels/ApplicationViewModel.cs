using Client.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Client.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private StudentViewModel selectedStudent;

        public ObservableCollection<StudentViewModel> Students { get; set; }
        public StudentViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      StudentViewModel student = new StudentViewModel();
                      Students.Insert(0, student);
                      SelectedStudent = student;
                  }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      StudentViewModel student = obj as StudentViewModel;
                      if (student != null)
                      {
                          Students.Remove(student);
                      }
                  },
                 (obj) => Students.Count > 0));
            }
        }

        public ApplicationViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>
            {
                new StudentViewModel { Id = 1, FullName = "Andriy Antonik", GroupId = 1 },
                new StudentViewModel { Id = 2, FullName = "New Student1", GroupId = 2 },
                new StudentViewModel { Id = 3, FullName = "New Student2", GroupId = 1 },

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
