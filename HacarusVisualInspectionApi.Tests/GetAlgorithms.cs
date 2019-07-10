using System;
using System.Globalization;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetAlgorithms
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetAlgorithmsSuccess.txt");
            var Client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            AlgorithmResponse Response = VisualInspection.GetAlgorithms();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data[0].AlgorithmId.Equals("one-class-svm"));
            Assert.IsTrue(Response.Data[0].Name.Equals("Patch One Class SVM"));
            Assert.IsTrue(Response.Data[0].Parameters.Count.Equals(1));
            Assert.IsTrue(Response.Data[0].Parameters[0].AlgorithmParameterId.Equals(249));
            Assert.IsTrue(Response.Data[0].Parameters[0].CreatedAt.Equals(DateTime.Parse("2019-06-06T23:29:17Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data[0].Parameters[0].DataType.Equals("tuple"));
            Assert.IsTrue(Response.Data[0].Parameters[0].ModelParameter);
            Assert.IsTrue(Response.Data[0].Parameters[0].Name.Equals("patch_size"));
            Assert.IsTrue(Response.Data[0].Parameters[0].UpdatedAt.Equals(DateTime.Parse("2019-06-06T23:30:20Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data[0].Parameters[0].Value.Equals("[4, 4]"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedNoAlgorithm()
        {
            Console.WriteLine("FailedNoAlgorithm Start");
            var JsonString = File.ReadAllText("../../../Files/GetAlgorithmsFailedNoAlgorithm.txt");
            var Client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            AlgorithmResponse Response = VisualInspection.GetAlgorithms();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals("No algorithms found"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/algorithms"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedNoAlgorithm End");

        }
    }
}