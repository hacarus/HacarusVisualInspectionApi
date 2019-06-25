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
            var json = File.ReadAllText("../../../Files/GetAlgorithmsSuccess.txt");
            var client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AlgorithmResponse response = visualInspection.GetAlgorithms();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data[0].algorithm_id.Equals("one-class-svm"));
            Assert.IsTrue(response.data[0].name.Equals("Patch One Class SVM"));
            Assert.IsTrue(response.data[0].parameters.Count.Equals(1));
            Assert.IsTrue(response.data[0].parameters[0].algorithm_parameter_id.Equals(249));
            Assert.IsTrue(response.data[0].parameters[0].created_at.Equals(DateTime.Parse("2019-06-06T23:29:17Z").ToUniversalTime()));
            Assert.IsTrue(response.data[0].parameters[0].data_type.Equals("tuple"));
            Assert.IsTrue(response.data[0].parameters[0].model_parameter);
            Assert.IsTrue(response.data[0].parameters[0].name.Equals("patch_size"));
            Assert.IsTrue(response.data[0].parameters[0].updated_at.Equals(DateTime.Parse("2019-06-06T23:30:20Z").ToUniversalTime()));
            Assert.IsTrue(response.data[0].parameters[0].value.Equals("[4, 4]"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedNoAlgorithm()
        {
            Console.WriteLine("FailedNoAlgorithm Start");
            var json = File.ReadAllText("../../../Files/GetAlgorithmsFailedNoAlgorithm.txt");
            var client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.NotFound, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            AlgorithmResponse response = visualInspection.GetAlgorithms();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(response.errors.title.Equals("No algorithms found"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/algorithms"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedNoAlgorithm End");

        }
    }
}