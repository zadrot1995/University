using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Common.Interfaces;
using Client.Models;
using Newtonsoft.Json;

namespace Client.Common.Services
{
    public class JsonResponseProcessor : IResponseProcessor
    {

        public JsonResponseProcessor()
        {
            //_crashService = crashService;
        }

        public async Task<Result<T>> GetResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            try
            {
                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                var responseObj = Deseralize<T>(jsonResult);
                if (httpResponse.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"success  url = {httpResponse.RequestMessage.RequestUri} : {jsonResult}");
                    return Result<T>.CreateSuccessResult(responseObj);
                }
                else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    //await _crashService.TrackHttpErrorAsync(new Exception(httpResponse.StatusCode.ToString()), httpResponse);
                    return Result<T>.CreateFailureResult(statusCode: (int)HttpStatusCode.InternalServerError);
                }
                else
                {
                    //await _crashService.TrackHttpErrorAsync(new Exception(httpResponse.StatusCode.ToString()), httpResponse);
                    var apiError = Deseralize<ApiError>(jsonResult);
                    if (apiError != null)
                        return Result<T>.CreateFailureResult(apiError);

                    return Result<T>.CreateFailureResult(statusCode: (int)httpResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                //_crashService.TrackCustomError(ex);
                return Result<T>.CreateFailureResult("Cталась помилка, спробуйте пізніше");
            }
        }

        public T Deseralize<T>(string jsonResult)
        {
            T result = default(T);
            if (jsonResult is T)//string, no need to deserialize 
            {
                result = (T)Convert.ChangeType(jsonResult, typeof(string));
                return result;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(jsonResult))
                    throw new Exception("Empty response");
                result = JsonConvert.DeserializeObject<T>(jsonResult);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //_crashService.TrackCustomError(ex);
                return default(T);
            }
            return result;
        }
    }
}
