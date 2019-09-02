using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetWorkers
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetWorkersSuccess.txt");
            var Client = MockGenerator.MockRestClient<WorkersResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            WorkersResponse Response = VisualInspection.GetWorkers();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Predicting.Length.Equals(1));
            Assert.IsTrue(Response.Data.Training.Length.Equals(1));
            Console.WriteLine("Success End");
        }
    }
}
