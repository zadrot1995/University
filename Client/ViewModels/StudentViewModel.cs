using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Client.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        int id;
        string fullName;
        int groupId;

        public int Id 
        { 
            get => id; 
            set {
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
        public int GroupId
        {
            get => groupId;
            set
            {
                groupId = value;
                OnPropertyChanged("GroupId");
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
