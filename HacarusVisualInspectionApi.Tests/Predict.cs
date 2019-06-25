using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class Predict
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var Json = File.ReadAllText("../../../Files/PredictSuccess.txt");
            var Client = MockGenerator.MockRestClient<PredictResponse>(HttpStatusCode.OK, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;

            PredictResponse response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.item_ids.Count.Equals(1));
            Assert.IsTrue(response.data.item_ids[0].Equals("NewItem"));
            Assert.IsTrue(response.data.model_version.Equals("model-2019061101:26:07"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedItemIdDoesNotExist()
        {
            Console.WriteLine("FailedItemIdDoesNotExist Start");
            var Json = File.ReadAllText("../../../Files/PredictFailedItemIdDoesNotExist.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.NotFound, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            PredictResponse response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(response.errors.title.Equals("Cannot find items"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/serve"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedItemIdDoesNotExist End");
        }

        [TestMethod]
        public void FailedNoModel()
        {
            Console.WriteLine("FailedNoModel Start");
            var Json = File.ReadAllText("../../../Files/PredictFailedNoModel.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            PredictResponse response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(response.errors.title.Equals("There is no available model"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/serve"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedItemIdDoesNotExists End");
        }
    }
}
