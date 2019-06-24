using System;
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
        public void ActivateLicense_Success()
        {
            Console.WriteLine("ActivateLicense_Success Start");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, "{\"data\": {\"customer_id\": \"test_customer_id\", \"status\": \"ok\"}}");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.customer_id.Equals("test_customer_id"));
            Assert.IsTrue(response.data.status.Equals("ok"));
            Console.WriteLine("ActivateLicense_Success End");
        }

        [TestMethod]
        public void ActivateLicense_Failed_InvalidCustomerID()
        {
            Console.WriteLine("ActivateLicense_Failed_InvalidCustomerID Start");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, "{ \"errors\": { \"detail\": null, \"source\": { \"pointer\": \"/api/auth/license\" }, \"status\": 403, \"title\": \"Invalid license!\" } }");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "invalid_test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("ActivateLicense_Failed_InvalidCustomerID End");
        }

        [TestMethod]
        public void ActivateLicense_Failed_InvalidLicenseFile()
        {
            Console.WriteLine("ActivateLicense_Failed_InvalidLicenseFile Start");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, "{ \"errors\": { \"detail\": null, \"source\": { \"pointer\": \"/api/auth/license\" }, \"status\": 403, \"title\": \"Invalid license!\" } }");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("ActivateLicense_Failed_InvalidLicenseFile End");
        }

        [TestMethod]
        public void ActivateLicense_Failed_LicenseFileExists()
        {
            Console.WriteLine("ActivateLicense_Failed_LicenseFileExists Start");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, "{ \"errors\": { \"detail\": \"License already exists\", \"source\": { \"pointer\": \"/api/auth/license\" }, \"status\": 403, \"title\": \"Invalid license!\" } }");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Assert.IsTrue(response.errors.details.Equals("License already exists"));
            Console.WriteLine("ActivateLicense_Failed_LicenseFileExists End");
        }
    }
}
