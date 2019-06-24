using System;
using System.Diagnostics;
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
        public void Login_Success()
        {
            Console.WriteLine("Login_Success Start");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.OK, "{\"data\": {\"access_token\": \"TestAccessToken\",\"expires\": 2592000}}");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("ValidClientId", "ValidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.access_token.Equals("TestAccessToken"));
            Assert.IsTrue(response.data.expires.Equals(2592000));
            Console.WriteLine("Login_Success End");

        }

        [TestMethod]
        public void Login_Failed_ClientID()
        {
            Console.WriteLine("Login_Failed_ClientID Start");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, "{ \"errors\": { \"detail\": null, \"source\": { pointer: \"/api/auth/token\" }, \"status\": 401, \"title\": \"Cannot find client information\" } }");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("InvalidClientId", "ValidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(response.errors.title.Equals("Cannot find client information"));
            Console.WriteLine("Login_Failed_ClientID End");

        }

        [TestMethod]
        public void Login_Failed_ClientSecret()
        {
            Console.WriteLine("Login_Failed_ClientSecret Start");
            var client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, "{ \"errors\": { \"detail\": null, \"source\": { \"pointer\": \"/api/auth/token\" }, \"status\": 401, \"title\": \"Client id and secret mismatch\" } }");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AccessTokenResponse response = visualInspection.Authorize("ValidClientId", "InvalidClientSecret");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(response.errors.title.Equals("Client id and secret mismatch"));
            Console.WriteLine("Login_Failed_ClientSecret End");

        }

    }
}
