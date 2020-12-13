using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Common.Interfaces;
using JsonMasking;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;

namespace Flagman.Common.Services
{
    public class CrashService : ICrashService
    {
        public void TrackCustomError(Exception ex, IDictionary<string, string> customProperties = null)
        {
            if (customProperties == null)
                customProperties = new Dictionary<string, string>();
            customProperties.Add("StackTrace", ex.StackTrace);
            Crashes.TrackError(ex, customProperties); 
        }

        public async Task TrackHttpErrorAsync(Exception ex, HttpResponseMessage httpResponseMessage, HttpRequestMessage httpRequestMessage = null, params KeyValuePair<string, string>[] customProperties)
        {
            if (ex is InvalidOperationException)
                return;

            var responseBody = string.Empty;
            var responseCode = string.Empty;
            if (httpResponseMessage != null && httpResponseMessage.Content != null)
            {
                responseBody = await httpResponseMessage?.Content?.ReadAsStringAsync();
                responseCode = httpResponseMessage.StatusCode.ToString();
            }

            var requestBody = string.Empty;
            var method = string.Empty;
            var uri = string.Empty;
            if (httpRequestMessage != null && httpRequestMessage.Content != null)
            {
                requestBody = await httpRequestMessage.Content.ReadAsStringAsync();
                requestBody = HideSecureElements(requestBody);
                method = httpRequestMessage.Method?.Method;
                uri = httpRequestMessage.RequestUri?.OriginalString;
            }


            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "method", method},
                { "uri", uri},
                { "content", requestBody },
                { "httpResponseCode", responseCode },
                { "bodyResponse", responseBody}
            };
            if (customProperties.Length > 0)
            {
                AddCustomFieldsToDictionary(dict, customProperties);
            }

            #if DEBUG
            var serialized = JsonConvert.SerializeObject(dict);
            Debug.WriteLine(serialized);
            #endif


            Crashes.TrackError(ex, dict);
        }

        private void AddCustomFieldsToDictionary(IDictionary<string, string> dict, params KeyValuePair<string, string>[] customProperties)
        {
            foreach (var property in customProperties)
            {
                dict.Add(property);
            }
        }

        private string HideSecureElements(string content)
        {
            var blacklist = new string[] { "password", "PasswordConfirm"};
            var mask = "******";

            return content.MaskFields(blacklist, mask);
        }
    }
}
