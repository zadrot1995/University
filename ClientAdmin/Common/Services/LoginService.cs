using ClientAdmin.Common.Constants;
using ClientAdmin.Common.Interfaces;
using ClientAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Common.Services
{
    public class LoginService : ILoginService
    {
        HttpService _httpService;
        TokenService _tokenService;

        public LoginService(HttpService httpService, TokenService tokenService)
        {
            _httpService = httpService;
            _tokenService = tokenService;
        }

        public async Task<bool> AuthAsync(string email, string password)
        {
            var model = new { Email = email, Password = password };
            var result = await _httpService.PostAsync<TokensModel>(ApiConstants.Auth, model);
            if(result.IsSuccess)
            {
                await _tokenService.SetTokensAsync(result.Value);

            }

            return result.ValidateResponse();
        }
    }
}
