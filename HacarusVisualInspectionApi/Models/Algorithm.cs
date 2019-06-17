using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{
    public class AlgorithmParameter
    {
        public int algorithm_parameter_id { get; set; }
        public DateTime created_at { get; set; }
        public string data_type { get; set; }
        public bool model_parameter { get; set; }
        public string name { get; set; }
        public DateTime updated_at { get; set; }
        public string value { get; set; }
    }

    public class Algorithm
    {
        public string algorithm_id { get; set; }
        public string name { get; set; }
        public List<AlgorithmParameter> parameters { get; set; }
    }

    public class AlgorithmResponse: Response
    {
        public List<Algorithm> data { get; set; }
    }
}
