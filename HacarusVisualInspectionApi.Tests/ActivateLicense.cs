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
            var JSONString = File.ReadAllText("../../../Files/ActivateLicenseSuccess.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = visualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.customer_id.Equals("test_customer_id"));
            Assert.IsTrue(Response.data.status.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidCustomerID()
        {
            Console.WriteLine("FailedInvalidCustomerID Start");
            var JSONString = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");
           
            LicenseResponse Response = visualInspection.ActivateLicense(LicenseFile, "invalid_test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidCustomerID End");
        }

        [TestMethod]
        public void FailedInvalidLicenseFile()
        {
            Console.WriteLine("FailedInvalidLicenseFile Start");
            var JSONString = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = visualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidLicenseFile End");
        }

        [TestMethod]
        public void FailedLicenseFileExists()
        {
            Console.WriteLine("FailedLicenseFileExists Start");
            var JSONString = File.ReadAllText("../../../Files/ActivateLicenseFailedLicenseFileExists.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            var LicenseFile = new FileModel("../../../Files/license0", "txt");

            LicenseResponse Response = visualInspection.ActivateLicense(LicenseFile, "test_customer_id");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNull(Response.data);
            Assert.IsNotNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(Response.errors.title.Equals("Invalid license!"));
            Assert.IsTrue(Response.errors.details.Equals("License already exists"));
            Console.WriteLine("FailedLicenseFileExists End");
        }
    }
}
