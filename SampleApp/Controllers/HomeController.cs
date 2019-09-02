using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Models;
using HacarusVisualInspectionApi;
using HacarusVisualInspectionApi.Models;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment Environment;
        private readonly HacarusVisualInspection VisualInspection = new HacarusVisualInspection("http://127.0.0.1:3000/api");
        public static string AccessToken;
        public static string CurrentContextId;

        public HomeController(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        [HttpPost]
        public IActionResult Login(
            string loginClient, string clientId, string clientSecret
        )
        {
            AccessTokenResponse Result = VisualInspection.Authorize(clientId, clientSecret);
            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> ActivateLicense(
            IFormFile licenseFile
        )
        {
            var Uploads = Path.Combine(Environment.WebRootPath, "uploads");
            if (!Directory.Exists(Uploads))
            {
                Directory.CreateDirectory(Uploads);
            }
            var file = new FileModel();
            if (licenseFile.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(Uploads, licenseFile.FileName), FileMode.Create))
                {
                    await licenseFile.CopyToAsync(fileStream);
                    file.FileName = Path.Combine(Uploads, licenseFile.FileName);
                    file.ContentType = licenseFile.ContentType;
                }

                LicenseResponse Result = VisualInspection.ActivateLicense(file);

                ViewData["HttpResponse"] = "Status code: " + Result.HttpResponse.StatusCode;
                ViewData["StringMessage"] = Result.HttpResponse.Content;

            }


            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "activateLicense";

            return Index();
        }



        [HttpPost]
        public IActionResult GetVersionNumber(
        )
        {
            VersionResponse Result = VisualInspection.GetVersionNumber();

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getVersionNumber";

            return Index();
        }

        [HttpPost]
        public IActionResult GetItems(
            string getItems
        )
        {
            ItemsResponse Result = VisualInspection.GetItems();

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getItems";

            return Index();
        }

        [HttpPost]
        public IActionResult GetAlgorithms(
            string getAlgorithms
        )
        {
            AlgorithmResponse Result = VisualInspection.GetAlgorithms();

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getAlgorithms";

            return Index();
        }

        [HttpPost]
        public IActionResult GetModels(
            string getAlgorithms
        )
        {
            ModelsResponse Result = VisualInspection.GetModels();

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getModels";

            return Index();
        }

        [HttpPost]
        public IActionResult Train(
            string train, string name, string algorithmId, List<string> itemIds
        )
        {
            AlgorithmParameter AlgorithmParameter = new AlgorithmParameter();
            AlgorithmParameter.AlgorithmParameterId = 221;
            AlgorithmParameter.Value = "50";

            if (string.IsNullOrEmpty(algorithmId))
            {
                algorithmId = "OC";
            }

            if (string.IsNullOrEmpty(name))
            {
                name = DateTime.Now.ToString();
            }

            ModelResponse Result = VisualInspection.Train(algorithmId, name, itemIds.ToArray(), new AlgorithmParameter[] { AlgorithmParameter });

            Console.WriteLine("IFFFF " + itemIds.Count);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "train";

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            string upload, string good, string training, ICollection<IFormFile> files
        )
        {
            var Uploads = Path.Combine(Environment.WebRootPath, "uploads");
            if (!Directory.Exists(Uploads))
            {
                Directory.CreateDirectory(Uploads);
            }


            List<FileModel> FileNames = new List<FileModel>();
            foreach (var FileObject in files)
            {
                if (FileObject.Length > 0)
                {
                    using (var FileStream = new FileStream(Path.Combine(Uploads, FileObject.FileName), FileMode.Create))
                    {
                        await FileObject.CopyToAsync(FileStream);
                        var image = new FileModel(Path.Combine(Uploads, FileObject.FileName), FileObject.ContentType);
                        FileNames.Add(image);
                    }
                }
            }

            bool? IsGood = null;
            var isTraining = !string.IsNullOrEmpty(training) && training.Equals("true");



            if (!string.IsNullOrEmpty(good))
            {
                IsGood = good.Equals("true");
            }

            if (isTraining)
            {
                UploadResponse Result = VisualInspection.Upload(FileNames, (bool)IsGood);
                ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
                ViewData["StringMessage"] = Result.HttpResponse.Content;
            }
            else
            {
                UploadResponse Result = VisualInspection.Upload(FileNames);
                ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
                ViewData["StringMessage"] = Result.HttpResponse.Content;
            }                                                                                                                                                                                                                                                                                                                                                           

            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "upload";

            return Index();
        }

        [HttpPost]
        public IActionResult Serve(
            string serve, string itemIdServe, string modelIdServe
        )
        {
            PredictResponse Result = VisualInspection.Serve(new string[] { itemIdServe }, modelIdServe);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "serve";

            return Index();
        }


        [HttpPost]
        public IActionResult GetItem(
            string getItem, string itemId
        )
        {
            ItemResponse Result = VisualInspection.GetItem(itemId, true, true);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getItem";

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

            Annotation NewAnnotation = new Annotation(xMin, xMax, yMin, yMax, notes);
            GenericResponse Result = VisualInspection.SetAnnotations(new Annotation[] { NewAnnotation }, imageId);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.HttpResponse.StatusCode + " " + Result.HttpResponse.StatusCode;
            ViewData["StringMessage"] = Result.HttpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "addAnnotation";

            return Index();
        }


        public IActionResult Index()
        {
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Algorithms = new List<Algorithm>();
            ViewBag.TrainingItems = new List<Item>();
            ViewBag.PredictItems = new List<Item>();
            ViewBag.Models = new List<ModelData>();

            if (ViewBag.BearerAvailable)
            {
                var AlgorithmResponse = VisualInspection.GetAlgorithms();
                var TrainingResponse = VisualInspection.GetItems();
                ModelsResponse ModelsResponse = VisualInspection.GetModels();
                Console.Write("START IFFF");
                if (TrainingResponse != null && TrainingResponse.Data != null)
                {
                    ViewBag.TrainingItems = TrainingResponse.Data.Training;
                    ViewBag.PredictItems = TrainingResponse.Data.Predict;
                    //Console.Write(TrainingResponse.Data.Training.Count);
                }

                if (AlgorithmResponse != null && AlgorithmResponse.Data != null)
                {
                    ViewBag.Algorithms = AlgorithmResponse.Data;
                    Console.Write(AlgorithmResponse.Data.Count);
                }

                if (ModelsResponse != null && ModelsResponse.Data != null)
                {
                    ViewBag.Models = ModelsResponse.Data;
                    Console.Write(ModelsResponse.Data.Count);
                }

                Console.Write("END IFFF");
            }

            // Console.Write("END INDEX "+ ViewBag.Algorithms.Count);

            return View("Index");
        }

        public IActionResult ClientCredential()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
