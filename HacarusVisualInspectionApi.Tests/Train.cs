using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class Train
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/TrainSuccess.txt");
            var Client = MockGenerator.MockRestClient<ModelResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            TrainResponse Response = VisualInspection.Train("OC", "6/11/19 10:26:07 AM", new string[] { "iItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsFalse(Response.Data.Active);
            Assert.IsTrue(Response.Data.AlgorithmId.Equals("RF"));
            Assert.IsTrue(Response.Data.AlgorithmType.Equals("unsupervised"));
            Assert.IsTrue(Response.Data.ContextDefault);
            Assert.IsTrue(Response.Data.ContextId.Equals(1033));
            Assert.IsTrue(Response.Data.CreatedAt.Equals(DateTime.Parse("2019-09-09T10:05:32Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data.ModelId.Equals("c5e77995-1036-5a54-9e8a-edd450362802"));
            Assert.IsNull(Response.Data.ImageUrl);
            Assert.IsTrue(Response.Data.Name.Equals("rgi1"));
            Assert.IsTrue(Response.Data.Name.Equals("rgi1"));
            Assert.IsTrue(Response.Data.NgImgCount.Equals(0));
            Assert.IsTrue(Response.Data.OkImgCount.Equals(0));
            Assert.IsNull(Response.Data.Recall);
            Assert.IsNull(Response.Data.Precision);
            Assert.IsTrue(Response.Data.Status.Equals("creating"));
            Assert.IsNull(Response.Data.StatusText);
            Assert.IsTrue(Response.Data.UpdatedAt.Equals(DateTime.Parse("2019-09-09T10:05:32Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data.Version.Equals("0.3.3-1568023532.1785076"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidId()
        {
            Console.WriteLine("FailedInvalidId Start");
            var JsonString = File.ReadAllText("../../../Files/TrainFailedInvalidId.txt");
            var Client = MockGenerator.MockRestClient<ModelResponse>(HttpStatusCode.Forbidden, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            TrainResponse Response = VisualInspection.Train("OC", "6/11/19 10:26:07 AM", new string[] { "InvalidItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.Errors.Title.Equals("You do not have access to one or more item ids provided"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/train"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Forbidden));
            Console.WriteLine("FailedInvalidId End");

        }
    }
}
