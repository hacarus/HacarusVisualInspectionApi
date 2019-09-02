using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public partial class WorkersResponse : Response
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("predicting")]
        public string[] Predicting { get; set; }

        [JsonProperty("training")]
        public string[] Training { get; set; }
    }

}
