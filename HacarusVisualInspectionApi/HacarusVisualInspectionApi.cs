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

        public HacarusVisualInspection(string serverUrl = "https://sdd-api.hacarus.com/api", string language = "en")
        {
            APIService.Instance.ServerUrl = serverUrl;
            APIService.Instance.Language = language;
        }

        public HacarusVisualInspection(RestClient client, string language = "en")
        {
            APIService.Instance.Client = client;
            APIService.Instance.Language = language;
        }


        public void SetLanguage(string language)
        {
            APIService.Instance.Language = language;
        }

        public AccessTokenResponse Authorize(string clientId, string clientSecret)
        {
            var Response = APIService.Instance.Authorize(clientId, clientSecret);
            return Response;
        }

        public LicenseResponse ActivateLicense(FileModel licenseFile)
        {
            return APIService.Instance.ActivateLicense(licenseFile);
        }

        public ItemsResponse GetItems()
        {
            return APIService.Instance.GetItems();
        }

        public VersionResponse GetVersionNumber()
        {
            return APIService.Instance.GetVersionNumber();
        }

        public AlgorithmResponse GetAlgorithms()
        {
            return APIService.Instance.GetAlgorithms();
        }

        public ModelsResponse GetModels()
        {
            return APIService.Instance.GetModels();
        }

        public TrainResponse Train(string algorithmId, string modelName, string[] itemIds, AlgorithmParameter[] algorithmParameters)
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

        public PredictResponse Serve(string[] itemIds, string modelId = "")
        {
            return APIService.Instance.Serve(itemIds, modelId);
        }

        public ItemResponse GetItem(string itemId, bool showAnnotations = false, bool showAssessments = false)
        {
            return APIService.Instance.GetItem(itemId, showAnnotations, showAssessments);
        }

        public GenericResponse SetAnnotations(Annotation[] annotations, string imageId)
        {
            return APIService.Instance.SetAnnotations(annotations, imageId);
        }


        public WorkersResponse GetWorkers()
        {
            return APIService.Instance.GetWorkers();
        }

        public GenericResponse DeleteModels(string[] modelIds)
        {
            return APIService.Instance.DeleteModels(modelIds);
        }
    }
}
