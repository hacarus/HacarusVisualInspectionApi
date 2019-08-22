using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class DeleteResponse : Response
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
