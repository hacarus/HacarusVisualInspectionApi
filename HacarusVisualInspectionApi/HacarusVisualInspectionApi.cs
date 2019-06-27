using System;
using System.Collections.Generic;
using HacarusVisualInspectionApi.Models;
using RestSharp;

namespace HacarusVisualInspectionApi
{
    public sealed class HacarusVisualInspection
    {
        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(APIService.Instance.AccessToken);
            }
        }

        public HacarusVisualInspection(string serverUrl = "https://sdd-api.hacarus.com/api")
        {
            APIService.Instance.ServerUrl = serverUrl;
        }

        public HacarusVisualInspection(RestClient client)
        {
            APIService.Instance.Client = client;
        }

        public AccessTokenResponse Authorize(string clientId, string clientSecret)
        {
            var Response = APIService.Instance.Authorize(clientId, clientSecret);
            return Response;
        }

        public LicenseResponse ActivateLicense(FileModel licenseFile, string customerId)
        {
            return APIService.Instance.ActivateLicense(licenseFile, customerId);
        }


        public ItemsResponse GetItems()
        {
            return APIService.Instance.GetItems();
        }

        public AlgorithmResponse GetAlgorithms()
        {
            return APIService.Instance.GetAlgorithms();
        }

        public ModelsResponse GetModels()
        {
            return APIService.Instance.GetModels();
        }

        public ModelResponse Train(string algorithmId, string modelName, string[] itemIds, AlgorithmParameter[] algorithmParameters)
        {
            return APIService.Instance.Train(algorithmId, modelName, itemIds, algorithmParameters);
        }

        // Upload for training
        public UploadResponse Upload(List<FileModel> files, bool isGood)
        {
            return APIService.Instance.Upload(files, isGood, true);
        }

        // Upload for prediction
        public UploadResponse Upload(List<FileModel> files)
        {
            return APIService.Instance.Upload(files, null, false);
        }

        public PredictResponse Serve(string[] itemIds, int? modelId = null)
        {
            return APIService.Instance.Serve(itemIds, modelId);
        }

        public ItemResponse GetItem(string itemId)
        {
            return APIService.Instance.GetItem(itemId);
        }
    }
}
