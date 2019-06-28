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
            ModelResponse Response = VisualInspection.Train("one-class-svm", "6/11/19 10:26:07 AM", new string[] { "iItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsFalse(Response.data.active);
            Assert.IsTrue(Response.data.algorithm_id.Equals("one-class-svm"));
            Assert.IsFalse(Response.data.context_default);
            Assert.IsTrue(Response.data.context_id.Equals(1000));
            Assert.IsTrue(Response.data.created_at.Equals(DateTime.Parse("2019-06-11T01:26:08Z").ToUniversalTime()));
            Assert.IsTrue(Response.data.model_id.Equals(270));
            Assert.IsTrue(Response.data.name.Equals("6/11/19 10:26:07 AM"));
            Assert.IsTrue(Response.data.status.Equals("creating"));
            Assert.IsTrue(Response.data.updated_at.Equals(DateTime.Parse("2019-06-11T10:26:07Z").ToUniversalTime()));
            Assert.IsTrue(Response.data.version.Equals("model-2019061101:26:07"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidId()
        {
            Console.WriteLine("FailedInvalidId Start");
            var JsonString = File.ReadAllText("../../../Files/TrainFailedInvalidId.txt");
            var Client = MockGenerator.MockRestClient<ModelResponse>(HttpStatusCode.Forbidden, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ModelResponse Response = VisualInspection.Train("one-class-svm", "6/11/19 10:26:07 AM", new string[] { "InvalidItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.Errors.Title.Equals("You do not have access to one or more item ids provided"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/train"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Forbidden));
            Console.WriteLine("FailedInvalidId End");

        }
    }
}
