using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Client.Common.Services
{
    public class JsonRequestProcessor
    {
        public JsonRequestProcessor()
        {
        }

        public HttpContent GetContent(object model)
        {
            var jsonModel = JsonConvert.SerializeObject(model);
            return new StringContent(jsonModel, Encoding.UTF8, MediaType);
        }

        public string MediaType => "application/json";
    }
}
