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
    public class ActivateLicense
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/ActivateLicenseSuccess.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.customer_id.Equals("test_customer_id"));
            Assert.IsTrue(Response.data.status.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidCustomerID()
        {
            Console.WriteLine("FailedInvalidCustomerID Start");
            var JsonString = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");
           
            LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile, "invalid_test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.Errors.Title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidCustomerID End");
        }

        [TestMethod]
        public void FailedInvalidLicenseFile()
        {
            Console.WriteLine("FailedInvalidLicenseFile Start");
            var JsonString = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.Errors.Title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidLicenseFile End");
        }

        [TestMethod]
        public void FailedLicenseFileExists()
        {
            Console.WriteLine("FailedLicenseFileExists Start");
            var JsonString = File.ReadAllText("../../../Files/ActivateLicenseFailedLicenseFileExists.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = VisualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.Errors.Title.Equals("Invalid license!"));
            Assert.IsTrue(Response.Errors.Details.Equals("License already exists"));
            Console.WriteLine("FailedLicenseFileExists End");
        }
    }
}
