using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class Upload
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/UploadSuccess.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            var file = new FileModel("../../../Files/NewItem.JPG", "jpg");
            UploadResponse Response = VisualInspection.Upload(new List<FileModel> { file });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.Errors);;
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.item_ids.Count.Equals(1));
            Assert.IsTrue(Response.data.item_ids[0].Equals("NewItem"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidFile()
        {
            Console.WriteLine("FailedInvalidFile Start");
            var JsonString = File.ReadAllText("../../../Files/UploadFailedInvalidFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            var file = new FileModel("../../../Files/NewItem invalid.name.JPG", "jpg");
           
            UploadResponse Response = VisualInspection.Upload(new List<FileModel> { file }, true);
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);;
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(Response.Errors.Title.Equals("Invalid Request"));
            Assert.IsTrue(Response.Errors.Details.Equals("NewItem invalid.name.png"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedInvalidFile End");
        }

        [TestMethod]
        public void FailedNoFile()
        {
            Console.WriteLine("FailedNoFile Start");
            var JsonString = File.ReadAllText("../../../Files/UploadFailedNoFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            UploadResponse Response = VisualInspection.Upload(new List<FileModel> { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(Response.Errors.Title.Equals("No images to upload"));
            Assert.IsNull(Response.Errors.Details);
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedNoFile End");
        }

    }
}
