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
using Hacarus.SpectroSdk.Api;
using Hacarus.SpectroSdk.Client;
using Hacarus.SpectroSdk.Model;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment IHEnvironment;
        public static string AccessToken;
        public static string CurrentContextId;
        private static SpectroApi SpectroInstance = new SpectroApi("https://sdd-local.hacarus.com");
        private static ModelsApi ModelsInstance = new ModelsApi("https://sdd-local.hacarus.com");
        private static AlgorithmsApi AlgorithmsInstance = new AlgorithmsApi("https://sdd-local.hacarus.com");
        private static ItemsApi ItemsInstance = new ItemsApi("https://sdd-local.hacarus.com");



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
                var Result = SpectroInstance.Login(loginParams);
                Debug.WriteLine(Result);
                var ConfigurationInstance = new Configuration();
                ConfigurationInstance.AccessToken = Result.AccessToken;
                SpectroInstance.Configuration = ConfigurationInstance;
                ModelsInstance.Configuration = ConfigurationInstance;
                AlgorithmsInstance.Configuration = ConfigurationInstance;
                ItemsInstance.Configuration = ConfigurationInstance;
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                    var Result = ModelsInstance.ImportModels(FStream);
                    ViewData["StringMessage"] = Result.ToJson();
                    ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
            //try
            //{
            //    var Result = Instance.GetVersion();
            //    ViewData["StringMessage"] = Result.ToJson();
            //    ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
            //    ViewBag.Active = "getVersionNumber";
            //}
            //catch (ApiException e)
            //{
            //    ViewData["HttpResponse"] = e.ErrorCode;
            //    ViewData["StringMessage"] = e.Message;
            //}

            return Index();
        }

        [HttpPost]
        public IActionResult GetContext()
        {
            //try
            //{
            //    var Result = Instance.GetContext();
            //    ViewData["StringMessage"] = Result.ToJson();
            //    ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
            //    ViewBag.Active = "getItems";
            //}
            //catch (ApiException e)
            //{
            //    ViewData["HttpResponse"] = e.ErrorCode;
            //    ViewData["StringMessage"] = e.Message;
            //}



            return Index();
        }

        [HttpPost]
        public IActionResult GetPredictionItems(
            string modelId
       )
        {
            try
            {
                var Result = ItemsInstance.GetItemsByType(itemType: "prediction", count: 10, page: 1, modelId: modelId);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.PredictionItems = Result.Data.Items;
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Result = ItemsInstance.GetItemsByType(itemType: "training", count: 10, page: 1, modelId: modelId);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.TrainingItems = Result.Data.Items;
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
            //try
            //{
            //    var Result = SpectroInstance.GetWorkers();
            //    ViewData["StringMessage"] = Result.ToJson();
            //    ViewBag.BearerAvailable = Instance.Configuration.AccessToken != null;
            //    ViewBag.Active = "getWorkers";
            //}
            //catch (ApiException e)
            //{
            //    ViewData["HttpResponse"] = e.ErrorCode;
            //    ViewData["StringMessage"] = e.Message;
            //}

            return Index();
        }

        [HttpPost]
        public IActionResult GetAlgorithms(
            string getAlgorithms
        )
        {
            try
            {
                var Result = AlgorithmsInstance.GetAlgorithms();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Result = ModelsInstance.GetModels();
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
            var AlgorithmParameter = new OverrideParam(value: "[88,88]", algorithmParameterId: 919);

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
                var Params = new TrainRequest(overrideParams: new List<OverrideParam> { AlgorithmParameter }, itemIds: itemIds, name: name);
                var Result = AlgorithmsInstance.Train(algorithmId: algorithmId, trainRequest: Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
                ViewBag.Active = "train";
            }
            catch (ApiException e)
            {
                ViewData["HttpResponse"] = e.ErrorCode;
                ViewData["StringMessage"] = ((BaseError)e.ErrorContent).Errors.Title + ": "
                                + ((BaseError)e.ErrorContent).Errors.Message[0].Errors[0];
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
                var Result = ItemsInstance.AddItem(
                    training: isTraining,
                    files: List,
                    good: IsGood
                );
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Params = new Predict(new List<string> { itemIdServe });
                var Result = ModelsInstance.PredictItems(modelId: modelIdServe, predict: Params);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Result = ModelsInstance.DeleteModels(new List<string> { modelIdsServe });
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Result = ItemsInstance.GetItemById(itemId, true, true, null);
                ViewData["StringMessage"] = Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
            string addAnnotation, string itemId,
            int xMin, int xMax,
            int yMin, int yMax,
            string notes
        )
        {
            try
            {
                var Params = new AnnotateItemRequest(new List<RequestAnnotation> { new RequestAnnotation(xMax, xMin, yMax, yMin, 0, notes) });
                //var Result = 
                ItemsInstance.Annotate(itemId: itemId, annotateItemRequest: Params);
                ViewData["StringMessage"] = "success";
                    //Result.ToJson();
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                    var Result = ModelsInstance.ImportModels(FStream);
                    ViewData["StringMessage"] = Result.ToJson();
                    ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
                var Params = new ModelIdsQuery(modelIdsExport);
                var Result = ModelsInstance.ExportModelsWithId(Params);

                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                               "model.zip");

                var fileStream = System.IO.File.Create(fileName);
                Result.Seek(0, SeekOrigin.Begin);
                Result.CopyTo(fileStream);
                fileStream.Close();

                ViewData["StringMessage"] = "Download started.";
                using (var fileStream2 = System.IO.File.Create(fileName))
                {
                    Result.Seek(0, SeekOrigin.Begin);
                    Result.CopyTo(fileStream2);
                }

                ViewData["StringMessage"] = "Successfully saved to Desktop.";
                ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
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
            ViewBag.BearerAvailable = SpectroInstance.Configuration.AccessToken != null;
            ViewBag.Algorithms = new List<AlgorithmWithParameter>();
            ViewBag.TrainingItems = new List<Item>();
            ViewBag.PredictItems = new List<Item>();
            ViewBag.Models = new List<HModel>();

            if (ViewBag.BearerAvailable)
            {

                try
                {   
                    var AlgorithmResponse = AlgorithmsInstance.GetAlgorithms();
                    ViewBag.Algorithms = AlgorithmResponse.Data;
                    Debug.WriteLine(AlgorithmResponse.Data.Count);
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                    Debug.WriteLine(e);
                }

                try
                {
                    var ItemsResponse = ItemsInstance.GetItemsByType(itemType: "prediction", count: 10, page: 1);
                    ViewBag.PredictItems = ItemsResponse.Data.Items ;
                }
                catch (ApiException e)
                {
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                    Debug.WriteLine(e);
                }

                try
                {
                    var ItemsResponse = ItemsInstance.GetItemsByType(itemType: "training", count: 10, page: 1);
                    ViewBag.TrainingItems = ItemsResponse.Data.Items;
                }
                catch (ApiException e)
                {
                    Debug.WriteLine(e);
                    //ViewData["HttpResponse"] = e.ErrorContent;
                    //ViewData["StringMessage"] = e.ErrorCode;
                }

                try
                {
                    var ModelsResponse = ModelsInstance.GetModels();
                    ViewBag.Models = Array.FindAll(ModelsResponse.Data.ToArray(), (HModel Model) => (bool)Model.Active);
                    Debug.WriteLine("ModelsResponse");
                    Debug.WriteLine(ModelsResponse);
                    //Console.Write(ModelsResponse.Data);
                    //Console.Write(ModelsResponse.Data.Count);
                }
                catch (ApiException e)
                {
                    Debug.WriteLine(e);
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
