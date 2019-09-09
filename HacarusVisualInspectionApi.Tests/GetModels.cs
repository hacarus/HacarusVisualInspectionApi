using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetModels
    {
        [TestMethod]
        public void SuccessActive()
        {
            Console.WriteLine("SuccessActive Start");
            var JsonString = File.ReadAllText("../../../Files/GetModels.txt");
            var Client = MockGenerator.MockRestClient<ModelsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ModelsResponse Response = VisualInspection.GetModels();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Count.Equals(2));
            Assert.IsTrue(Response.Data[1].Active);
            Assert.IsTrue(Response.Data[1].AlgorithmId.Equals("IF"));
            Assert.IsTrue(Response.Data[1].AlgorithmType.Equals("unsupervised"));
            Assert.IsFalse(Response.Data[1].ContextDefault);
            Assert.IsTrue(Response.Data[1].CreatedAt.Equals(DateTime.Parse("2019-09-09T02:28:02Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data[1].ImageUrl.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/bf879bb9e18ac516dbe4747999bc415587d68eb1"));
            Assert.IsTrue(Response.Data[1].ModelId.Equals("7cb127ae-79e2-5bf0-bf72-ac178f464c4c"));
            Assert.IsTrue(Response.Data[1].Name.Equals("hgi1"));
            Assert.IsTrue(Response.Data[1].Status.Equals("active"));
            Assert.IsTrue(Response.Data[1].OkImgCount.Equals(9));
            Assert.IsTrue(Response.Data[1].NgImgCount.Equals(4));
            Assert.IsTrue(((double)Response.Data[1].Stats.Precision.Computed).Equals(0.0));
            Assert.IsTrue(((double)Response.Data[1].Stats.Precision.Projected).Equals(0.3077000000));
            Assert.IsTrue(((double)Response.Data[1].Stats.Recall.Computed).Equals(0.0));
            Assert.IsTrue(((double)Response.Data[1].Stats.Recall.Projected).Equals(1.0000000000));
            Assert.IsNull(Response.Data[1].StatusText);
            Assert.IsTrue(Response.Data[1].Version.Equals("0.3.3-1567996081.5101113"));
            Console.WriteLine("SuccessActive End");
        }

        [TestMethod]
        public void SuccessInactive()
        {
            Console.WriteLine("SuccessInactive Start");
            var JsonString = File.ReadAllText("../../../Files/GetModels.txt");
            var Client = MockGenerator.MockRestClient<ModelsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ModelsResponse Response = VisualInspection.GetModels();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Count.Equals(2));
            Assert.IsFalse(Response.Data[0].Active);
            Assert.IsTrue(Response.Data[0].AlgorithmId.Equals("AE"));
            Assert.IsTrue(Response.Data[0].AlgorithmType.Equals("unsupervised"));
            Assert.IsFalse(Response.Data[0].ContextDefault);
            Assert.IsTrue(Response.Data[0].CreatedAt.Equals(DateTime.Parse("2019-09-09T03:23:37Z").ToUniversalTime()));
            Assert.IsNull(Response.Data[0].ImageUrl);
            Assert.IsTrue(Response.Data[0].ModelId.Equals("b2b99239-bdf4-5616-a531-f50546e8e32a"));
            Assert.IsTrue(Response.Data[0].Name.Equals("aci1"));
            Assert.IsTrue(Response.Data[0].Status.Equals("failed"));
            Assert.IsTrue(Response.Data[0].OkImgCount.Equals(0));
            Assert.IsTrue(Response.Data[0].NgImgCount.Equals(0));
            Assert.IsNull(Response.Data[0].Stats.Precision.Computed);
            Assert.IsNull(Response.Data[0].Stats.Precision.Projected);
            Assert.IsNull(Response.Data[0].Stats.Recall.Computed);
            Assert.IsNull(Response.Data[0].Stats.Recall.Projected);
            Assert.IsTrue(Response.Data[0].StatusText.Equals("Malformed parameters detected. Please check parameters before training!"));
            Assert.IsTrue(Response.Data[0].Version.Equals("0.3.3-1567999416.8217766"));
            Console.WriteLine("SuccessInactive End");
        }
    }
}
