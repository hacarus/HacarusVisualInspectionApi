using System;
using System.IO;
using System.Net;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class SetLanguage
    {
        [TestMethod]
        public void GetContextEnglishSetLanguage()
        {
            Console.WriteLine("GetContextEnglish Start");
            var JsonString = File.ReadAllText("../../../Files/LanguageEn.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            VisualInspection.SetLanguage("en");
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals(""));
            Assert.IsTrue(Response.Errors.Details.Equals("Cannot find context"));
            Console.WriteLine("GetContextEnglish End");
        }
  
        [TestMethod]
        public void GetContextJapaneseSetLanguage()
        {
            Console.WriteLine("GetContextJapaneseSetLanguage Start");
            var JsonString = File.ReadAllText("../../../Files/LanguageJa.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client);
            VisualInspection.SetLanguage("ja");
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals(""));
            Assert.IsTrue(Response.Errors.Details.Equals("\u30b3\u30f3\u30c6\u30ad\u30b9\u30c8\u304c\u898b\u3064\u304b\u308a\u307e\u305b\u3093\u3002"));
            Console.WriteLine("GetContextJapaneseSetLanguage End");
        }
    
        [TestMethod]
        public void GetContextJapanese()
        {
            Console.WriteLine("GetContextJapanese Start");
            var JsonString = File.ReadAllText("../../../Files/LanguageJa.txt");
            var Client = MockGenerator.MockRestClient<ItemsResponse>(HttpStatusCode.NotFound, JsonString);
            HacarusVisualInspection VisualInspection = new HacarusVisualInspection(Client, "ja");
            ItemsResponse Response = VisualInspection.GetItems();
            Assert.IsNotNull(Response);
            Assert.IsNotNull(Response.HttpResponse);
            Assert.IsNotNull(Response.Errors);
            Assert.IsTrue(Response.HttpResponse.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsTrue(Response.Errors.Title.Equals(""));
            Assert.IsTrue(Response.Errors.Details.Equals("\u30b3\u30f3\u30c6\u30ad\u30b9\u30c8\u304c\u898b\u3064\u304b\u308a\u307e\u305b\u3093\u3002"));
            Console.WriteLine("GetContextJapanese End");
        }
    }
}
