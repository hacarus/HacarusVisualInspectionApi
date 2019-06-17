using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{

    public class PredictData
    {
        public List<string> items { get; set; }
        public string model_version { get; set; }
    }

    public class PredictResponse: Response
    {
        public PredictData data { get; set; }
    }
}
