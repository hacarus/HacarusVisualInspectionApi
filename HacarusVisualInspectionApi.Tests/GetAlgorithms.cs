using System;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests.TestFiles
{
    [TestClass]
    public class GetAlgorithms
    {
        [TestMethod]
        public void GetAlgorithms_Success()
        {
            Console.WriteLine("GetAlgorithms_Success Start");
            var client = MockGenerator.MockRestClient<AlgorithmResponse>(HttpStatusCode.OK, "{ \"data\": [ { \"algorithm_id\": \"one-class-svm\", \"name\": \"Patch One Class SVM\", \"parameters\": [ { \"algorithm_parameter_id\": 249, \"created_at\": \"2019-06-06T23:29:17Z\", \"data_type\": \"tuple\", \"model_parameter\": true, \"name\": \"patch_size\", \"updated_at\": \"2019-06-06T23:30:20Z\", \"value\": \"[4, 4]\" } ] } ] }");
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
            Assert.IsTrue(response.data[0].parameters[0].created_at.Equals("2019-06-06T23:29:17Z"));
            Assert.IsTrue(response.data[0].parameters[0].data_type.Equals("tuple"));
            Assert.IsTrue(response.data[0].parameters[0].model_parameter);
            Assert.IsTrue(response.data[0].parameters[0].name.Equals("patch_size"));
            Assert.IsTrue(response.data[0].parameters[0].updated_at.Equals("2019-06-06T23:30:20Z"));
            Assert.IsTrue(response.data[0].parameters[0].value.Equals("[4, 4]"));
            Console.WriteLine("GetAlgorithms_Success End");

        }
    }
}