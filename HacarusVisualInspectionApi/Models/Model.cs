using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class ModelData
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("algorithm_id")]
        public string AlgorithmId { get; set; }

        [JsonProperty("context_default")]
        public bool ContextDefault { get; set; }

        [JsonProperty("context_id")]
        public int ContextId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("model_id")]
        public int ModelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

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
}
