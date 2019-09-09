using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class WorkersResponse : Response
    {
        [JsonProperty("data")]
        public WorkerData Data { get; set; }
    }

    public class WorkerData
    {
        [JsonProperty("predicting")]
        public string[] Predicting { get; set; }

        [JsonProperty("training")]
        public string[] Training { get; set; }
    }

}
