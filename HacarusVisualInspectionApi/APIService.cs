using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using HacarusVisualInspectionApi.Models;

namespace HacarusVisualInspectionApi
{
    class APIService
    {
        private static readonly Lazy<APIService> _instance = new Lazy<APIService>(() => new APIService());

        public static APIService Instance
        {
            get { 
                return _instance.Value; 
            }

        }

        public RestClient Client { get; set; }
        public String Language { get; set; }

        public string AccessToken { get; set; }
        public string ServerUrl
        {
            get {
                return ServerUrl;
            }
            set
            {
                this.Client = new RestClient(value);
            }
        }

        public AccessTokenResponse Authorize(string clientId, string clientSecret)
        {
            var Request = new RestRequest("auth/token", Method.POST);
            Request.AddHeader("Accept-Language", this.Language);

            var Parameters = new
            {
                client_id = clientId,
                client_secret = clientSecret,
                grant_type = "client_credentials"
            };
            var Json = JsonConvert.SerializeObject(Parameters);
            Request.AddJsonBody(Json);

            var Response = this.Client.Execute(Request);
            AccessTokenResponse ResponseObject = JsonConvert.DeserializeObject<AccessTokenResponse>(Response.Content);
            if(ResponseObject.Errors == null)
            {
                this.AccessToken = ResponseObject.Data.AccessToken;
            }
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }

        public LicenseResponse ActivateLicense(FileModel licenseFile)
        {
            var Request = new RestRequest("v1/license", Method.POST);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            Request.AddHeader("Accept-Language", this.Language);
            Request.AlwaysMultipartFormData = true;
            Request.AddHeader("Content-Type", "multipart/form-data");
            Request.AddFile("license", licenseFile.FileName, licenseFile.FileName);
            var Response = this.Client.Execute(Request);
            LicenseResponse ResponseObject = JsonConvert.DeserializeObject<LicenseResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }

        public VersionResponse GetVersionNumber()
        {
            var Request = new RestRequest("auth/app_version", Method.GET);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var Response = this.Client.Execute(Request);
            VersionResponse ResponseObject = JsonConvert.DeserializeObject<VersionResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }

        public ItemsResponse GetItems()
        {
            var Request = new RestRequest("v1/items", Method.GET);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var Response = this.Client.Execute(Request);
            ItemsResponse ResponseObject = JsonConvert.DeserializeObject<ItemsResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }

        public AlgorithmResponse GetAlgorithms()
        {
            var Request = new RestRequest("v1/algorithms", Method.GET);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var Response = this.Client.Execute(Request);
            AlgorithmResponse ResponseObject = JsonConvert.DeserializeObject<AlgorithmResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }


        public ModelsResponse GetModels()
        {
            var Request = new RestRequest("v1/models", Method.GET);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var Response = this.Client.Execute(Request);
            ModelsResponse ResponseObject = JsonConvert.DeserializeObject<ModelsResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }


        public ModelResponse Train(string algorithmId, string modelName, string[] itemIds, AlgorithmParameter[] algorithmParameters)
        {
            var Request = new RestRequest("v1/train", Method.POST);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var Parameters = new
            {
                algorithm_id = algorithmId,
                name = modelName,
                override_params = algorithmParameters,
                item_ids = itemIds
            };

            var Json = JsonConvert.SerializeObject(Parameters);
            Request.AddJsonBody(Json);
            var Response = this.Client.Execute(Request);
            ModelResponse ResponseObject = JsonConvert.DeserializeObject<ModelResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }

        public UploadResponse Upload(List<FileModel> filenames, bool? isGood, bool isTraining)
        {
            var Request = new RestRequest("v1/upload", Method.POST);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            Request.AlwaysMultipartFormData = true;
            Request.AddHeader("Content-Type", "multipart/form-data");
            var indexCounter = 0;
            foreach (var file in filenames)
            {
                Request.AddFile("files[" + indexCounter + "]", file.FileName, file.ContentType);
                indexCounter = indexCounter + 1;
            }
            Request.AddParameter("training", isTraining ? "true" : "false");
            Request.AddParameter("good", isGood == null ? null : (isGood.Equals(true) ? "true" : "false"));
            var Response = this.Client.Execute(Request);
            UploadResponse ResponseObject = JsonConvert.DeserializeObject<UploadResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }


        public PredictResponse Serve(string[] itemIds, int? modelId = null)
        {
            var Request = new RestRequest("v1/serve", Method.POST);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var predictParameters = new
            {
                item_ids = itemIds,
                model_id = modelId
            };

            var Json = JsonConvert.SerializeObject(predictParameters);
            Request.AddJsonBody(Json);
            var predictResponse = this.Client.Execute(Request);
            PredictResponse ResponseObject = JsonConvert.DeserializeObject<PredictResponse>(predictResponse.Content);
            ResponseObject.HttpResponse = predictResponse;
            return ResponseObject;
        }

        public ItemResponse GetItem(string itemId)
        {
            var Request = new RestRequest("v1/item/" + itemId, Method.GET);
            Request.AddHeader("Accept-Language", this.Language);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var predictResponse = this.Client.Execute(Request);
            ItemResponse ResponseObject = JsonConvert.DeserializeObject<ItemResponse>(predictResponse.Content);
            ResponseObject.HttpResponse = predictResponse;
            return ResponseObject;
        }

        public GenericResponse AddAnnotations(Annotation[] annotations, string imageId)
        {
            var Request = new RestRequest("v1/image/" + imageId + "/annotation", Method.POST);
            Request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            Request.AddHeader("Accept-Language", this.Language);
            var RequestParameters = new
            {
                annotations
            };
            var Json = JsonConvert.SerializeObject(RequestParameters);
            Request.AddJsonBody(Json);
            var Response = this.Client.Execute(Request);
            GenericResponse ResponseObject = JsonConvert.DeserializeObject<GenericResponse>(Response.Content);
            ResponseObject.HttpResponse = Response;
            return ResponseObject;
        }
    }
}
