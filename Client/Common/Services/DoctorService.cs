using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ViClinic.Common.Constants;
using ViClinic.Common.Interfaces;
using ViClinic.Models;

namespace ViClinic.Common.Services
{
    public class DoctorService : IDoctorService
    {
        private Doctor _cachedDoctor;
        private readonly IHttpService _httpService;

        public DoctorService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Result<Doctor>> GetProfileAsync(bool useCache = false)
        {
            if (useCache && _cachedDoctor != null)
                return Result<Doctor>.CreateSuccessResult(_cachedDoctor);
            var result = await _httpService.GetAsync<Doctor>(ApiConstants.Doctor);
            if (result.IsSuccess)
                _cachedDoctor = result.Value;
            return result;
        }

        public async Task<Result<DoctorMedicalProfile>> GetMedicalProfileAsync() =>
            await _httpService.GetAsync<DoctorMedicalProfile>(ApiConstants.DoctorMedicalProfile);

        public async Task<Result<string>> UploadAvatarAsync(Stream stream)
        {
            var response = await _httpService.PostAsync<string>(ApiConstants.UploadAvatar, stream, requestProcessor: new MultipartFormDataRequestProcessor());
            return response;
        }

        public async Task<DoctorWorkExperience> GetWorkExpirienceAsync(Guid id)
        {
            var result = await _httpService.GetAsync<DoctorWorkExperience>(ApiConstants.ExistingWorkExperience(id));
            return result.Value;
        }

        public async Task<bool> AddWorkExpirienceAsync(DoctorWorkExperience workExperience)
        {
            var result = await _httpService.PostAsync<DoctorWorkExperience>(ApiConstants.WorkExperience, workExperience);
            if (result.ValidateResponse())
                return true;
            return false;
        }

        public async Task<bool> UpdateWorkExpirienceAsync(DoctorWorkExperience workExperience)
        {
            if (workExperience == null || !workExperience.Id.HasValue)
                return false;
            var result = await _httpService.PutAsync<DoctorWorkExperience>(ApiConstants.ExistingWorkExperience(workExperience.Id.Value), workExperience);
            if (result.ValidateResponse())
                return true;
            return false;
        }

        public async Task<bool> DeleteWorkExpirienceAsync(Guid id)
        {
            var result = await _httpService.DeleteAsync<string>(ApiConstants.ExistingWorkExperience(id));
            if (result.ValidateResponse())
                return true;
            return false;
        }

        public async Task AddMedicalLicenseAsync(Stream stream, string description)
        {
            var model = new MultipartFormDataRequestModel
            {
                Stream = stream,
                Parameters = new Dictionary<string, string> { { "Description", description } }
            };
            var response = await _httpService.PostAsync<string>(ApiConstants.MedicalLicense, model, requestProcessor: new MultipartFormDataRequestProcessor());
        }
    }
}
