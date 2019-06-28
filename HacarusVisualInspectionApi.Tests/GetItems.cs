using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetItems
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Archived.Count.Equals(0));
            Assert.IsTrue(Response.Data.Predict.Count.Equals(1));
            Assert.IsTrue(Response.Data.Training.Count.Equals(1));

            //Summary
            Assert.IsNotNull(Response.Data.Summary);
            Assert.IsTrue(Response.Data.Summary.Adjusted.Equals(0));
            Assert.IsTrue(Response.Data.Summary.Analysed.Equals(0));
            Assert.IsTrue(Response.Data.Summary.ArchivedDefects.Equals(0));
            Assert.IsTrue(Response.Data.Summary.Assessment.Equals("Bad Product"));
            Assert.IsTrue(Response.Data.Summary.Confirmed.Equals(0));
            Assert.IsTrue(Response.Data.Summary.DefectsDetected.Equals(0));
            Assert.IsTrue(Response.Data.Summary.DetectionAccuracy.Equals(0));
            Assert.IsTrue(Response.Data.Summary.ItemsArchived.Equals(0));
            Assert.IsTrue(Response.Data.Summary.ItemsForReview.Equals(0));
            Assert.IsTrue(Response.Data.Summary.Title.Equals("Context #1"));
            Assert.IsTrue(Response.Data.Summary.Training.Good.Equals(1));
            Assert.IsTrue(Response.Data.Summary.Training.Defect.Equals(0));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessPredictGoodStatus()
        {
            Console.WriteLine("SuccessPredictGoodStatus Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsTrue(Response.Data.Predict[0].Assessment.Equals("Upload specific status"));
            Assert.IsFalse(Response.Data.Predict[0].ConfirmedAssessment);
            Assert.IsTrue(Response.Data.Predict[0].Date.Equals(DateTime.Parse("Wed, 19 Jun 2019 05:03:09 GMT").ToUniversalTime()));
            Assert.IsTrue(Response.Data.Predict[0].DefaultImage.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Assert.IsNull(Response.Data.Predict[0].Description);
            Assert.IsTrue(Response.Data.Predict[0].DetectedObjects.Equals(0));
            Assert.IsTrue(Response.Data.Predict[0].DetectionAccuracy.Equals(0));
            Assert.IsTrue(Response.Data.Predict[0].FinishedDate.Equals(DateTime.Parse("Wed, 19 Jun 2019 07:24:42 GMT").ToUniversalTime()));
            Assert.IsTrue((bool)Response.Data.Predict[0].Good);
            Assert.IsFalse(Response.Data.Predict[0].IsTrainingData);
            Assert.IsTrue(Response.Data.Predict[0].ItemId.Equals("0001"));
            Assert.IsTrue(Response.Data.Predict[0].Label.Equals("Job id is 0001"));
            Assert.IsTrue(Response.Data.Predict[0].OverrideAssessment);
            Assert.IsTrue(Response.Data.Predict[0].Status.Equals("done"));
            Assert.IsTrue(Response.Data.Predict[0].ThumbnailImage.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Console.WriteLine("SuccessPredictGoodStatus End");
        }

        [TestMethod]
        public void SuccessTrainingNullStatus()
        {
            Console.WriteLine("SuccessTrainingNullStatus Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsNull(Response.Data.Training[0].Assessment);
            Assert.IsTrue(Response.Data.Training[0].ConfirmedAssessment);
            Assert.IsTrue(Response.Data.Training[0].Date.Equals(DateTime.Parse("Mon, 10 Jun 2019 08:22:02 GMT").ToUniversalTime()));
            Assert.IsTrue(Response.Data.Training[0].DefaultImage.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Assert.IsNull(Response.Data.Training[0].Description);
            Assert.IsTrue(Response.Data.Training[0].DetectionAccuracy.Equals(0));
            Assert.IsTrue(Response.Data.Training[0].DetectedObjects.Equals(0));
            Assert.IsNull(Response.Data.Training[0].FinishedDate);
            Assert.IsNull(Response.Data.Training[0].Good);
            Assert.IsTrue(Response.Data.Training[0].IsTrainingData);
            Assert.IsTrue(Response.Data.Training[0].ItemId.Equals("T1-22-01"));
            Assert.IsTrue(Response.Data.Training[0].Label.Equals("Job id is T1-22-01"));
            Assert.IsTrue(Response.Data.Training[0].OverrideAssessment);
            Assert.IsTrue(Response.Data.Training[0].Status.Equals("pending"));
            Assert.IsTrue(Response.Data.Training[0].ThumbnailImage.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Console.WriteLine("SuccessTrainingNullStatus End");
        }
    }
}
