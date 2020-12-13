using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace Client.Common.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentsViewModel>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);

    }
}
