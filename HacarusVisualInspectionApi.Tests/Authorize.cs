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
            var JsonString = File.ReadAllText("../../../Files/AuthorizeSuccess.txt");
            var Client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            AccessTokenResponse Response = VisualInspection.Authorize("ValidClientId", "ValidClientSecret");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.AccessToken.Equals("GeneratedAccessToken"));
            Assert.IsTrue(Response.Data.Expires.Equals(2592000));
            Console.WriteLine("Success End");

        }

        [TestMethod]
        public void FailedClientID()
        {
            Console.WriteLine("FailedClientID Start");
            var JsonString = File.ReadAllText("../../../Files/AuthorizeFailedClientID.txt");
            var Client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            AccessTokenResponse Response = VisualInspection.Authorize("InvalidClientId", "ValidClientSecret");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(Response.Errors.Title.Equals("Cannot find client information"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedClientID End");

        }

        [TestMethod]
        public void FailedClientSecret()
        {
            Console.WriteLine("FailedClientSecret Start");
            var JsonString = File.ReadAllText("../../../Files/AuthorizeFailedClientSecret.txt");
            var Client = MockGenerator.MockRestClient<AccessTokenResponse>(HttpStatusCode.Unauthorized, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            AccessTokenResponse Response = VisualInspection.Authorize("ValidClientId", "InvalidClientSecret");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(Response.Errors.Title.Equals("Client id and secret mismatch"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("https://sdd-api.hacarus.com/api/auth/token"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedClientSecret End");
        }

    }
}
