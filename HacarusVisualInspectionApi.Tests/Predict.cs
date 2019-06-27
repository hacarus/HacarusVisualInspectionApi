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
            var JSONString = File.ReadAllText("../../../Files/PredictSuccess.txt");
            var Client = MockGenerator.MockRestClient<PredictResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);

            PredictResponse Response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.item_ids.Count.Equals(1));
            Assert.IsTrue(Response.data.item_ids[0].Equals("NewItem"));
            Assert.IsTrue(Response.data.model_version.Equals("model-2019061101:26:07"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedItemIdDoesNotExist()
        {
            Console.WriteLine("FailedItemIdDoesNotExist Start");
            var JSONString = File.ReadAllText("../../../Files/PredictFailedItemIdDoesNotExist.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.NotFound, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            PredictResponse Response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.errors.title.Equals("Cannot find items"));
            Assert.IsTrue(Response.errors.source.pointer.Equals("/api/v1/serve"));
            Assert.IsTrue(Response.errors.status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedItemIdDoesNotExist End");
        }

        [TestMethod]
        public void FailedNoModel()
        {
            Console.WriteLine("FailedNoModel Start");
            var JSONString = File.ReadAllText("../../../Files/PredictFailedNoModel.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            PredictResponse Response = visualInspection.Serve(new string[] { "NewItem" });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(Response.errors.title.Equals("There is no available model"));
            Assert.IsTrue(Response.errors.source.pointer.Equals("/api/v1/serve"));
            Assert.IsTrue(Response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedItemIdDoesNotExists End");
        }
    }
}
