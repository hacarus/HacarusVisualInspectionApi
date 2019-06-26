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
            var json = File.ReadAllText("../../../Files/GetItems.txt");
            var client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ItemsResponse response = visualInspection.GetItems();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.httpResponse);
            Assert.IsNotNull(response.data);
            Assert.IsNull(response.errors);
            Assert.IsTrue(response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(response.data.archived.Count.Equals(0));
            Assert.IsTrue(response.data.predict.Count.Equals(1));
            Assert.IsTrue(response.data.training.Count.Equals(1));

            //Summary
            Assert.IsNotNull(response.data.summary);
            Assert.IsTrue(response.data.summary.adjusted.Equals(0));
            Assert.IsTrue(response.data.summary.analysed.Equals(0));
            Assert.IsTrue(response.data.summary.archived_defects.Equals(0));
            Assert.IsTrue(response.data.summary.assessment.Equals("Bad Product"));
            Assert.IsTrue(response.data.summary.confirmed.Equals(0));
            Assert.IsTrue(response.data.summary.defects_detected.Equals(0));
            Assert.IsTrue(response.data.summary.detection_accuracy.Equals(0));
            Assert.IsTrue(response.data.summary.items_archived.Equals(0));
            Assert.IsTrue(response.data.summary.items_for_review.Equals(0));
            Assert.IsTrue(response.data.summary.title.Equals("Context #1"));
            Assert.IsTrue(response.data.summary.training.good.Equals(1));
            Assert.IsTrue(response.data.summary.training.defect.Equals(0));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessPredictGoodStatus()
        {
            Console.WriteLine("SuccessPredictGoodStatus Start");
            var json = File.ReadAllText("../../../Files/GetItems.txt");
            var client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ItemsResponse response = visualInspection.GetItems();
            Assert.IsTrue(response.data.predict[0].assessment.Equals("Upload specific status"));
            Assert.IsFalse(response.data.predict[0].confirmed_assessment);
            Assert.IsTrue(response.data.predict[0].date.Equals(DateTime.Parse("Wed, 19 Jun 2019 05:03:09 GMT").ToUniversalTime()));
            Assert.IsTrue(response.data.predict[0].default_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Assert.IsNull(response.data.predict[0].description);
            Assert.IsTrue(response.data.predict[0].detected_objects.Equals(0));
            Assert.IsTrue(response.data.predict[0].detection_accuracy.Equals(0));
            Assert.IsTrue(response.data.predict[0].finished_date.Equals(DateTime.Parse("Wed, 19 Jun 2019 07:24:42 GMT").ToUniversalTime()));
            Assert.IsTrue((bool)response.data.predict[0].good);
            Assert.IsFalse(response.data.predict[0].is_training_data);
            Assert.IsTrue(response.data.predict[0].item_id.Equals("0001"));
            Assert.IsTrue(response.data.predict[0].label.Equals("Job id is 0001"));
            Assert.IsTrue(response.data.predict[0].override_assessment);
            Assert.IsTrue(response.data.predict[0].status.Equals("done"));
            Assert.IsTrue(response.data.predict[0].thumbnail_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Console.WriteLine("SuccessPredictGoodStatus End");
        }

        [TestMethod]
        public void SuccessTrainingNullStatus()
        {
            Console.WriteLine("SuccessTrainingNullStatus Start");
            var json = File.ReadAllText("../../../Files/GetItems.txt");
            var client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, json);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.Client = client;
            ItemsResponse response = visualInspection.GetItems();
            Assert.IsNull(response.data.training[0].assessment);
            Assert.IsTrue(response.data.training[0].confirmed_assessment);
            Assert.IsTrue(response.data.training[0].date.Equals(DateTime.Parse("Mon, 10 Jun 2019 08:22:02 GMT").ToUniversalTime()));
            Assert.IsTrue(response.data.training[0].default_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Assert.IsNull(response.data.training[0].description);
            Assert.IsTrue(response.data.training[0].detection_accuracy.Equals(0));
            Assert.IsTrue(response.data.training[0].detected_objects.Equals(0));
            Assert.IsNull(response.data.training[0].finished_date);
            Assert.IsNull(response.data.training[0].good);
            Assert.IsTrue(response.data.training[0].is_training_data);
            Assert.IsTrue(response.data.training[0].item_id.Equals("T1-22-01"));
            Assert.IsTrue(response.data.training[0].label.Equals("Job id is T1-22-01"));
            Assert.IsTrue(response.data.training[0].override_assessment);
            Assert.IsTrue(response.data.training[0].status.Equals("pending"));
            Assert.IsTrue(response.data.training[0].thumbnail_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Console.WriteLine("SuccessTrainingNullStatus End");
        }
    }
}
