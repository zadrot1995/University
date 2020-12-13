using ClientAdmin.Common.Constants;
using ClientAdmin.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Common.Services
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        HttpService _httpService;

        public ForgotPasswordService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var model = new { Email = email };
            var result = await _httpService.PostAsync<string>(ApiConstants.ForgotPassword, model);

            return result.ValidateResponse();
        }

        public async Task<bool> UpdatePasswordAsync(string password, string token)
        {
            var mas = token.Split('_');
            if (mas == null || mas.Length != 2)
            {
                return false;
            }
            var model = new { NewPassword = password, Token = mas[1], UserId = mas[0] };
            var result = await _httpService.PostAsync<string>(ApiConstants.UpdatePassword, model);

            return result.ValidateResponse();
        }
    }
}
