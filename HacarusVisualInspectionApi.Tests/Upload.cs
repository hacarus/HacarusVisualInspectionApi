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
            var Json = File.ReadAllText("../../../Files/UploadSuccess.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.OK, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;

            var file = new FileModel();
            file.filename = "../../../Files/NewItem.JPG";
            file.contentType = "jpg";

            UploadResponse response = visualInspection.Upload(new List<FileModel> { file }, null, false);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.item_ids.Count.Equals(1));
            Assert.IsTrue(response.data.item_ids[0].Equals("NewItem"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidFile()
        {
            Console.WriteLine("FailedInvalidFile Start");
            var Json = File.ReadAllText("../../../Files/UploadFailedInvalidFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;

            var file = new FileModel();
            file.filename = "../../../Files/NewItem invalid.name.JPG";
            file.contentType = "jpg";

            UploadResponse response = visualInspection.Upload(new List<FileModel> { file }, null, false);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(response.errors.title.Equals("Invalid Request"));
            Assert.IsTrue(response.errors.details.Equals("NewItem invalid.name.png"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedInvalidFile End");
        }

        [TestMethod]
        public void FailedNoFile()
        {
            Console.WriteLine("FailedNoFile Start");
            var Json = File.ReadAllText("../../../Files/UploadFailedNoFile.txt");
            var Client = MockGenerator.MockRestClient<UploadResponse>(HttpStatusCode.BadRequest, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;

            UploadResponse response = visualInspection.Upload(new List<FileModel> { }, null, false);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsTrue(response.errors.title.Equals("No images to upload"));
            Assert.IsNull(response.errors.details);
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/upload"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.BadRequest));
            Console.WriteLine("FailedNoFile End");
        }

    }
}
