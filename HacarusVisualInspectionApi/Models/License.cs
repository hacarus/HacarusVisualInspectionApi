using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class LicenseData
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class LicenseResponse : Response
    {
        [JsonProperty("data")]
        public LicenseData Data { get; set; }
    }
}
