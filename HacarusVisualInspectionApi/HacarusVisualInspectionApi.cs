using System;
using System.Collections.Generic;
using HacarusVisualInspectionApi.Models;
using RestSharp;

namespace HacarusVisualInspectionApi
{
    public sealed class HacarusVisualInspection
    {
        private string ClientId = string.Empty;
        private string ClientSecret = string.Empty;

        public string StringMessage { get; set; }
        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(APIService.Instance.AccessToken);
            }
        }

        public string AccessToken
        {
            get
            {
                return APIService.Instance.AccessToken;
            }
        }

        public RestClient Client
        {
            get
            {
                return APIService.Instance.Client;
            }
            set
            {
                APIService.Instance.Client = value;
            }
        }

        public HacarusVisualInspection(string serverUrl = "https://sdd-api.hacarus.com/api")
        {
            APIService.Instance.ServerUrl = serverUrl;
        }

        public AccessTokenResponse Authorize(string clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;

            var response = APIService.Instance.Authorize(this.ClientId, this.ClientSecret);

            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public LicenseResponse ActivateLicense(FileModel licenseFile, string customerId)
        {
            var response = APIService.Instance.ActivateLicense(licenseFile, customerId);
            this.StringMessage = response.httpResponse.Content;

            return response;
        }


        public ItemsResponse GetItems()
        {
            var response = APIService.Instance.GetItems();
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public AlgorithmResponse GetAlgorithms()
        {
            var response = APIService.Instance.GetAlgorithms();
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public ModelsResponse GetModels()
        {
            var response = APIService.Instance.GetModels();
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public ModelResponse Train(string algorithmId, string modelName, string[] itemIds, AlgorithmParameter[] algorithmParameters)
        {
            var response = APIService.Instance.Train(algorithmId, modelName, itemIds, algorithmParameters);
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public UploadResponse Upload(List<FileModel> files, bool? isGood, bool isTraining)
        {
            var response = APIService.Instance.Upload(files, isGood, isTraining);
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public PredictResponse Serve(string[] itemIds, int? modelId = null)
        {
            var response = APIService.Instance.Serve(itemIds, modelId);
            this.StringMessage = response.httpResponse.Content;

            return response;
        }

        public ItemResponse GetItem(string itemId)
        {
            var response = APIService.Instance.GetItem(itemId);
            this.StringMessage = response.httpResponse.Content;

            return response;
        }
    }
}
