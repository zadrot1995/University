using Client.Common.Constants;
using Client.Common.Interfaces;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace Client.Common.Services
{
    class StudentService 
    {
        private readonly IHttpService _httpService;
        private readonly ICrashService _crashService;

        public StudentService(IHttpService httpService, ICrashService crashService)
        {
            _httpService = httpService;
            _crashService = crashService;
        }

        public Task<Student> CreateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
        //public async Task<IEnumerable<StudentsViewModel>> GetStudentsAsync()
        //{
        //    try
        //    {
        //        var studentResponce = await _httpService.GetAsync<IEnumerable<Student>>(ApiConstants.Students);
        //        if (studentResponce.ValidateResponse())
        //        {
        //            List<Student> students = studentResponce.Value.ToList();
        //            List<StudentsViewModel> studentViewModels = new List<StudentsViewModel>();
        //            foreach(Student student in students)
        //            {
        //                studentViewModels.Add(new StudentsViewModel
        //                {
        //                    FullName = student.FullName,
        //                    GroupId = student.GroupId,
        //                    Id = student.Id
        //                });
        //            }    
        //            return studentViewModels;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _crashService.TrackCustomError(ex);
        //    }
        //    return null;

           
        //}
    }
}
