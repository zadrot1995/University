using System;
using Newtonsoft.Json;

namespace ClientAdmin.Models
{
    public class TokensModel
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
