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
            var JSONString = File.ReadAllText("../../../Files/GetModels.txt");
            var Client = MockGenerator.MockRestClient<ModelsResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            ModelsResponse Response = visualInspection.GetModels();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.Count.Equals(1));
            Assert.IsTrue(Response.data[0].active);
            Assert.IsTrue(Response.data[0].algorithm_id.Equals("one-class-svm"));
            Assert.IsFalse(Response.data[0].context_default);
            Assert.IsTrue(Response.data[0].created_at.Equals(DateTime.Parse("2019-06-10T08:28:16Z").ToUniversalTime()));
            Assert.IsTrue(Response.data[0].model_id.Equals(269));
            Assert.IsTrue(Response.data[0].name.Equals("Test-20190610-01"));
            Assert.IsTrue(Response.data[0].status.Equals("active"));
            Assert.IsTrue(Response.data[0].version.Equals("model-2019061008:28:16"));
            Console.WriteLine("Success End");
        }
    }
}
