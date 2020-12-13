using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClientAdmin.Models
{
    public class ApiError
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }

    public class ErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
