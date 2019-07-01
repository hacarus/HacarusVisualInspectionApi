using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class UploadData
    {
        [JsonProperty("item_ids")]
        public List<string> ItemIds { get; set; }
    }

    public class UploadResponse : Response
    {
        [JsonProperty("data")]
        public UploadData Data { get; set; }
    }

}
