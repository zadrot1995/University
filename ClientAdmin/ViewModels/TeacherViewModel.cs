using ClientAdmin.Common.DTO;
using ClientAdmin.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using University.Domain.Entities;

namespace ClientAdmin.ViewModels
{
    public class TeacherViewModel : BindableBase
    {
        TeacherService _teacherService;
        DepartmentService _departmentService;
        public List<DepartmentDTO> Departments { get; set; }
        public DelegateCommand<Window> CommandTapCreate { get; private set; }
        private string firstName;
        private string lastName;
        private TeachingPositionType position;
        private DepartmentDTO department;
        private string email;
        //private string tempPassword;

        public TeacherViewModel(TeacherService teacherService, DepartmentService departmentService)
        {
            _teacherService = teacherService;
            _departmentService = departmentService;
            LoadDepartment();
            CommandTapCreate = new DelegateCommand<Window>(CommandCreate);

        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty<string>(ref firstName, value);
        }
        public string LastName
        {
            get => lastName;
            set => SetProperty<string>(ref lastName, value);
        }
       
        public TeachingPositionType Position
        {
            get => position;
            set => SetProperty<TeachingPositionType>(ref position, value);
        }
        public DepartmentDTO Department
        {
            get => department;
            set => SetProperty<DepartmentDTO>(ref department, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty<string>(ref email, value);
        }
        
        private async void CommandCreate(Window currentWindow)
        {

            MessageBox.Show(FirstName + LastName + Email);

            //if (Email == null || TempPassword == null ||
            //    Email == "" || TempPassword == "" ||
            //    FirstName == null || LastName == null ||
            //    FirstName == "" || LastName == "" ||
            //    Birthday == null || Position == null ||
            //    Birthday == "" || Position == "" ||
            //    Chair == "" || Chair == null)
            //    MessageBox.Show("Please, try again and enter correct!");
            //else
            //{
                //Teacher teacher = new Teacher
                //{
                    
                //}
                //bool result = await _teacherService.CreateTeacherAsync(Email, Password);

                //if (result)
                //{
                //    MainPage showListDisciplines = new MainPage();
                //    showListDisciplines.Show();
                //    currentWindow.Close();
                //}
                //else
                //    MessageBox.Show("Something is wrong!\nPlease, try again!");
            //}
        }

        private async void LoadDepartment()
        {
            Departments = new List<DepartmentDTO>();
            Departments.Add(new DepartmentDTO { Name = "Dep1" });
            Departments.Add(new DepartmentDTO { Name = "Dep1" });

        }


    }
}
