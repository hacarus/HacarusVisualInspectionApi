using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{
    public class ModelData
    {
        public bool active { get; set; }
        public string algorithm_id { get; set; }
        public bool context_default { get; set; }
        public int context_id { get; set; }
        public DateTime created_at { get; set; }
        public int model_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public DateTime updated_at { get; set; }
        public string version { get; set; }
    }

    public class ModelResponse: Response
    {
        public ModelData data { get; set; }
    }

    public class ModelsResponse: Response
    {
        public List<ModelData> data { get; set; }
    }
}
