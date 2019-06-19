using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using HacarusVisualInspectionApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace HacarusVisualInspectionSDK
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
            var request = new RestRequest("auth/token", Method.POST);

            var parameters = new
            {
                client_id = clientId,
                client_secret = clientSecret,
                grant_type = "client_credentials"
            };
            var json = JsonConvert.SerializeObject(parameters);
            request.AddJsonBody(json);

            var response = this.Client.Post(request);
            AccessTokenResponse responseObject = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);
            if(responseObject.errors == null)
            {
                this.AccessToken = responseObject.data.access_token;
            }
            responseObject.httpResponse = response;
            return responseObject;
        }

        public LicenseResponse ActivateLicense(FileModel licenseFile, string costumerId)
        {
            var request = new RestRequest("auth/license", Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("license", licenseFile.filename, licenseFile.filename);
            request.AddParameter("customer_id", costumerId);
            //X509Certificate2 certificate = new X509Certificate2(licenseFile.filename);
            //this.Client.ClientCertificates = new X509CertificateCollection() { certificate };
            var response = this.Client.Post(request);
            LicenseResponse responseObject = JsonConvert.DeserializeObject<LicenseResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }

        public ItemsResponse GetItems()
        {
            var request = new RestRequest("v1/items", Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var response = this.Client.Get(request);
            ItemsResponse responseObject = JsonConvert.DeserializeObject<ItemsResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }

        public AlgorithmResponse GetAlgorithms()
        {
            var request = new RestRequest("v1/algorithms", Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var response = this.Client.Get(request);
            AlgorithmResponse responseObject = JsonConvert.DeserializeObject<AlgorithmResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }


        public ModelsResponse GetModels()
        {
            var request = new RestRequest("v1/models", Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var response = this.Client.Get(request);
            ModelsResponse responseObject = JsonConvert.DeserializeObject<ModelsResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }


        public ModelResponse Train(string algorithmId, string modelName, string[] itemIds, AlgorithmParameter[] algorithmParameters)
        {
            var request = new RestRequest("v1/train", Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var parameters = new
            {
                algorithm_id = algorithmId,
                name = modelName,
                override_params = algorithmParameters,
                item_ids = itemIds
            };

            var json = JsonConvert.SerializeObject(parameters);
            request.AddJsonBody(json);
            var response = this.Client.Post(request);
            ModelResponse responseObject = JsonConvert.DeserializeObject<ModelResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }

        public UploadResponse Upload(List<FileModel> filenames, bool? isGood, bool isTraining)
        {
            var request = new RestRequest("v1/upload", Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Content-Type", "multipart/form-data");
            var indexCounter = 0;
            foreach (var file in filenames)
            {
                request.AddFile("files[" + indexCounter + "]", file.filename, file.contentType);
                indexCounter = indexCounter + 1;
            }
            request.AddParameter("training", isTraining ? "true" : "false");
            request.AddParameter("good", isGood == null ? null : (isGood.Equals(true) ? "true" : "false"));
            var response = this.Client.Post(request);
            UploadResponse responseObject = JsonConvert.DeserializeObject<UploadResponse>(response.Content);
            responseObject.httpResponse = response;
            return responseObject;
        }


        public PredictResponse Serve(string[] item_ids, int? modelId = null)
        {
            var request = new RestRequest("v1/serve", Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var predictParameters = new
            {
                item_ids,
                model_id = modelId
            };

            var json = JsonConvert.SerializeObject(predictParameters);
            request.AddJsonBody(json);
            var predictResponse = this.Client.Post(request);
            PredictResponse responseObject = JsonConvert.DeserializeObject<PredictResponse>(predictResponse.Content);
            responseObject.httpResponse = predictResponse;
            return responseObject;
        }

        public ItemResponse GetItem(string item_id)
        {
            var request = new RestRequest("v1/item/" + item_id, Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", this.AccessToken));
            var predictResponse = this.Client.Get(request);
            ItemResponse responseObject = JsonConvert.DeserializeObject<ItemResponse>(predictResponse.Content);
            responseObject.httpResponse = predictResponse;
            return responseObject;
        }
    }
}
