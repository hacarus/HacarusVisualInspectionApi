using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{
    public class UploadData
    {
        public List<string> item_ids { get; set; }
    }

    public class UploadResponse : Response
    {
        public UploadData data { get; set; }
    }

}
