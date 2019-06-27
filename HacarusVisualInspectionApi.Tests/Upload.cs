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
            var JSONString = File.ReadAllText("../../../Files/UploadSuccess.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);

            var file = new FileModel("../../../Files/NewItem.JPG", "jpg");
            UploadResponse Response = visualInspection.Upload(new List<FileModel> { file });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.item_ids.Count.Equals(1));
            Assert.IsTrue(Response.data.item_ids[0].Equals("NewItem"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidFile()
        {
            Console.WriteLine("FailedInvalidFile Start");
            var JSONString = File.ReadAllText("../../../Files/UploadFailedInvalidFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);

            var file = new FileModel("../../../Files/NewItem invalid.name.JPG", "jpg");
           
            UploadResponse Response = visualInspection.Upload(new List<FileModel> { file }, true);
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(Response.errors.title.Equals("Invalid Request"));
            Assert.IsTrue(Response.errors.details.Equals("NewItem invalid.name.png"));
            Assert.IsTrue(Response.errors.source.pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(Response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedInvalidFile End");
        }

        [TestMethod]
        public void FailedNoFile()
        {
            Console.WriteLine("FailedNoFile Start");
            var JSONString = File.ReadAllText("../../../Files/UploadFailedNoFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);

            UploadResponse Response = visualInspection.Upload(new List<FileModel> { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(Response.errors.title.Equals("No images to upload"));
            Assert.IsNull(Response.errors.details);
            Assert.IsTrue(Response.errors.source.pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(Response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedNoFile End");
        }

    }
}
