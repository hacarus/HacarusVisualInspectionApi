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
            var Json = File.ReadAllText("../../../Files/TrainSuccess.txt");
            var Client = MockGenerator.MockRestClient<ModelResponse>(HttpStatusCode.OK, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            ModelResponse response = visualInspection.Train("one-class-svm", "6/11/19 10:26:07 AM", new string[] { "iItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsFalse(response.data.active);
            Assert.IsTrue(response.data.algorithm_id.Equals("one-class-svm"));
            Assert.IsFalse(response.data.context_default);
            Assert.IsTrue(response.data.context_id.Equals(1000));
            Assert.IsTrue(response.data.created_at.Equals(DateTime.Parse("2019-06-11T01:26:08Z").ToUniversalTime()));
            Assert.IsTrue(response.data.model_id.Equals(270));
            Assert.IsTrue(response.data.name.Equals("6/11/19 10:26:07 AM"));
            Assert.IsTrue(response.data.status.Equals("creating"));
            Assert.IsTrue(response.data.updated_at.Equals(DateTime.Parse("2019-06-11T10:26:07Z").ToUniversalTime()));
            Assert.IsTrue(response.data.version.Equals("model-2019061101:26:07"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidId()
        {
            Console.WriteLine("FailedInvalidId Start");
            var Json = File.ReadAllText("../../../Files/TrainFailedInvalidId.txt");
            var Client = MockGenerator.MockRestClient<ModelResponse>(HttpStatusCode.Forbidden, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            ModelResponse response = visualInspection.Train("one-class-svm", "6/11/19 10:26:07 AM", new string[] { "InvalidItemID" }, new AlgorithmParameter[] { });
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("You do not have access to one or more item ids provided"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/train"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.Forbidden));
            Console.WriteLine("FailedInvalidId End");

        }
    }
}
