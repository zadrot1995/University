using Client.Commands;
using ClientAdmin.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace ClientAdmin.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IStudentService _studentService;
        private StudentsViewModel selectedStudent;
        public ObservableCollection<StudentsViewModel> Students { get; set; }
        public StudentsViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        private RelayCommand addStudent;
        //public RelayCommand AddStudent
        //{
            
        //}

        // команда удаления
        private RelayCommand removeStudent;
        public RelayCommand RemoveStudent
        {
            get
            {
                return removeStudent ??
                  (removeStudent = new RelayCommand(obj =>
                  {
                      StudentsViewModel student = obj as StudentsViewModel;
                      if (student != null)
                      {
                          Students.Remove(student);
                      }
                  },
                 (obj) => Students.Count > 0));
            }
        }

        //public ApplicationViewModel()
        //{

        //    Students = new ObservableCollection<StudentViewModel>
        //    {
        //        new StudentViewModel { Id = 1, FullName = "Andriy Antonik", GroupId = 1 },
        //        new StudentViewModel { Id = 2, FullName = "New Student1", GroupId = 2 },
        //        new StudentViewModel { Id = 3, FullName = "New Student2", GroupId = 1 },

        //    };
        //}

        public ApplicationViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            InitializeData();
        }

        private async Task InitializeData()
        {
            IEnumerable<StudentsViewModel> studentsResponce = await _studentService.GetStudentsAsync();
            foreach (StudentsViewModel student in studentsResponce)
            {
                Students.Add(student);
            }

        }

        // async Task<StudentViewModel> GetProductAsync(string path)
        //{
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Students = await response.Content.ReadAsAsync<List<StudentViewModel>>();
        //    }
        //    return product;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
