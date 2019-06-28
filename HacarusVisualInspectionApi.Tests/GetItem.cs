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
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.data.computed_assessment.assessment_result.Equals("[PatchOneClassSVMDetector] Defected product"));
            Assert.IsTrue(Response.data.computed_assessment.detected_objects.Equals(2));
            Assert.IsTrue(Response.data.computed_assessment.detection_accuracy.Equals(100.0));
            Assert.IsFalse((bool)Response.data.computed_assessment.good);

            Assert.IsTrue(Response.data.confirmed_assessment);

            Assert.IsTrue(Response.data.images.Count.Equals(1));
            Assert.IsTrue(Response.data.images[0].annotations.Count.Equals(2));
            Assert.IsTrue(Response.data.images[0].annotations[0].annotation_id.Equals(8269));
            Assert.IsTrue(Response.data.images[0].annotations[0].created_at.Equals(DateTime.Parse("2019-06-11T05:47:00Z").ToUniversalTime()));
            Assert.IsTrue(Response.data.images[0].annotations[0].image_id.Equals(1805));
            Assert.IsNull(Response.data.images[0].annotations[0].notes);
            Assert.IsTrue(Response.data.images[0].annotations[0].x_max.Equals(620));
            Assert.IsTrue(Response.data.images[0].annotations[0].x_min.Equals(606));
            Assert.IsTrue(Response.data.images[0].annotations[0].y_max.Equals(2322));
            Assert.IsTrue(Response.data.images[0].annotations[0].y_min.Equals(2284));

            Assert.IsTrue(Response.data.images[0].content_type.Equals("image/jpeg"));
            Assert.IsTrue(Response.data.images[0].defect_counted.Equals(70));
            Assert.IsTrue(Response.data.images[0].exif_metadata.FocalLengthIn35mmFilm.Equals(29));
            Assert.IsTrue(Response.data.images[0].exif_metadata.GPSInfo["1"].Equals("N"));
            Assert.IsTrue(Response.data.images[0].file_size.Equals(1524794));
            Assert.IsTrue(Response.data.images[0].height.Equals(3024));
            Assert.IsTrue(Response.data.images[0].image_id.Equals(1805));
            Assert.IsTrue(Response.data.images[0].is_raw_uploaded);
            Assert.IsNull(Response.data.images[0].position);
            Assert.IsTrue(Response.data.images[0].processed);
            Assert.IsTrue(Response.data.images[0].raw_url.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(Response.data.images[0].url.Equals("https://hacarus-saas-data.s3.amazonaws.com/processed/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(Response.data.images[0].width.Equals(4032));


            Assert.IsFalse(Response.data.is_training_data);
            Assert.IsTrue(Response.data.item_id.Equals("IMG6760_U"));
            Assert.IsTrue(Response.data.label.Equals("Job id is IMG6760_U"));
            Assert.IsNull(Response.data.manual_assessment.assessment_result);
            Assert.IsNull(Response.data.manual_assessment.detected_objects);
            Assert.IsNull(Response.data.manual_assessment.detection_accuracy);
            Assert.IsNull(Response.data.manual_assessment.good);
            Assert.IsFalse(Response.data.manual_assessment.override_assessment);
            Assert.IsTrue(Response.data.status.Equals("done"));

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
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(Response.data.computed_assessment.assessment_result.Equals("[DictionaryReconstructDetector] Good product!"));
            Assert.IsTrue(Response.data.computed_assessment.detected_objects.Equals(0));
            Assert.IsTrue(Response.data.computed_assessment.detection_accuracy.Equals(100.0));
            Assert.IsTrue((bool)Response.data.computed_assessment.good);

            Assert.IsFalse(Response.data.confirmed_assessment);

            Assert.IsTrue(Response.data.images.Count.Equals(1));
            Assert.IsTrue(Response.data.images[0].annotations.Count.Equals(18));
            Assert.IsNotNull(Response.data.images[0].exif_metadata);

            Assert.IsTrue(Response.data.manual_assessment.assessment_result.Equals("test defect"));
            Assert.IsTrue(Response.data.manual_assessment.detected_objects.Equals(0));
            Assert.IsNull(Response.data.manual_assessment.detection_accuracy);
            Assert.IsFalse((bool)Response.data.manual_assessment.good);
            Assert.IsTrue(Response.data.manual_assessment.override_assessment);

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
            Assert.IsNull(Response.data);
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
            Assert.IsNull(Response.data);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(Response.Errors.Title.Equals("No permission to view item!"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/item/NoPermissionItemId"));
            Assert.IsTrue(Response.Errors.Status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedItemIdNoPermission End");
        }

    }
}
