using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class AddAnnotation
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/AddAnnotationSuccess.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            AddAnnotationResponse Response = VisualInspection.AddAnnotation(LicenseFile);
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Equals("ok"));
            Console.WriteLine("Success End");
        }

        //[TestMethod]
        //public void FailedInvalidLicenseFile()
        //{
        //    Console.WriteLine("FailedInvalidLicenseFile Start");
        //    var JsonString = File.ReadAllText("../../../Files/ActivateLicenseFailed.txt");
        //    var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JsonString);
        //    HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
        //    var LicenseFile = new FileModel("../../../Files/license0", "txt");

        //    LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile);
        //    Assert.IsNotNull(Response);
        //    Assert.IsNotNull(Response.HttpResponse);
        //    Assert.IsNull(Response.Data);
        //    Assert.IsNotNull(Response.Errors);
        //    Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
        //    Assert.IsTrue(Response.Errors.Title.Equals("Invalid license!"));
        //    Console.WriteLine("FailedInvalidLicenseFile End");
        //}

        //[TestMethod]
        //public void FailedLicenseFileExists()
        //{
        //    Console.WriteLine("FailedLicenseFileExists Start");
        //    var JsonString = File.ReadAllText("../../../Files/ActivateLicenseFailedLicenseFileExists.txt");
        //    var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JsonString);
        //    HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
        //    var LicenseFile = new FileModel("../../../Files/license0", "txt");

        //    LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile);
        //    Assert.IsNotNull(Response);
        //    Assert.IsNotNull(Response.HttpResponse);
        //    Assert.IsNull(Response.Data);
        //    Assert.IsNotNull(Response.Errors);
        //    Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
        //    Assert.IsTrue(Response.Errors.Title.Equals("Invalid license!"));
        //    Assert.IsTrue(Response.Errors.Details.Equals("License already exists"));
        //    Console.WriteLine("FailedLicenseFileExists End");
        //}
    }
}
