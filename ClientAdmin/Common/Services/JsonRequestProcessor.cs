using ClientAdmin.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClientAdmin.Common.Services
{
    public class JsonRequestProcessor : IRequestProcessor
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
