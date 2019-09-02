using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class ItemsResponse : Response
    {
        [JsonProperty("data")]
        public ItemsData Data { get; set; }
    }

    public class ItemsData
    {
        [JsonProperty("predict")]
        public Item[] Predict { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("training")]
        public Item[] Training { get; set; }
    }

    public  class Summary
    {
        [JsonProperty("predict_stats")]
        public Stats[] PredictStats { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("training_stats")]
        public Stats TrainingStats { get; set; }
    }

    public  class Stats
    {
        [JsonProperty("NG_count")]
        public long NgCount { get; set; }

        [JsonProperty("OK_count")]
        public long OkCount { get; set; }

        [JsonProperty("accuracy")]
        public long Accuracy { get; set; }

        [JsonProperty("adjusted_count")]
        public long AdjustedCount { get; set; }

        [JsonProperty("confirmed_count")]
        public long ConfirmedCount { get; set; }

        [JsonProperty("done_count")]
        public long DoneCount { get; set; }

        [JsonProperty("model_id")]
        public string ModelId { get; set; }
    }
}