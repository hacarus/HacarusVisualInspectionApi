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

    public class Item
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("default_image")]
        public object DefaultImage { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("finished_date")]
        public DateTimeOffset? FinishedDate { get; set; }

        [JsonProperty("is_training_data")]
        public bool IsTrainingData { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("models")]
        public Model[] Models { get; set; }

        [JsonProperty("override")]
        public Override Override { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("thumbnail_image")]
        public object ThumbnailImage { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Images { get; set; }
    }

    public class Model
    {
        [JsonProperty("aggregate")]
        public Aggregate Aggregate { get; set; }

        [JsonProperty("assessments")]
        public Assessment[] Assessments { get; set; }

        [JsonProperty("model_id")]
        public long ModelId { get; set; }
    }

    public class Aggregate
    {
        [JsonProperty("detected_objects")]
        public long DetectedObjects { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Assessment
    {
        [JsonProperty("annotations")]
        public object[] Annotations { get; set; }

        [JsonProperty("computed")]
        public Override Computed { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("final")]
        public Override Final { get; set; }

        [JsonProperty("finished_date")]
        public object FinishedDate { get; set; }

        [JsonProperty("image_id")]
        public long ImageId { get; set; }

        [JsonProperty("model_id")]
        public long ModelId { get; set; }
    }

    public  class Summary
    {
        [JsonProperty("predict_stats")]
        public PredictStat[] PredictStats { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("training_stats")]
        public TrainingStats TrainingStats { get; set; }
    }

    public  class PredictStat
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
        public long ModelId { get; set; }
    }

    public  class TrainingStats
    {
        [JsonProperty("NG_count")]
        public long NgCount { get; set; }

        [JsonProperty("OK_count")]
        public long OkCount { get; set; }
    }
}