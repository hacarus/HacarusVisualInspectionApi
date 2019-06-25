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
            var json = File.ReadAllText("../../../Files/ActivateLicenseSuccess.txt");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/Files/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.customer_id.Equals("test_customer_id"));
            Assert.IsTrue(response.data.status.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedInvalidCustomerID()
        {
            Console.WriteLine("FailedInvalidCustomerID Start");
            var json = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/Files/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "invalid_test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidCustomerID End");
        }

        [TestMethod]
        public void FailedInvalidLicenseFile()
        {
            Console.WriteLine("FailedInvalidLicenseFile Start");
            var json = File.ReadAllText("../../../Files/ActivateLicenseFailedInvalidCustomerID.txt");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/Files/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Console.WriteLine("FailedInvalidLicenseFile End");
        }

        [TestMethod]
        public void FailedLicenseFileExists()
        {
            Console.WriteLine("FailedLicenseFileExists Start");
            var json = File.ReadAllText("../../../Files/ActivateLicenseFailedLicenseFileExists.txt");
            var client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.Forbidden, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            var file = new FileModel();
            file.filename = "/Users/christinealcachupas/Projects/Hacarus/HacarusVisualInspectionApi/HacarusVisualInspectionApi.Tests/Files/license0";
            file.contentType = "txt";

            LicenseResponse response = visualInspection.ActivateLicense(file, "test_customer_id");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNull(response.data);
            Assert.IsNotNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Forbidden));
            Assert.IsTrue(response.errors.title.Equals("Invalid license!"));
            Assert.IsTrue(response.errors.details.Equals("License already exists"));
            Console.WriteLine("FailedLicenseFileExists End");
        }
    }
}
