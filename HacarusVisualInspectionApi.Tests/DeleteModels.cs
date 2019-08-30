using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class DeleteModels
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/DeleteModelSuccess.txt");
            var Client = MockGenerator.MockRestClient<PredictResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            DeleteResponse Response = VisualInspection.DeleteModels(new int[] { 1000 });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Status.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedModelIdDoesNotExist()
        {
            Console.WriteLine("FailedModelIdDoesNotExist Start");
            var JsonString = File.ReadAllText("../../../Files/DeleteModelFailed.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            DeleteResponse Response = VisualInspection.DeleteModels(new int[] { 1001 });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Details.Equals("No model found"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/model?"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedModelIdDoesNotExist End");
        }
    }
}
