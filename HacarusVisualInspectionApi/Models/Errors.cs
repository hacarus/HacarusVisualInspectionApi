using System;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{
    public class Source
    {
        public string pointer { get; set; }
    }

    public class Errors
    {
        public Source source { get; set; }
        public int status { get; set; }
        public string title { get; set; }

        [JsonProperty("detail")]
        private object _detail;

        public string details
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
