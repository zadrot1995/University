using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jose;
using Newtonsoft.Json;
using ClientAdmin.Common;
using ClientAdmin.Common.Constants;
using ClientAdmin.Common.Enum;
using ClientAdmin.Common.Extensions;
using ClientAdmin.Common.Interfaces;
using ClientAdmin.Models;
using System.IdentityModel.Tokens.Jwt;
using ClientAdmin.Configuration;

namespace ClientAdmin.Common.Services
{
    public class TokenService : ITokenService
    {
        private string _refreshUrl;
        private TokensModel _cachedTokens;
        private IResponseProcessor _responseProcessor;
        private IConfigurationManager _configurationManager;
        private HttpClient _httpClient;
        private Dictionary<string, DateTime> _refreshHistory = new Dictionary<string, DateTime>();

        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public TokenService(/*ISecureStorageService secureStorageService,*/ IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
            // _secureStorageService = secureStorageService;
            //_crashService = crashService;
            //_refreshUrl = configurationManager.SecurityUrl;
            _refreshUrl = "";
            _responseProcessor = new JsonResponseProcessor();
            _cachedTokens = new TokensModel();
            //_httpClient = GetHttpClient();
        }

        public async Task<bool> RefreshTokenAsync(TokensModel tokensModel)
        {
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "")
            {
                Content = new JsonRequestProcessor().GetContent(tokensModel)
            };

            var httpResult = await httpClient.SendAsync(httpRequestMessage);

            if (httpResult.IsSuccessStatusCode)
            {
                var responseProcessor = new JsonResponseProcessor();
                var tokenResult = await responseProcessor.GetResponseAsync<TokensModel>(httpResult);

                if (tokenResult.ValidateResponse())
                {
                    // 
                    return true;
                }
            }

            return false;
        }

        public async Task<string> GetTokenFromStorageAsync(Enum.TokenType tokenType)
        {
            try
            {
                switch (tokenType)
                {
                    case Enum.TokenType.ACCESS:
                        {
                            //                            if (string.IsNullOrEmpty(_cachedTokens.AccessToken))
                            //SecureAccessTokenName = name 
                            //                               _cachedTokens.AccessToken = await _secureStorageService.GetAsync("SecureAccessTokenName");
                            return _cachedTokens.AccessToken;
                        }
                    case Enum.TokenType.REFRESH:
                        {
                            //                            if (string.IsNullOrEmpty(_cachedTokens.RefreshToken))
                            //                                _cachedTokens.RefreshToken = await _secureStorageService.GetAsync("SecureAccessTokenName");
                            return _cachedTokens.RefreshToken;
                        }
                }
            }
            catch (Exception ex) { }
            return string.Empty;
        }

        public async Task<TokensModel> GetTokensFromStorageAsync()
        {
            try
            {
                if (_cachedTokens.IsEmpty())
                {
                    //                   _cachedTokens.AccessToken = await _secureStorageService.GetAsync("SecureAccessTokenName");
                    //                   _cachedTokens.RefreshToken = await _secureStorageService.GetAsync("SecureAccessTokenName");
                }
                return _cachedTokens.Clone();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SetTokensAsync(TokensModel token)
        {
            if (token == null || string.IsNullOrEmpty(token.AccessToken) || string.IsNullOrEmpty(token.RefreshToken))
            {
                return false;
            }
            try
            {
                _cachedTokens.AccessToken = token.AccessToken;
                _cachedTokens.RefreshToken = token.RefreshToken;
                //               await _secureStorageService.SetAsync("SecureRefreshTokenName", token.AccessToken);
                //               await _secureStorageService.SetAsync("SecureRefreshTokenName", token.RefreshToken);
                return true;
            }
            catch (Exception ex)
            {
                //_crashService.TrackCustomError(ex);
                return false;
            }
        }

        public void ClearCache()
        {
            _cachedTokens = new TokensModel();
            _refreshHistory.Clear();
            //            _secureStorageService.Remove("SecureAccessTokenName");
            //            _secureStorageService.Remove("SecureAccessTokenName");
        }

        public Task<string> GetTokenFromStorageAsync(Interfaces.TokenType tokenType)
        {
            throw new NotImplementedException();
        }
    }
}
