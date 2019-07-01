using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class Source
    {
        [JsonProperty("pointer")]
        public string Pointer { get; set; }
    }

    public class Errors
    {
        [JsonProperty("source")]
        public Source Source { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        private object _detail;

        public string Details
        {
            get
            {
                if (_detail != null)
                {
                    if (_detail is string)
                    {
                        // Do nothing
                    }
                    else
                    {
                        _detail = string.Join("\n", ((Newtonsoft.Json.Linq.JArray)_detail).ToObject<string[]>());
                    }
                }
                return _detail as string;
            }
        }
    }

}
