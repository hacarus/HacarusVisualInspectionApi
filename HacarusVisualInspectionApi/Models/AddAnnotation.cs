using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public partial class AddAnnotationResponse : Response
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}