using System;
using System.Net;
using Moq;
using RestSharp;

namespace HacarusVisualInspectionApi.Tests
{
    public class MockGenerator
    {
        public static RestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json)
        where T : new()
        {
            var restClient = new Mock<RestClient>();

            restClient.Setup(x => x.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse<T>
                {
                    StatusCode = httpStatusCode,
                    Content = json
                });

            return restClient.Object;
        }
    }
}
