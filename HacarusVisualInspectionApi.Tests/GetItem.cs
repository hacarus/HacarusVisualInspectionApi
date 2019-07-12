using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class GetItem
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemSuccess.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("ItemId");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.Data.ComputedAssessment.AssessmentResult.Equals("[OC] Defected product"));
            Assert.IsTrue(Response.Data.ComputedAssessment.DetectedObjects.Equals(2));
            Assert.IsTrue(Response.Data.ComputedAssessment.DetectionAccuracy.Equals(100.0));
            Assert.IsFalse((bool)Response.Data.ComputedAssessment.Good);

            Assert.IsTrue(Response.Data.ConfirmedAssessment);

            Assert.IsTrue(Response.Data.Images.Count.Equals(1));
            Assert.IsTrue(Response.Data.Images[0].Annotations.Count.Equals(2));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].AnnotationId.Equals(8269));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].CreatedAt.Equals(DateTime.Parse("2019-06-11T05:47:00Z").ToUniversalTime()));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].ImageId.Equals(1805));
            Assert.IsNull(Response.Data.Images[0].Annotations[0].Notes);
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].XMax.Equals(620));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].XMin.Equals(606));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].YMax.Equals(2322));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].YMin.Equals(2284));

            Assert.IsTrue(Response.Data.Images[0].ContentType.Equals("image/jpeg"));
            Assert.IsTrue(Response.Data.Images[0].DefectCounted.Equals(70));
            Assert.IsTrue(Response.Data.Images[0].ExifMetadata.FocalLengthIn35mmFilm.Equals(29));
            Assert.IsTrue(Response.Data.Images[0].ExifMetadata.GpsInfo["1"].Equals("N"));
            Assert.IsTrue(Response.Data.Images[0].FileSize.Equals(1524794));
            Assert.IsTrue(Response.Data.Images[0].Height.Equals(3024));
            Assert.IsTrue(Response.Data.Images[0].ImageId.Equals(1805));
            Assert.IsTrue(Response.Data.Images[0].IsRawUploaded);
            Assert.IsNull(Response.Data.Images[0].Position);
            Assert.IsTrue(Response.Data.Images[0].Processed);
            Assert.IsTrue(Response.Data.Images[0].RawUrl.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(Response.Data.Images[0].Url.Equals("https://hacarus-saas-data.s3.amazonaws.com/processed/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(Response.Data.Images[0].Width.Equals(4032));


            Assert.IsFalse(Response.Data.IsTrainingData);
            Assert.IsTrue(Response.Data.ItemId.Equals("IMG6760_U"));
            Assert.IsTrue(Response.Data.Label.Equals("Job id is IMG6760_U"));
            Assert.IsNull(Response.Data.ManualAssessment.AssessmentResult);
            Assert.IsNull(Response.Data.ManualAssessment.DetectedObjects);
            Assert.IsNull(Response.Data.ManualAssessment.DetectionAccuracy);
            Assert.IsNull(Response.Data.ManualAssessment.Good);
            Assert.IsFalse((bool)Response.Data.ManualAssessment.OverrideAssessment);
            Assert.IsTrue(Response.Data.Status.Equals("done"));

            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessManual()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemSuccessManual.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("ItemId");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.Data.ComputedAssessment.AssessmentResult.Equals("[DR] Good product!"));
            Assert.IsTrue(Response.Data.ComputedAssessment.DetectedObjects.Equals(0));
            Assert.IsTrue(Response.Data.ComputedAssessment.DetectionAccuracy.Equals(100.0));
            Assert.IsTrue((bool)Response.Data.ComputedAssessment.Good);

            Assert.IsFalse(Response.Data.ConfirmedAssessment);

            Assert.IsTrue(Response.Data.Images.Count.Equals(1));
            Assert.IsTrue(Response.Data.Images[0].Annotations.Count.Equals(18));
            Assert.IsNotNull(Response.Data.Images[0].ExifMetadata);

            Assert.IsTrue(Response.Data.ManualAssessment.AssessmentResult.Equals("test defect"));
            Assert.IsTrue(Response.Data.ManualAssessment.DetectedObjects.Equals(0));
            Assert.IsNull(Response.Data.ManualAssessment.DetectionAccuracy);
            Assert.IsFalse((bool)Response.Data.ManualAssessment.Good);
            Assert.IsTrue((bool)Response.Data.ManualAssessment.OverrideAssessment);

            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedItemIdDoesNotExist()
        {
            Console.WriteLine("FailedItemIdDoesNotExists Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemFailedItemIdDoesNotExist.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("invaliditem");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals("No match for item_id!"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/item/invaliditem"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedItemIdDoesNotExist End");
        }


        [TestMethod]
        public void FailedItemIdNoPermission()
        {
            Console.WriteLine("FailedItemIdNoPermission Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemFailedItemIdNoPermission.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.Unauthorized, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("NoPermissionItemId");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsNull(Response.Data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(Response.Errors.Title.Equals("No permission to view item!"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/item/NoPermissionItemId"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedItemIdNoPermission End");
        }

    }
}
