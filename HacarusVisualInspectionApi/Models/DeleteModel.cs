using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class DeleteResponse : Response
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
