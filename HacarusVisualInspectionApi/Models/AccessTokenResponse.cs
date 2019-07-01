using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class AccessTokenData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires")]
        public int Expires { get; set; }
    }

    public class AccessTokenResponse: Response
    {
        [JsonProperty("data")]
        public AccessTokenData Data { get; set; }
    }
}
