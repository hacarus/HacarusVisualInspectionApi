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
        private readonly HacarusVisualInspection VisualInspection = new HacarusVisualInspection("https://sdd-demo.hacarus.com/api");
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
            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> ActivateLicense(
            string customerId, IFormFile licenseFile
        )
        {
            var uploads = Path.Combine(Environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var file = new FileModel();
            if (licenseFile.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, licenseFile.FileName), FileMode.Create))
                {
                    await licenseFile.CopyToAsync(fileStream);
                    file.FileName = Path.Combine(uploads, licenseFile.FileName);
                    file.ContentType = licenseFile.ContentType;
                }

                LicenseResponse Result = VisualInspection.ActivateLicense(file, customerId);

                ViewData["HttpResponse"] = "Status code: " + Result.httpResponse.StatusCode;
                ViewData["StringMessage"] = Result.httpResponse.Content;

            }


            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "activateLicense";

            return Index();
        }

        [HttpPost]
        public IActionResult GetItems(
            string getItems
        )
        {
            ItemsResponse Result = VisualInspection.GetItems();

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
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

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
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

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getModels";

            return Index();
        }

        [HttpPost]
        public IActionResult Train(
            string train, string name, string algorithmId, List<string> itemIds
        )
        {
            AlgorithmParameter algorithmParameter = new AlgorithmParameter();
            algorithmParameter.AlgorithmParameterId = 221;
            algorithmParameter.Value = "50";

            if (string.IsNullOrEmpty(algorithmId))
            {
                algorithmId = "hacarus-fused-lasso";
            }

            if (string.IsNullOrEmpty(name))
            {
                name = DateTime.Now.ToString();
            }

            ModelResponse Result = VisualInspection.Train(algorithmId, name, itemIds.ToArray(), new AlgorithmParameter[] { algorithmParameter });

            Console.WriteLine("IFFFF " + itemIds.Count);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "train";

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            string upload, string good, string training, ICollection<IFormFile> files
        )
        {
            var uploads = Path.Combine(Environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }


            List<FileModel> filenames = new List<FileModel>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        //var image = new FileModel();
                        //image.FileName = Path.Combine(uploads, file.FileName);
                        //image.ContentType = file.ContentType;
                        var image = new FileModel(Path.Combine(uploads, file.FileName), file.ContentType);
                        filenames.Add(image);
                    }
                }
            }

            bool? isGood = null;
            var isTraining = !string.IsNullOrEmpty(training) && training.Equals("true");



            if (!string.IsNullOrEmpty(good))
            {
                isGood = good.Equals("true");
            }

            if (isTraining)
            {
                UploadResponse Result = VisualInspection.Upload(filenames, (bool)isGood);
                ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
                ViewData["StringMessage"] = Result.httpResponse.Content;
            }
            else
            {
                UploadResponse Result = VisualInspection.Upload(filenames);
                ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
                ViewData["StringMessage"] = Result.httpResponse.Content;
            }                                                                                                                                                                                                                                                                                                                                                           

            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "upload";

            return Index();
        }

        [HttpPost]
        public IActionResult Serve(
            string serve, string itemIdServe, int modelIdServe
        )
        {
            PredictResponse Result = VisualInspection.Serve(new string[] { itemIdServe }, modelIdServe);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "serve";

            return Index();
        }


        [HttpPost]
        public IActionResult GetItem(
            string getItem, string itemId
        )
        {
            ItemResponse Result = VisualInspection.GetItem(itemId);

            ViewData["HttpResponse"] = "Status code: " + (int)Result.httpResponse.StatusCode + " " + Result.httpResponse.StatusCode;
            ViewData["StringMessage"] = Result.httpResponse.Content;
            ViewBag.BearerAvailable = VisualInspection.IsAuthorized;
            ViewBag.Active = "getItem";

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
                var algorithmResponse = VisualInspection.GetAlgorithms();
                var trainingResponse = VisualInspection.GetItems();
                ModelsResponse modelsResponse = VisualInspection.GetModels();
                Console.Write("START IFFF");
                if (trainingResponse != null && trainingResponse.data != null)
                {
                    ViewBag.TrainingItems = trainingResponse.data.training;
                    ViewBag.PredictItems = trainingResponse.data.predict;
                    Console.Write(trainingResponse.data.training.Count);
                }

                if (algorithmResponse != null && algorithmResponse.Data != null)
                {
                    ViewBag.Algorithms = algorithmResponse.Data;
                    Console.Write(algorithmResponse.Data.Count);
                }

                if (modelsResponse != null && modelsResponse.data != null)
                {
                    ViewBag.Models = modelsResponse.data;
                    Console.Write(modelsResponse.data.Count);
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
