using ClientAdmin.Common.DTO;
using ClientAdmin.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Common.Services
{
    public class DepartmentService
    {
        private readonly IHttpService _httpService;

        public DepartmentService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<List<DepartmentDTO>> GetDepartmentsAsync()
        {
            var result = await _httpService.GetAsync<List<DepartmentDTO>>("/api/Department");
            return result.Value;
        }
    }
}
