using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetModels
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var json = File.ReadAllText("../../../Files/GetModels.txt");
            var client = MockGenerator.MockRestClient<ModelsResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ModelsResponse response = visualInspection.GetModels();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.Count.Equals(1));
            Assert.IsTrue(response.data[0].active);
            Assert.IsTrue(response.data[0].algorithm_id.Equals("one-class-svm"));
            Assert.IsFalse(response.data[0].context_default);
            Assert.IsTrue(response.data[0].created_at.Equals(DateTime.Parse("2019-06-10T08:28:16Z").ToUniversalTime()));
            Assert.IsTrue(response.data[0].model_id.Equals(269));
            Assert.IsTrue(response.data[0].name.Equals("Test-20190610-01"));
            Assert.IsTrue(response.data[0].status.Equals("active"));
            Assert.IsTrue(response.data[0].version.Equals("model-2019061008:28:16"));
            Console.WriteLine("Success End");
        }
    }
}
