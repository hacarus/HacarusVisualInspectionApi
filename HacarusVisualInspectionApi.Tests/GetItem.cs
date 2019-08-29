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
        public void SuccessTraining()
        {
            Console.WriteLine("Get Training Item Success Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemSuccess.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("ItemId");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.Data.Active);
            Assert.IsTrue(Response.Data.CreatedAt.Equals(DateTime.Parse("2019-08-29T01:04:10+00:00")));
            Assert.IsTrue(Response.Data.DefaultImage.Equals("1eb4ecce4c2d0783964a771034805e290af70082"));
            Assert.IsNull(Response.Data.Description);
            Assert.IsNull(Response.Data.FinishedDate);
            Assert.IsTrue(Response.Data.Images.Length.Equals(1));

            Assert.IsTrue(Response.Data.Images[0].Annotations.Length.Equals(1));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].AnnotationId.Equals(4));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].CreatedAt.Equals(DateTime.Parse("2019-08-29T01:04:35+00:00")));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].ForTraining);
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].Notes.Equals("test"));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].XMin.Equals(1));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].XMax.Equals(2));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].YMin.Equals(3));
            Assert.IsTrue(Response.Data.Images[0].Annotations[0].YMax.Equals(4));

            Assert.IsTrue(Response.Data.Images[0].BatchId.Equals("batch1"));
            Assert.IsTrue(Response.Data.Images[0].ContentType.Equals("image/jpeg"));
            Assert.IsTrue(Response.Data.Images[0].CreatedAt.Equals(DateTime.Parse("2019-08-29T01:04:10+00:00")));
            Assert.IsTrue(Response.Data.Images[0].Defects.Equals(1));
            Assert.IsNotNull(Response.Data.Images[0].ExifMetadata);
            Assert.IsTrue(Response.Data.Images[0].FileName.Equals("IMG-1006-OK-T.JPG"));
            Assert.IsTrue(Response.Data.Images[0].FileSize.Equals(143697));
            Assert.IsTrue(Response.Data.Images[0].Height.Equals(719));
            Assert.IsTrue(Response.Data.Images[0].ImageId.Equals(1023));
            Assert.IsTrue(Response.Data.Images[0].Key.Equals("key123"));
            Assert.IsNull(Response.Data.Images[0].Position);
            Assert.IsTrue(Response.Data.Images[0].Processed);
            Assert.IsTrue(Response.Data.Images[0].Uploaded);
            Assert.IsTrue(Response.Data.Images[0].Width.Equals(759));

            Assert.IsTrue((bool)Response.Data.IsTrainingData);
            Assert.IsTrue(Response.Data.ItemId.Equals("IMG-1006-OK-T"));
            Assert.IsNotNull(Response.Data.Override);
            Assert.IsNull(Response.Data.Override.DetectedObjects);
            Assert.IsNull(Response.Data.Override.DetectionAccuracy);
            Assert.IsTrue(Response.Data.Override.Label.Equals("OK"));
            Assert.IsTrue(Response.Data.Override.Result.Equals("Upload specific status"));
            Assert.IsTrue(Response.Data.Status.Equals("done"));

            //IMAGES TEST
            //ANNOTATION TEST
            //OVERRIDE IS NULL
            //DETECTED OBJECTS IS NULL
            //Training
            //Predict
            //METADATA
            //POsition

            Console.WriteLine("Get Training Item Success End");
        }

        [TestMethod]
        public void SuccessPredictNoLabelNotProccess()
        {
            Console.WriteLine("SuccessPredictNoLabelNotProccess Start");
            var JsonString = File.ReadAllText("../../../Files/GetItemPredictNoLabelUnproccessed.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            ItemResponse Response = VisualInspection.GetItem("ItemId");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.Data.Active);
            Assert.IsTrue(Response.Data.CreatedAt.Equals(DateTime.Parse("2019-08-29T04:19:46+00:00")));
            Assert.IsTrue(Response.Data.DefaultImage.Equals("5d0e87d0227a3c334d5224541fa14b560f54cf36"));
            Assert.IsNull(Response.Data.Description);
            Assert.IsNull(Response.Data.FinishedDate);
            Assert.IsTrue(Response.Data.Images.Length.Equals(1));

            Assert.IsTrue(Response.Data.Images[0].ContentType.Equals("image/jpeg"));
            Assert.IsTrue(Response.Data.Images[0].Defects.Equals(0));
            Assert.IsNotNull(Response.Data.Images[0].ExifMetadata);
            Assert.IsTrue(Response.Data.Images[0].FileSize.Equals(32764));
            Assert.IsTrue(Response.Data.Images[0].Height.Equals(360));
            Assert.IsTrue(Response.Data.Images[0].ImageId.Equals(1025));
            Assert.IsTrue((bool)Response.Data.Images[0].IsRawUploaded);
            Assert.IsTrue(Response.Data.Images[0].Position.Equals("RIGHT"));
            Assert.IsFalse(Response.Data.Images[0].Processed);
            Assert.IsTrue(Response.Data.Images[0].RawUrl.Equals("5d0e87d0227a3c334d5224541fa14b560f54cf36"));
            Assert.IsTrue(Response.Data.Images[0].Url.Equals("5d0e87d0227a3c334d5224541fa14b560f54cf36"));
            Assert.IsTrue(Response.Data.Images[0].Width.Equals(480));

            Assert.IsTrue(Response.Data.Images[0].ExifMetadata.ApertureValue.Count.Equals(2));
            Assert.IsNotNull(Response.Data.Images[0].ExifMetadata);

            Assert.IsTrue(Response.Data.ItemId.Equals("Canon_PowerShot_S40"));
            Assert.IsNull(Response.Data.Override);
            Assert.IsTrue(Response.Data.Status.Equals("done"));


            //IMAGES TEST
            //ANNOTATION TEST
            //OVERRIDE IS NULL
            //DETECTED OBJECTS IS NULL
            //Training
            //Predict
            //METADATA
            //POsition
            //predict predicted

            Console.WriteLine("SuccessPredictNoLabelNotProccess End");
        }


        //[TestMethod]
        //public void SuccessManual()
        //{
        //    Console.WriteLine("Success Start");
        //    var JsonString = File.ReadAllText("../../../Files/GetItemSuccessManual.txt");
        //    var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, JsonString);
        //    HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
        //    ItemResponse Response = VisualInspection.GetItem("ItemId");
        //    Assert.IsNotNull(Response);
        //    Assert.IsNotNull(Response.HttpResponse);
        //    Assert.IsNotNull(Response.Data);
        //    Assert.IsNull(Response.Errors);
        //    Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

        //    //Assert.IsTrue(Response.Data.ComputedAssessment.AssessmentResult.Equals("[DR] Good product!"));
        //    //Assert.IsTrue(Response.Data.ComputedAssessment.DetectedObjects.Equals(0));
        //    //Assert.IsTrue(Response.Data.ComputedAssessment.DetectionAccuracy.Equals(100.0));
        //    //Assert.IsTrue((bool)Response.Data.ComputedAssessment.Good);

        //    //Assert.IsFalse(Response.Data.ConfirmedAssessment);

        //    //Assert.IsTrue(Response.Data.Images.Count.Equals(1));
        //    //Assert.IsTrue(Response.Data.Images[0].Annotations.Count.Equals(18));
        //    //Assert.IsNotNull(Response.Data.Images[0].ExifMetadata);

        //    //Assert.IsTrue(Response.Data.ManualAssessment.AssessmentResult.Equals("test defect"));
        //    //Assert.IsTrue(Response.Data.ManualAssessment.DetectedObjects.Equals(0));
        //    //Assert.IsNull(Response.Data.ManualAssessment.DetectionAccuracy);
        //    //Assert.IsFalse((bool)Response.Data.ManualAssessment.Good);
        //    //Assert.IsTrue((bool)Response.Data.ManualAssessment.OverrideAssessment);

        //    Console.WriteLine("Success End");
        //}

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
