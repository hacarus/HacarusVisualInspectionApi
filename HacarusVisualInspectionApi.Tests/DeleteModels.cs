﻿using System;
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

            DeleteResponse Response = VisualInspection.Delete(new string[] { "ModelId" });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedItemIdDoesNotExist()
        {
            Console.WriteLine("FailedItemIdDoesNotExist Start");
            var JsonString = File.ReadAllText("../../../Files/DeleteFailedModelIdDoesNotExist.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            DeleteResponse Response = VisualInspection.Delete(new string[] { "ModelId" });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Details.Equals("No model found"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/context/ModelId/model?"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedModelIdDoesNotExist End");
        }

        //[TestMethod]
        //public void FailedNoModel()
        //{
        //    Console.WriteLine("FailedNoModel Start");
        //    var JsonString = File.ReadAllText("../../../Files/PredictFailedNoModel.txt");
        //    var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JsonString);
        //    HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
        //    PredictResponse Response = VisualInspection.Serve(new string[] { "NewItem" });
        //    Assert.IsNotNull(Response);
        //    Assert.IsNotNull(Response.HttpResponse);
        //    Assert.IsNotNull(Response.Errors);
        //    Assert.IsNull(Response.Data);
        //    Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
        //    Assert.IsTrue(Response.Errors.Title.Equals("There is no available model"));
        //    Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/serve"));
        //    Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.BadRequest));
        //    Console.WriteLine("FailedItemIdDoesNotExists End");
        //}
    }
}
