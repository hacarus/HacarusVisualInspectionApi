using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace HacarusVisualInspectionApi.Models
{
    public class Response
    {
        [JsonProperty("errors")]
        public Errors Errors { get; set; }

        public IRestResponse HttpResponse { get; set; }
    }

    public class FileModel
    {
        public string FileName;
        public string ContentType;

        public FileModel() { }
        public FileModel(string filename, string contentType) 
        {
            FileName = filename;
            ContentType = contentType;
        }
    }

    public class GenericData
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class GenericResponse : Response
    {
        [JsonProperty("data")]
        public GenericData Data { get; set; }
    }
}
