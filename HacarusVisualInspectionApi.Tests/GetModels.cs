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
            var JsonString = File.ReadAllText("../../../Files/GetModels.txt");
            var Client = MockGenerator.MockRestClient<ModelsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ModelsResponse Response = VisualInspection.GetModels();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Count.Equals(1));
            Assert.IsTrue(Response.Data[0].Active);
            Assert.IsTrue(Response.Data[0].AlgorithmId.Equals("one-class-svm"));
            Assert.IsFalse(Response.Data[0].ContextDefault);
            Assert.IsTrue(Response.Data[0].CreatedAt.Equals(DateTime.Parse("2019-06-10T08:28:16Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data[0].ModelId.Equals(269));
            Assert.IsTrue(Response.Data[0].Name.Equals("Test-20190610-01"));
            Assert.IsTrue(Response.Data[0].Status.Equals("active"));
            Assert.IsTrue(Response.Data[0].Version.Equals("model-2019061008:28:16"));
            Console.WriteLine("Success End");
        }
    }
}
