using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.Common.Interfaces;
using Client.Common.Extensions;
using Client.Models;
using Newtonsoft.Json;
using Polly;

namespace Client.Common.Services
{
    public class HttpService : IHttpService
    {
        private readonly IResponseProcessor _responseProcessor;
        private readonly IRequestProcessor _requestProcessor;
        private readonly ITokenService _tokenService;
        private readonly IUnauthorizedHandlerStrategy _unauthorizedHandlerStrategy;
        private readonly HttpClient _client;
        private const string mediaType = "application/json";
        private string _defaultBaseUrl;

        public HttpService(ITokenService tokenService, IConfigurationManager configurationManager,
            IUnauthorizedHandlerStrategy unauthorizedHandlerStrategy)
        {
            _client = new HttpClient
            {
                Timeout = TimeSpan.FromHours(2)
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            _unauthorizedHandlerStrategy = unauthorizedHandlerStrategy;
            _responseProcessor = new JsonResponseProcessor();
            _tokenService = tokenService;
            _requestProcessor = new JsonRequestProcessor();
            _defaultBaseUrl = configurationManager.ApiJson;
        }

        public async Task<Result<T>> GetAsync<T>(string requestUri, string baseUrl = null, CancellationToken cancellationToken = default, IResponseProcessor responseProcessor = null, bool withRetry = true)
        {
            return await ProcessResponseAsync<T>(HttpMethod.Get, requestUri, baseUrl, null, responseProcessor, cancellationToken, withRetry);
        }

        public async Task<Result<T>> PostAsync<T>(string requestUri, object model, string baseUrl = null, CancellationToken cancellationToken = default,
            IResponseProcessor responseProcessor = null, bool withRetry = true, IRequestProcessor requestProcessor = null)
        {
            requestProcessor = requestProcessor ?? _requestProcessor;
            return await ProcessResponseAsync<T>(HttpMethod.Post, requestUri, baseUrl, requestProcessor.GetContent(model), responseProcessor, cancellationToken, withRetry);
        }

        public async Task<Result<T>> PutAsync<T>(string requestUri, object model, string baseUrl = null, CancellationToken cancellationToken = default,
            IResponseProcessor responseProcessor = null, bool withRetry = true, IRequestProcessor requestProcessor = null)
        {
            requestProcessor = requestProcessor ?? _requestProcessor;
            return await ProcessResponseAsync<T>(HttpMethod.Put, requestUri, baseUrl, requestProcessor.GetContent(model), responseProcessor, cancellationToken, withRetry);
        }

        public async Task<Result<T>> DeleteAsync<T>(string requestUri, string baseUrl = null, CancellationToken cancellationToken = default, IResponseProcessor responseProcessor = null, bool withRetry = true)
        {
            return await ProcessResponseAsync<T>(HttpMethod.Delete, requestUri, baseUrl, null, responseProcessor, cancellationToken, withRetry);
        }

        private async Task<Result<T>> ProcessResponseAsync<T>(HttpMethod method, string requestUri, string baseUrl = null, HttpContent content = null, IResponseProcessor responseProcessor = null, CancellationToken cancellationToken = default, bool withRetry = true)
        {
            /*
            if (!_connectivityService.IsNetworkAvailable)
            {
                return Result<T>.CreateFailureResult(AppResources.NoInternetConnection);
            }
            */
            //responseProcessor = responseProcessor ?? _responseProcessor;
            var tokens = await GetAuthorizationInformationAsync();

            baseUrl = baseUrl ?? _defaultBaseUrl;
            var fullUrl = $"{baseUrl}{requestUri}";

            var httpRequestMessage = new HttpRequestMessage(method, fullUrl)
            {
                Content = content
            };

            HttpResponseMessage httpResponse = null;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                httpResponse = await _client.SendAsync(httpRequestMessage, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var needUpdate = await IsTokenNeedUpdateAsync(httpResponse);
                    if (!needUpdate)
                        return Result<T>.CreateFailureResult("Error result");
                    if (await _tokenService.RefreshTokenAsync(tokens))
                    {
                        var copyContent = await content.CloneAsync();
                        return await ProcessResponseAsync<T>(method, requestUri, baseUrl, copyContent, responseProcessor, cancellationToken);
                    }
                    else
                    {
                        await _unauthorizedHandlerStrategy.ExecuteAsync();
                        return Result<T>.CreateFailureResult("Error result");
                    }
                }

                return await responseProcessor.GetResponseAsync<T>(httpResponse);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Result<T>.CreateFailureResult("ServerCannotBeReachedError");
            }
            finally
            {
                httpResponse?.Dispose();
                content?.Dispose();
            }
        }

        private async Task<TokensModel> GetAuthorizationInformationAsync()
        {
            var tokens = await _tokenService.GetTokensFromStorageAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            return tokens;
        }

        private async Task<bool> IsTokenNeedUpdateAsync(HttpResponseMessage httpResponseMessage)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ApiError>(content);
            return false; //TODO: update
        }
    }
}
