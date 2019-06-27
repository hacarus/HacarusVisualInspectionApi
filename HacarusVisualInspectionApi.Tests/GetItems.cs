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
            var JSONString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = visualInspection.GetItems();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.httpResponse);
            Assert.IsNotNull(Response.data);
            Assert.IsNull(Response.errors);
            Assert.IsTrue(Response.httpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.data.archived.Count.Equals(0));
            Assert.IsTrue(Response.data.predict.Count.Equals(1));
            Assert.IsTrue(Response.data.training.Count.Equals(1));

            //Summary
            Assert.IsNotNull(Response.data.summary);
            Assert.IsTrue(Response.data.summary.adjusted.Equals(0));
            Assert.IsTrue(Response.data.summary.analysed.Equals(0));
            Assert.IsTrue(Response.data.summary.archived_defects.Equals(0));
            Assert.IsTrue(Response.data.summary.assessment.Equals("Bad Product"));
            Assert.IsTrue(Response.data.summary.confirmed.Equals(0));
            Assert.IsTrue(Response.data.summary.defects_detected.Equals(0));
            Assert.IsTrue(Response.data.summary.detection_accuracy.Equals(0));
            Assert.IsTrue(Response.data.summary.items_archived.Equals(0));
            Assert.IsTrue(Response.data.summary.items_for_review.Equals(0));
            Assert.IsTrue(Response.data.summary.title.Equals("Context #1"));
            Assert.IsTrue(Response.data.summary.training.good.Equals(1));
            Assert.IsTrue(Response.data.summary.training.defect.Equals(0));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void SuccessPredictGoodStatus()
        {
            Console.WriteLine("SuccessPredictGoodStatus Start");
            var JSONString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = visualInspection.GetItems();
            Assert.IsTrue(Response.data.predict[0].assessment.Equals("Upload specific status"));
            Assert.IsFalse(Response.data.predict[0].confirmed_assessment);
            Assert.IsTrue(Response.data.predict[0].date.Equals(DateTime.Parse("Wed, 19 Jun 2019 05:03:09 GMT").ToUniversalTime()));
            Assert.IsTrue(Response.data.predict[0].default_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Assert.IsNull(Response.data.predict[0].description);
            Assert.IsTrue(Response.data.predict[0].detected_objects.Equals(0));
            Assert.IsTrue(Response.data.predict[0].detection_accuracy.Equals(0));
            Assert.IsTrue(Response.data.predict[0].finished_date.Equals(DateTime.Parse("Wed, 19 Jun 2019 07:24:42 GMT").ToUniversalTime()));
            Assert.IsTrue((bool)Response.data.predict[0].good);
            Assert.IsFalse(Response.data.predict[0].is_training_data);
            Assert.IsTrue(Response.data.predict[0].item_id.Equals("0001"));
            Assert.IsTrue(Response.data.predict[0].label.Equals("Job id is 0001"));
            Assert.IsTrue(Response.data.predict[0].override_assessment);
            Assert.IsTrue(Response.data.predict[0].status.Equals("done"));
            Assert.IsTrue(Response.data.predict[0].thumbnail_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/bc8a33dde2b0f45e2d6340083b5e153f59e33a42"));
            Console.WriteLine("SuccessPredictGoodStatus End");
        }

        [TestMethod]
        public void SuccessTrainingNullStatus()
        {
            Console.WriteLine("SuccessTrainingNullStatus Start");
            var JSONString = File.ReadAllText("../../../Files/GetItems.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.OK, JSONString);
            HacarusVisualInspection visualInspection = new HacarusVisualInspection(Client);
            ItemsResponse Response = visualInspection.GetItems();
            Assert.IsNull(Response.data.training[0].assessment);
            Assert.IsTrue(Response.data.training[0].confirmed_assessment);
            Assert.IsTrue(Response.data.training[0].date.Equals(DateTime.Parse("Mon, 10 Jun 2019 08:22:02 GMT").ToUniversalTime()));
            Assert.IsTrue(Response.data.training[0].default_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/raw/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Assert.IsNull(Response.data.training[0].description);
            Assert.IsTrue(Response.data.training[0].detection_accuracy.Equals(0));
            Assert.IsTrue(Response.data.training[0].detected_objects.Equals(0));
            Assert.IsNull(Response.data.training[0].finished_date);
            Assert.IsNull(Response.data.training[0].good);
            Assert.IsTrue(Response.data.training[0].is_training_data);
            Assert.IsTrue(Response.data.training[0].item_id.Equals("T1-22-01"));
            Assert.IsTrue(Response.data.training[0].label.Equals("Job id is T1-22-01"));
            Assert.IsTrue(Response.data.training[0].override_assessment);
            Assert.IsTrue(Response.data.training[0].status.Equals("pending"));
            Assert.IsTrue(Response.data.training[0].thumbnail_image.Equals("https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d29f794e781e12f466a1fcc1bf1a1596e5320"));
            Console.WriteLine("SuccessTrainingNullStatus End");
        }
    }
}
