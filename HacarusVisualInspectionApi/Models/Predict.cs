using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{

    public class PredictData
    {
        [JsonProperty("item_ids")]
        public List<string> ItemIds { get; set; }

        [JsonProperty("model_version")]
        public string ModelVersion { get; set; }
    }

    public class PredictResponse: Response
    {
        [JsonProperty("data")]
        public PredictData Data { get; set; }
    }
}
