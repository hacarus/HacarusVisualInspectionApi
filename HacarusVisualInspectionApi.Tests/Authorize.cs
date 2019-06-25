using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RestSharp;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class Authorize
    {

        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var json = File.ReadAllText("../../../Files/AuthorizeSuccess.txt");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("ValidClientId", "ValidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.access_token.Equals("GeneratedAccessToken"));
            Assert.IsTrue(response.data.expires.Equals(2592000));
            Console.WriteLine("Success End");

        }

        [TestMethod]
        public void FailedClientID()
        {
            Console.WriteLine("FailedClientID Start");
            var json = File.ReadAllText("../../../Files/AuthorizeFailedClientID.txt");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("InvalidClientId", "ValidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(response.errors.title.Equals("Cannot find client information"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedClientID End");

        }

        [TestMethod]
        public void FailedClientSecret()
        {
            Console.WriteLine("FailedClientSecret Start");
            var json = File.ReadAllText("../../../Files/AuthorizeFailedClientSecret.txt");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("ValidClientId", "InvalidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(response.errors.title.Equals("Client id and secret mismatch"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/auth/token"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedClientSecret End");
        }

    }
}
