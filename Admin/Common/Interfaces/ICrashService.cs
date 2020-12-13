using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Common.Interfaces
{
    public interface ICrashService
    {
        Task TrackHttpErrorAsync(Exception ex, HttpResponseMessage httpResponseMessage, HttpRequestMessage httpRequestMessage = null, params KeyValuePair<string, string>[] customProperties);
        void TrackCustomError(Exception ex, IDictionary<string, string> customProperties = null);
    }
}
