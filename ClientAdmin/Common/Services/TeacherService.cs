using ClientAdmin.Common.Constants;
using ClientAdmin.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace ClientAdmin.Common.Services
{
    public class TeacherService
    {
        private readonly IHttpService _httpService;

        public TeacherService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            var result = await _httpService.GetAsync<List<Teacher>>("/api/Teacher");
            return result.Value;
        }
        public async Task<Teacher> GetTeacherAsync(Guid id)
        {
            var result = await _httpService.GetAsync<Teacher>($"/api/Teacher{id}");
            return result.Value;
        }
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            var result = await _httpService.PostAsync<Teacher>($"/api/Teacher",teacher);
            return result.Value;
        }
    }
}
