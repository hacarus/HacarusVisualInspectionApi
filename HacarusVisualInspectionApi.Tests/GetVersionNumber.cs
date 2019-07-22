using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetVersionNumber
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetVersionNumber.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            VersionResponse Response = VisualInspection.GetVersionNumber();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.VersionNumber);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.VersionNumber.Equals("1.0.0.0"));
            Console.WriteLine("Success End");
        }
    }
}
