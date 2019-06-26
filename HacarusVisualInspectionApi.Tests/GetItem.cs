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
            var json = File.ReadAllText("../../../Files/GetItemSuccess.txt");
            var client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ItemResponse response = visualInspection.GetItem("ItemId");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(response.data.computed_assessment.assessment_result.Equals("[PatchOneClassSVMDetector] Defected product"));
            Assert.IsTrue(response.data.computed_assessment.detected_objects.Equals(2));
            Assert.IsTrue(response.data.computed_assessment.detection_accuracy.Equals(100.0));
            Assert.IsFalse((bool)response.data.computed_assessment.good);

            Assert.IsTrue(response.data.confirmed_assessment);

            Assert.IsTrue(response.data.images.Count.Equals(1));
            Assert.IsTrue(response.data.images[0].annotations.Count.Equals(2));
            Assert.IsTrue(response.data.images[0].annotations[0].annotation_id.Equals(8269));
            Assert.IsTrue(response.data.images[0].annotations[0].created_at.Equals(DateTime.Parse("2019-06-11T05:47:00Z").ToUniversalTime()));
            Assert.IsTrue(response.data.images[0].annotations[0].image_id.Equals(1805));
            Assert.IsNull(response.data.images[0].annotations[0].notes);
            Assert.IsTrue(response.data.images[0].annotations[0].x_max.Equals(620));
            Assert.IsTrue(response.data.images[0].annotations[0].x_min.Equals(606));
            Assert.IsTrue(response.data.images[0].annotations[0].y_max.Equals(2322));
            Assert.IsTrue(response.data.images[0].annotations[0].y_min.Equals(2284));

            Assert.IsTrue(response.data.images[0].content_type.Equals("image/jpeg"));
            Assert.IsTrue(response.data.images[0].defect_counted.Equals(70));
            Assert.IsTrue(response.data.images[0].exif_metadata.FocalLengthIn35mmFilm.Equals(29));
            Assert.IsTrue(response.data.images[0].exif_metadata.GPSInfo["1"].Equals("N"));
            Assert.IsTrue(response.data.images[0].file_size.Equals(1524794));
            Assert.IsTrue(response.data.images[0].height.Equals(3024));
            Assert.IsTrue(response.data.images[0].image_id.Equals(1805));
            Assert.IsTrue(response.data.images[0].is_raw_uploaded);
            Assert.IsNull(response.data.images[0].position);
            Assert.IsTrue(response.data.images[0].processed);
            Assert.IsTrue(response.data.images[0].raw_url.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(response.data.images[0].url.Equals("https://hacarus-saas-data.s3.amazonaws.com/processed/d9b6b9709b29d4deb30be4e981031f09823120c7"));
            Assert.IsTrue(response.data.images[0].width.Equals(4032));


            Assert.IsFalse(response.data.is_training_data);
            Assert.IsTrue(response.data.item_id.Equals("IMG6760_U"));
            Assert.IsTrue(response.data.label.Equals("Job id is IMG6760_U"));
            Assert.IsNull(response.data.manual_assessment.assessment_result);
            Assert.IsNull(response.data.manual_assessment.detected_objects);
            Assert.IsNull(response.data.manual_assessment.detection_accuracy);
            Assert.IsNull(response.data.manual_assessment.good);
            Assert.IsFalse(response.data.manual_assessment.override_assessment);
            Assert.IsTrue(response.data.status.Equals("done"));

            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessManual()
        {
            Console.WriteLine("Success Start");
            var json = File.ReadAllText("../../../Files/GetItemSuccessManual.txt");
            var client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ItemResponse response = visualInspection.GetItem("ItemId");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));

            Assert.IsTrue(response.data.computed_assessment.assessment_result.Equals("[DictionaryReconstructDetector] Good product!"));
            Assert.IsTrue(response.data.computed_assessment.detected_objects.Equals(0));
            Assert.IsTrue(response.data.computed_assessment.detection_accuracy.Equals(100.0));
            Assert.IsTrue((bool)response.data.computed_assessment.good);

            Assert.IsFalse(response.data.confirmed_assessment);

            Assert.IsTrue(response.data.images.Count.Equals(1));
            Assert.IsTrue(response.data.images[0].annotations.Count.Equals(18));
            Assert.IsNotNull(response.data.images[0].exif_metadata);

            Assert.IsTrue(response.data.manual_assessment.assessment_result.Equals("test defect"));
            Assert.IsTrue(response.data.manual_assessment.detected_objects.Equals(0));
            Assert.IsNull(response.data.manual_assessment.detection_accuracy);
            Assert.IsFalse((bool)response.data.manual_assessment.good);
            Assert.IsTrue(response.data.manual_assessment.override_assessment);

            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedItemIdDoesNotExist()
        {
            Console.WriteLine("FailedItemIdDoesNotExists Start");
            var Json = File.ReadAllText("../../../Files/GetItemFailedItemIdDoesNotExist.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.NotFound, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            ItemResponse response = visualInspection.GetItem("invaliditem");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(response.errors.title.Equals("No match for item_id!"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/item/invaliditem"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.NotFound));
            Console.WriteLine("FailedItemIdDoesNotExist End");
        }


        [TestMethod]
        public void FailedItemIdNoPermission()
        {
            Console.WriteLine("FailedItemIdNoPermission Start");
            var Json = File.ReadAllText("../../../Files/GetItemFailedItemIdNoPermission.txt");
            var Client = MockGenerator.MockRestClient<ItemResponse>(HttpStatusCode.Unauthorized, Json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = Client;
            ItemResponse response = visualInspection.GetItem("NoPermissionItemId");
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.errors);
            Assert.IsNull(response.data);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
            Assert.IsTrue(response.errors.title.Equals("No permission to view item!"));
            Assert.IsTrue(response.errors.source.pointer.Equals("/api/v1/item/NoPermissionItemId"));
            Assert.IsTrue(response.errors.status.Equals((int)HttpStatusCode.Unauthorized));
            Console.WriteLine("FailedItemIdNoPermission End");
        }

    }
}
