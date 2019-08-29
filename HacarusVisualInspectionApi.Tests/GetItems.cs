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
            Assert.IsTrue(Response.Data.Predict.Length.Equals(2));
            Assert.IsTrue(Response.Data.Training.Length.Equals(1));

            //Summary
            Assert.IsNotNull(Response.Data.Summary);
            Assert.IsNotNull(Response.Data.Summary.PredictStats);
            Assert.IsTrue(Response.Data.Summary.PredictStats.Length.Equals(1));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].NgCount.Equals(2));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].OkCount.Equals(4));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].Accuracy.Equals(0));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].AdjustedCount.Equals(0));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].ConfirmedCount.Equals(0));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].DoneCount.Equals(6));
            Assert.IsTrue(Response.Data.Summary.PredictStats[0].ModelId.Equals(1000));
            Assert.IsTrue(Response.Data.Summary.Title.Equals("Car Project"));
            Assert.IsTrue(Response.Data.Summary.TrainingStats.NgCount.Equals(0));
            Assert.IsTrue(Response.Data.Summary.TrainingStats.OkCount.Equals(1));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessPredict()
        {
            Console.WriteLine("SuccessPredict Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();

            Assert.IsNotNull(Response.Data.Predict);
            Assert.IsTrue(Response.Data.Predict[1].Active);
            Assert.IsTrue(Response.Data.Predict[1].CreatedAt.Equals(DateTime.Parse("2018-10-30T09:43:04+00:00")));
            Assert.IsNull(Response.Data.Predict[1].DefaultImage);
            Assert.IsNull(Response.Data.Predict[1].Description);
            Assert.IsTrue(Response.Data.Predict[1].FinishedDate.Equals(DateTime.Parse("2018-10-30T13:59:39+00:00")));
            Assert.IsFalse((bool)Response.Data.Predict[1].IsTrainingData);
            Assert.IsTrue(Response.Data.Predict[1].ItemId.Equals("1000"));
            Assert.IsTrue(Response.Data.Predict[1].Models.Length.Equals(0));
            Assert.IsTrue(Response.Data.Predict[1].Override.DetectedObjects.Equals(30));
            Assert.IsTrue(Response.Data.Predict[1].Override.DetectionAccuracy.Equals(99));
            Assert.IsTrue(Response.Data.Predict[1].Override.Label.Equals("OK"));
            Assert.IsTrue(Response.Data.Predict[1].Override.Result.Equals("This is an overriden result! YEEY!"));
            Assert.IsTrue(Response.Data.Predict[1].Status.Equals("done"));
            Assert.IsNull(Response.Data.Predict[1].ThumbnailImage);
            Console.WriteLine("SuccessPredict End");
        }


        [TestMethod]
        public void SuccessPredictWithModel()
        {
            Console.WriteLine("SuccessPredictWithModel Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();

            Assert.IsNotNull(Response.Data.Predict);
            Assert.IsTrue(Response.Data.Predict[0].Active);
            Assert.IsTrue(Response.Data.Predict[0].CreatedAt.Equals(DateTime.Parse("2018-10-30T13:24:57+00:00")));
            Assert.IsNull(Response.Data.Predict[0].DefaultImage);
            Assert.IsNull(Response.Data.Predict[0].Description);
            Assert.IsTrue(Response.Data.Predict[0].FinishedDate.Equals(DateTime.Parse("2018-10-30T14:03:01+00:00")));
            Assert.IsFalse((bool)Response.Data.Predict[0].IsTrainingData);
            Assert.IsTrue(Response.Data.Predict[0].ItemId.Equals("1001"));
            Assert.IsNull(Response.Data.Predict[0].Override);
            Assert.IsTrue(Response.Data.Predict[0].Status.Equals("done"));
            Assert.IsNull(Response.Data.Predict[0].ThumbnailImage);
            Assert.IsTrue(Response.Data.Predict[0].Models.Length.Equals(1));
            Assert.IsNotNull(Response.Data.Predict[0].Models[0].Aggregate);
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Aggregate.DetectedObjects.Equals(2));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Aggregate.Label.Equals("NG"));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].ModelId.Equals(1000));
            Assert.IsNotNull(Response.Data.Predict[0].Models[0].Assessments);
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments.Length.Equals(2));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Annotations.Length.Equals(0));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Computed.DetectedObjects.Equals(100));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Computed.DetectionAccuracy.Equals(50));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Computed.Label.Equals("OK"));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Computed.Result.Equals("good"));
            Assert.IsFalse(Response.Data.Predict[0].Models[0].Assessments[0].Confirmed);
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].CreatedAt.Equals(DateTime.Parse("2019-08-29T08:48:09+00:00")));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Final.DetectedObjects.Equals(100));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Final.DetectionAccuracy.Equals(50));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Final.Label.Equals("OK"));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].Final.Result.Equals("good"));
            Assert.IsNull(Response.Data.Predict[0].Models[0].Assessments[0].FinishedDate);
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].ImageId.Equals(1001));
            Assert.IsTrue(Response.Data.Predict[0].Models[0].Assessments[0].ModelId.Equals(1000));

            Console.WriteLine("SuccessPredictWithModel End");
        }

        [TestMethod]
        public void SuccessTraining()
        {
            Console.WriteLine("SuccessTraining Start");
            var JsonString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = VisualInspection.GetItems();

            Assert.IsNotNull(Response.Data.Training);
            Assert.IsTrue(Response.Data.Training[0].Active);
            Assert.IsTrue(Response.Data.Training[0].CreatedAt.Equals(DateTime.Parse("2019-08-29T01:04:10+00:00")));
            Assert.IsTrue(Response.Data.Training[0].DefaultImage.Equals("http://127.0.0.1:8080/raw/1eb4ecce4c2d0783964a771034805e290af70082"));
            Assert.IsNull(Response.Data.Training[0].Description);
            Assert.IsNull(Response.Data.Training[0].FinishedDate);
            Assert.IsTrue((bool)Response.Data.Training[0].IsTrainingData);
            Assert.IsTrue(Response.Data.Training[0].ItemId.Equals("IMG-1006-OK-T"));
            Assert.IsNull(Response.Data.Training[0].Models);
            Assert.IsNull(Response.Data.Training[0].Override.DetectedObjects);
            Assert.IsNull(Response.Data.Training[0].Override.DetectionAccuracy);
            Assert.IsTrue(Response.Data.Training[0].Override.Label.Equals("OK"));
            Assert.IsTrue(Response.Data.Training[0].Override.Result.Equals("Upload specific status"));
            Assert.IsTrue(Response.Data.Training[0].Status.Equals("done"));
            Assert.IsTrue(Response.Data.Training[0].ThumbnailImage.Equals("http://127.0.0.1:8080/thumbnail/1eb4ecce4c2d0783964a771034805e290af70082"));
            Console.WriteLine("SuccessTraining End");

        }
    }
}
