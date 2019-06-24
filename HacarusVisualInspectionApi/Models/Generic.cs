using System;
using System.Net;
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

    public class FileModel
    {
        public string filename;
        public string contentType;
    }
}
