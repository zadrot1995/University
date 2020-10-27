using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using University.Domain.Enums;

namespace Client.ViewModels
{
    class TeacherViewModel : INotifyPropertyChanged
    {
        int id;
        string fullName;
        TeachingPositionType teachingPositionType;

        public int Id 
        { 
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string FullName 
        { 
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public TeachingPositionType TeachingPositionType
        { 
            get => teachingPositionType;
            set
            {
                teachingPositionType = value;
                OnPropertyChanged("TeachingPositionType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //  public Group Group { get; set; }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
