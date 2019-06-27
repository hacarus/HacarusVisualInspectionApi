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
            var JSONString = File.ReadAllText("../../../Files/GetAlgorithmsSuccess.txt");
            var Client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            AlgorithmResponse Response = visualInspection.GetAlgorithms();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data[0].algorithm_id.Equals("one-class-svm"));
            Assert.IsTrue(Response.data[0].name.Equals("Patch One Class SVM"));
            Assert.IsTrue(Response.data[0].parameters.Count.Equals(1));
            Assert.IsTrue(Response.data[0].parameters[0].algorithm_parameter_id.Equals(249));
            Assert.IsTrue(Response.data[0].parameters[0].created_at.Equals(DateTime.Parse("2019-06-06T23:29:17Z").ToUniversalTime()));
            Assert.IsTrue(Response.data[0].parameters[0].data_type.Equals("tuple"));
            Assert.IsTrue(Response.data[0].parameters[0].model_parameter);
            Assert.IsTrue(Response.data[0].parameters[0].name.Equals("patch_size"));
            Assert.IsTrue(Response.data[0].parameters[0].updated_at.Equals(DateTime.Parse("2019-06-06T23:30:20Z").ToUniversalTime()));
            Assert.IsTrue(Response.data[0].parameters[0].value.Equals("[4, 4]"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedNoAlgorithm()
        {
            Console.WriteLine("FailedNoAlgorithm Start");
            var JSONString = File.ReadAllText("../../../Files/GetAlgorithmsFailedNoAlgorithm.txt");
            var Client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.NotFound, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            AlgorithmResponse Response = visualInspection.GetAlgorithms();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.errors);
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.errors.title.Equals("No algorithms found"));
            Assert.IsTrue(Response.errors.source.pointer.Equals("/api/v1/algorithms"));
            Assert.IsTrue(Response.errors.status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedNoAlgorithm End");

        }
    }
}