using System;
using System.Collections.Generic;
using RestSharp;

namespace HacarusVisualInspectionApi.Models
{
    public class Response
    {
        public Errors errors { get; set; }
        public IRestResponse httpResponse { get; set; }
    }


    public class GenericResponse: Response
    {
        public string data { get; set; }
    }

    public class ImageModel
    {
        public string filename;
        public string contentType;
    }

    public class UploadData
    {
        public List<string> item_ids { get; set; }
    }

    public class UploadResponse: Response
    {
        public UploadData data { get; set; }
    }
}
