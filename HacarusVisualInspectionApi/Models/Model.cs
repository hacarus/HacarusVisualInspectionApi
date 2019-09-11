using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class ModelResponse: Response
    {
        [JsonProperty("data")]
        public ModelData Data { get; set; }
    }

    public class ModelsResponse: Response
    {
        [JsonProperty("data")]
        public List<ModelData> Data { get; set; }
    }

    public class ModelData
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("algorithm_id")]
        public string AlgorithmId { get; set; }

        [JsonProperty("algorithm_type")]
        public string AlgorithmType { get; set; }

        [JsonProperty("context_default")]
        public bool ContextDefault { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("model_id")]
        public string ModelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ng_img_count")]
        public long NgImgCount { get; set; }

        [JsonProperty("ok_img_count")]
        public long OkImgCount { get; set; }

        [JsonProperty("stats")]
        public ModelStats Stats { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_text")]
        public string StatusText { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class ModelStats
    {
        [JsonProperty("precision")]
        public Precision Precision { get; set; }

        [JsonProperty("recall")]
        public Precision Recall { get; set; }
    }

    public class Precision
    {
        [JsonProperty("computed")]
        public double? Computed { get; set; }

        [JsonProperty("projected")]
        public double? Projected { get; set; }
    }

    public class TrainResponse: Response
    {
        [JsonProperty("data")]
        public TrainData Data { get; set; }
    }

    public class TrainData
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("algorithm_id")]
        public string AlgorithmId { get; set; }

        [JsonProperty("algorithm_type")]
        public string AlgorithmType { get; set; }

        [JsonProperty("context_default")]
        public bool ContextDefault { get; set; }

        [JsonProperty("context_id")]
        public long ContextId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("model_id")]
        public string ModelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ng_img_count")]
        public long NgImgCount { get; set; }

        [JsonProperty("ok_img_count")]
        public long OkImgCount { get; set; }

        [JsonProperty("precision")]
        public object Precision { get; set; }

        [JsonProperty("recall")]
        public object Recall { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_text")]
        public string StatusText { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
