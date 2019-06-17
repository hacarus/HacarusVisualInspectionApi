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
        //public string detail { get; set; }
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
                    else if (_detail is string[])
                    {
                        _detail = string.Join("\n\n", (string[])_detail);
                    }
                }

                return _detail as string;
            }
        }
    }

}
