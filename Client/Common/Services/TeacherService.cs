using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Common.Services
{
    public class TeacherService
    {
        private Patient _cachedPatient;
        private readonly IHttpService _httpService;

        public TeacherService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<List<Teacher>> GetWorkExpirienceAsync(Guid id)
        {
            var result = await _httpService.GetAsync<Teacher>(ApiConstants.);
            return result.Value;
        }
    }
}
