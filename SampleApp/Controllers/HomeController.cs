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
        private IHostingEnvironment _environment;
        HacarusVisualInspection hacarusVisualInspection = new HacarusVisualInspection("https://sdd-demo.hacarus.com/api");
        public static string bearer;
        public static string accessToken;
        public static string currentContextId;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public IActionResult Login(
            string loginClient, string clientId, string clientSecret
        )
        {
            AccessTokenResponse response = hacarusVisualInspection.Authorize(clientId, clientSecret);
            if (response.errors == null)
            {
                bearer = response.data.access_token;
            }

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);

            return Index();
        }

        [HttpPost]
        public IActionResult GetItems(
            string getItems
        )
        {
            ItemsResponse response = hacarusVisualInspection.GetItems();

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "getItems";

            return Index();
        }

        [HttpPost]
        public IActionResult GetAlgorithms(
            string getAlgorithms
        )
        {
            AlgorithmResponse response = hacarusVisualInspection.GetAlgorithms();

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "getAlgorithms";

            return Index();
        }

        [HttpPost]
        public IActionResult GetModels(
            string getAlgorithms
        )
        {
            ModelsResponse response = hacarusVisualInspection.GetModels();

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "getModels";

            return Index();
        }

        [HttpPost]
        public IActionResult Train(
            string train, string name, string algorithmId, List<string> itemIds
        )
        {
            AlgorithmParameter algorithmParameter = new AlgorithmParameter();
            algorithmParameter.algorithm_parameter_id = 221;
            algorithmParameter.value = "50";

            if (string.IsNullOrEmpty(algorithmId))
            {
                algorithmId = "hacarus-fused-lasso";
            }

            if (string.IsNullOrEmpty(name))
            {
                name = DateTime.Now.ToString();
            }

            ModelResponse response = hacarusVisualInspection.Train(algorithmId, name, itemIds.ToArray(), new AlgorithmParameter[] { algorithmParameter });

            Console.WriteLine("IFFFF " + itemIds.Count);

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "train";

            return Index();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            string upload, string good, string training, ICollection<IFormFile> files
        )
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            Console.WriteLine("ENDDDD" + files.Count);

            List<ImageModel> filenames = new List<ImageModel>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        var image = new ImageModel();
                        image.filename = Path.Combine(uploads, file.FileName);
                        image.contentType = file.ContentType;
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


            Console.WriteLine("isGood ? " + isGood + "|" + good);
            Console.WriteLine("isTraining ? " + isTraining + "|" + training);

            UploadResponse response = hacarusVisualInspection.Upload(filenames, isGood, isTraining);

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "upload";

            return Index();
        }

        [HttpPost]
        public IActionResult Serve(
            string serve, string itemIdServe, int modelIdServe
        )
        {
            PredictResponse response = hacarusVisualInspection.Serve(new string[] { itemIdServe }, modelIdServe);

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "serve";

            return Index();
        }


        [HttpPost]
        public IActionResult GetItem(
            string getItem, string itemId
        )
        {
            ItemResponse response = hacarusVisualInspection.GetItem(itemId);

            ViewData["HttpResponse"] = "Status code: " + (int)response.httpResponse.StatusCode + " " + response.httpResponse.StatusCode;
            ViewData["StringMessage"] = hacarusVisualInspection.StringMessage;
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Active = "getItem";

            return Index();
        }

        public IActionResult Index()
        {
            ViewBag.BearerAvailable = !string.IsNullOrEmpty(bearer);
            ViewBag.Algorithms = new List<Algorithm>();
            ViewBag.TrainingItems = new List<Item>();
            ViewBag.PredictItems = new List<Item>();
            ViewBag.Models = new List<ModelData>();

            if (ViewBag.BearerAvailable)
            {
                var algorithmResponse = hacarusVisualInspection.GetAlgorithms();
                var trainingResponse = hacarusVisualInspection.GetItems();
                ModelsResponse modelsResponse = hacarusVisualInspection.GetModels();
                Console.Write("START IFFF");
                if (trainingResponse != null && trainingResponse.data != null)
                {
                    ViewBag.TrainingItems = trainingResponse.data.training;
                    ViewBag.PredictItems = trainingResponse.data.predict;
                    Console.Write(trainingResponse.data.training.Count);
                }

                if (algorithmResponse != null && algorithmResponse.data != null)
                {
                    ViewBag.Algorithms = algorithmResponse.data;
                    Console.Write(algorithmResponse.data.Count);
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
