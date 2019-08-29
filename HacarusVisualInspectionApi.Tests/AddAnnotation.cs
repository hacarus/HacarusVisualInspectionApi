using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class AddAnnotation
    {
        [TestMethod]
        public void Success()
        {
            Console.WriteLine("Success Start");
            var JsonString = File.ReadAllText("../../../Files/AddAnnotationSuccess.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.OK, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            Annotation NewAnnotation = new Annotation();
            NewAnnotation.XMax = 10;
            NewAnnotation.XMin = 20;
            NewAnnotation.YMax = 30;
            NewAnnotation.YMin = 40;
            NewAnnotation.Notes = "test";
            GenericResponse Response = VisualInspection.AddAnnotations(new Annotation[] { NewAnnotation }, "1000");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Data);
            Assert.IsNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsTrue(Response.Data.Status.Equals("ok"));
            Console.WriteLine("Success End");
        }

        [TestMethod]
        public void FailedImageNotFound()
        {
            Console.WriteLine("FailedImageNotFound Start");
            var JsonString = File.ReadAllText("../../../Files/AddAnnotationFailed.txt");
            var Client = MockGenerator.MockRestClient<LicenseResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);

            Annotation NewAnnotation = new Annotation();
            NewAnnotation.XMax = 10;
            NewAnnotation.XMin = 20;
            NewAnnotation.YMax = 30;
            NewAnnotation.YMin = 40;
            NewAnnotation.Notes = "test";
            GenericResponse Response = VisualInspection.AddAnnotations(new Annotation[] { NewAnnotation }, "1001");
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNull(Response.Data);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals("Cannot find image"));
            Assert.IsTrue(Response.Errors.Source.Pointer.Equals("/api/v1/image/10/annotation?"));
            Console.WriteLine("FailedImageNotFound End");
        }

    }
}
