using System;
using Newtonsoft.Json;

namespace Client.Models
{
    public class TokensModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
