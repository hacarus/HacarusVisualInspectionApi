using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class VersionResponse : Response
    {
        [JsonProperty("data")]
        public string VersionNumber { get; set; }
    }
}
