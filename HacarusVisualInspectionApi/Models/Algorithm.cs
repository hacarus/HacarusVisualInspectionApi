using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class AlgorithmParameter
    {
        [JsonProperty("algorithm_parameter_id")]
        public int AlgorithmParameterId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("data_type")]
        public string DataType { get; set; }

        [JsonProperty("model_parameter")]
        public bool ModelParameter { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Algorithm
    {
        [JsonProperty("algorithm_id")]
        public string AlgorithmId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public List<AlgorithmParameter> Parameters { get; set; }
    }

    public class AlgorithmResponse: Response
    {
        [JsonProperty("data")]
        public List<Algorithm> Data { get; set; }
    }
}
