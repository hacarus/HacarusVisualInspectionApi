using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using SampleApp.Models;
//using HacarusVisualInspectionApi;
//using HacarusVisualInspectionApi.Models;
using SpectroSdk.Api;
using SpectroSdk.Client;
using SpectroSdk.Model;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment IHEnvironment;
        public static string AccessToken;
        public static string CurrentContextId;
        private static SpectroApi Instance = new SpectroApi("https://sdd-api.hacarus.com/api");



        public HomeController(IHostingEnvironment environment)
        {
            IHEnvironment = environment;
        }

        [HttpPost]
        public IActionResult Login(
            string loginClient, string clientId, string clientSecret
        )
        {
            try
            {
                LoginParams loginParams = new LoginParams(
                    clientId: clientId,
                    clientSecret: clientSecret,
                    grantType: "client_credentials"
                );
                var Result = Instance.Login(loginParams);
                var ConfigurationInstance = new Configuration();
                ConfigurationInstance.AccessToken = Result.Data.AccessToken;
                Instance.Configuration = ConfigurationInstance;
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> ActivateLicense(
            IFormFile LicenseFile
        )
        {
            var Uploads = Path.Combine(IHEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(Uploads))
            {
                Directory.CreateDirectory(Uploads);
            }

            if (LicenseFile.Length > 0)
            {
                var FStream = new FileStream(Path.Combine(Uploads, LicenseFile.FileName), FileMode.Create);
                LicenseFile.CopyTo(FStream);
                FStream.Seek(0, SeekOrigin.Begin);
                try
                {
                    var Result = Instance.ImportModels(FStream);
                    ViewData["StringMessage"] = Result.ToJson();
                    ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                    ViewBag.Active = "activateLicense";
                }
                catch (ApiException e)
                {
                    ViewData["HttpResponse"] = e.ErrorCode;
                    ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                    + ((BaseError)e.ErrorContent).Errors.Detail;

                }
                finally
                {
                    FStream.Close();
                }
            }


            return Index();
        }



        [HttpPost]
        public IActionResult GetVersionNumber(
        )
        {
            try
            {
                var Result = Instance.GetVersion();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getVersionNumber";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = e.Message;
            }

            return Index();
        }

        [HttpPost]
        public IActionResult GetContext()
        {
            try
            {
                var Result = Instance.GetContext();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getItems";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = e.Message;
            }



            return Index();
        }

        [HttpPost]
        public IActionResult GetPredictionItems(
            string modelId
       )
        {
            try
            {
                var Result = Instance.GetPredictionItems(count: 10, page: 1, modelId: modelId);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getPredictionItems";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = e.Message;
            }



            return Index();
        }

        [HttpPost]
        public IActionResult GetTrainingItems(
            string modelId
      )
        {
            try
            {
                var Result = Instance.GetTrainingItems(count: 10, page: 1, modelId: modelId);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getTrainingItems";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = e.Message;
            }



            return Index();
        }

        [HttpPost]
        public IActionResult GetWorkers(
            string getWorkers
        )
        {
            try
            {
                var Result = Instance.GetWorkers();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getWorkers";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = e.Message;
            }

            return Index();
        }

        [HttpPost]
        public IActionResult GetAlgorithms(
            string getAlgorithms
        )
        {
            try
            {
                var Result = Instance.GetAlgorithms();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getAlgorithms";
            }
            catch(ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }

        [HttpPost]
        public IActionResult GetModels(
            string getAlgorithms
        )
        {
            try
            {
                var Result = Instance.GetModels();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getModels";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }

        [HttpPost]
        public IActionResult Train(
            string train, string name, string algorithmId, List<string> itemIds
        )
        {
            var AlgorithmParameter = new BaseAlgorithmParameter(221, "50");

            if (string.IsNullOrEmpty(algorithmId))
            {
                algorithmId = "OC";
            }

            if (string.IsNullOrEmpty(name))
            {
                name = DateTime.Now.ToString();
            }

            try
            {
                var Params = new TrainParams(algorithmId, name, itemIds, new List<BaseAlgorithmParameter> { AlgorithmParameter });
                var Result = Instance.Train(Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "train";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }
            Console.WriteLine("IFFFF " + itemIds.Count);

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            string upload, string good, string training, ICollection<IFormFile> files
        )
        {
            var Uploads = Path.Combine(IHEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(Uploads))
            {
                Directory.CreateDirectory(Uploads);
            }

            bool? IsGood = null;
            var isTraining = !string.IsNullOrEmpty(training) && training.Equals("true");



            if (!string.IsNullOrEmpty(good))
            {
                IsGood = good.Equals("true");
            }

            List<System.IO.Stream> List = new List<System.IO.Stream>();
            foreach (var FileObject in files)
            {
                if (FileObject.Length > 0)
                {
                    var fStream = new FileStream(Path.Combine(Uploads, FileObject.FileName), FileMode.Create);
                    FileObject.CopyTo(fStream);
                    fStream.Seek(0, SeekOrigin.Begin);
                    List.Add(fStream);
                }
            }
            try
            {
                var Result = Instance.UploadItem(
                    training: isTraining,
                    files: List,
                    good: IsGood
                );
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "upload";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;

            }
            finally
            {
                foreach (var stream in List)
                {
                    stream.Close();
                }
            }

            return Index();
        }

        [HttpPost]
        public IActionResult Serve(
            string serve, string itemIdServe, string modelIdServe
        )
        {
            try
            {
                var Params = new PredictParams(modelIdServe, new List<string> { itemIdServe });
                var Result = Instance.Predict(Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "serve";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }


            return Index();
        }


        [HttpPost]
        public IActionResult DeleteModels(
            string deleteModels, string modelIdsServe
        )
        {
            try
            {
                var Params = new DeleteModelRequest(new List<string> { modelIdsServe });
                var Result = Instance.DeleteModels(Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "deleteModels";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }



        [HttpPost]
        public IActionResult GetItem(
            string getItem, string itemId
        )
        {
            try
            {
                var Result = Instance.GetItem(itemId, true, true);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "getItem";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }


        [HttpPost]
        public IActionResult AddAnnotation(
            string addAnnotation, string imageId,
            int xMin, int xMax,
            int yMin, int yMax,
            string notes
        )
        {
            try
            {
                var Params = new AnnotateParams(new List<BaseAnnotation> { new BaseAnnotation(notes, xMin, xMax, yMin, yMax) });
                var Result = Instance.Annotate(imageId, Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "addAnnotation";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> ImportModels(
            IFormFile Models
        )
        {
            var Uploads = Path.Combine(IHEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(Uploads))
            {
                Directory.CreateDirectory(Uploads);
            }

            if (Models.Length > 0)
            {
                var FStream = new FileStream(Path.Combine(Uploads, Models.FileName), FileMode.Create);
                Models.CopyTo(FStream);
                FStream.Seek(0, SeekOrigin.Begin);
                try
                {
                    var Result = Instance.ImportModels(FStream);
                    ViewData["StringMessage"] = Result.ToJson();
                    ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                    ViewBag.Active = "importModels";
                }
                catch (ApiException e)
                {
                    ViewData["HttpResponse"] = e.ErrorCode;
                    ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                    + ((BaseError)e.ErrorContent).Errors.Detail;

                }
                finally
                {
                    FStream.Close();
                }
            }

           
            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> ExportModels(
            List<string> modelIdsExport
        )
        {
            try {
                var Params = new ExportModelRequest(modelIdsExport);
                var Result = Instance.ExportModels(Params);

                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                               "model.zip");

                //var fileStream = System.IO.File.Create(fileName);
                //Result.Seek(0, SeekOrigin.Begin);
                //Result.CopyTo(fileStream);
                //fileStream.Close();

                ViewData["StringMessage"] = "Download started.";
                using (var fileStream = System.IO.File.Create(fileName))
                {
                    Result.Seek(0, SeekOrigin.Begin);
                    Result.CopyTo(fileStream);
                }

                ViewData["StringMessage"] = "Successfully saved to Desktop.";
                ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
                ViewBag.Active = "exportModels";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Detail;
            }


            return Index();
        }

        public IActionResult Index()
        {
            ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
            ViewBag.Algorithms = new List<Algorithm>();
            ViewBag.TrainingItems = new List<Item>();
            ViewBag.TrainingItems = new List<Item>();
            ViewBag.PredictItems = new List<Item>();
            ViewBag.Models = new List<Model>();

            if (ViewBag.BearerAvailable)
            {

                try
                {   
                    var AlgorithmResponse = Instance.GetAlgorithms();
                    ViewBag.Algorithms = AlgorithmResponse.Data;
                    Console.Write(AlgorithmResponse.Data.Count);
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                }

                try
                {
                    var ItemsResponse = Instance.GetPredictionItems(count: 10, page: 1);
                    ViewBag.PredictItems = ItemsResponse.Data.Items;
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                }

                try
                {
                    var ItemsResponse = Instance.GetTrainingItems(count: 10, page: 1);
                    ViewBag.TrainingItems = ItemsResponse.Data.Items;
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                }

                try
                {
                    var ModelsResponse = Instance.GetModels();
                    ViewBag.Models = Array.FindAll(ModelsResponse.Data.ToArray(), (Model Model) => Model.Active);
                    Console.Write(ModelsResponse.Data.Count);
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                }
            }
            Console.Write("END INDEX "+ ViewBag.Algorithms.Count);

            return View("Index");
        }


        //public IActionResult ClientCredential()
        //{
        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
