using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HacarusVisualInspectionApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RestSharp;

namespace HacarusVisualInspectionApi.Tests
{
    [TestClass]
    public class Login
    {
        public static RestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json)
    where T : new()
        {
            //var restClient = new Mock<RestClient>();

            //var data = JsonConvert.DeserializeObject<T>(json);
            //var response = new Mock<RestResponse>();
            //restClient.Setup(x => x.Execute<T>(It.IsAny<RestRequest>()))
            //.Returns(new RestResponse()
            //{
            //    //StatusCode = httpStatusCode,
            //    Content = json
            //});
            var restClient = new Mock<RestClient>();

            restClient.Setup(x => x.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse<T>
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = json
                });

            //var request = new RestRequest("auth/token", Method.POST);
            //var response = restClient.Object.Execute(request);
            //Console.WriteLine(response.Content);
            return restClient.Object;
            //var data = JsonConvert.DeserializeObject<T>(json);
            //var response = new Mock<RestResponse<T>>();
            //response.SetupGet(s => s.StatusCode).Returns(httpStatusCode);
            //response.Setup(s => s.Data).Returns(data);

            //var mockIRestClient = new Mock<RestClient>();
            //mockIRestClient.Setup(x => x.Execute<T>(It.IsAny<RestRequest>())).Returns(response.Object);

            //restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
            //.Returns(new RestResponse<RootObjectList>
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = null
            //});


            //return mockIRestClient.Object;


        }

        [TestMethod]
        public void Login_InvalidClientID()
        {

            var client = MockRestClient<AccessTokenResponse>(HttpStatusCode.NotFound, "{\ndata: {\naccess_token: \"n9C-MsdHq2rigkm4AVr\",\nexpires: 2592000\n}\n}");
            HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            visualInspection.SetClient(client);
            if(client.Equals(null))
            {

            }
            else {

                //var request = new RestRequest("auth/token", Method.POST);

                //var parameters = new
                //{
                //    client_id = "",
                //    client_secret = "",
                //    grant_type = "client_credentials"
                //};
                //var json = JsonConvert.SerializeObject(parameters);
                //request.AddJsonBody(json);

                //var response = client.Execute(request);
                //AccessTokenResponse responseObject = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);
                //if (responseObject.errors == null)
                //{
                //    //this.AccessToken = responseObject.data.access_token;
                //}
                //responseObject.httpResponse = response;
                //Console.WriteLine(responseObject.httpResponse.Content);


                //Act
                AccessTokenResponse response = visualInspection.Authorize("", "");
                //var request = new RestRequest("auth/token", Method.POST);

                ////var parameters = new
                ////{
                ////    client_id = "",
                ////    client_secret = "",
                ////    grant_type = "client_credentials"
                ////};
                ////var json = JsonConvert.SerializeObject(parameters);
                ////request.AddJsonBody(json);

                //var response = client.Execute(request);
                ////Console.WriteLine(response.Content);
                //AccessTokenResponse responseObject = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);

                //responseObject.httpResponse = response;
                //Console.WriteLine(responseObject.httpResponse.StatusCode);
                //if (responseObject.errors == null)
                //{
                //    //this.AccessToken = responseObject.data.access_token;
                //}
                //else
                //{

                //}
                ////responseObject.httpResponse = response;
                //return responseObject;
                //Assert
                Console.WriteLine(response);
                //Assert.IsTrue(response.httpResponse.StatusCode.Equals(System.Net.HttpStatusCode.OK), "success");

            }
            //HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            //visualInspection.SetClient(client);

            //// ARRANGE
            //var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            //handlerMock
            //   .Protected()
            //   // Setup the PROTECTED method to mock
            //   .Setup<Task<HttpResponseMessage>>(
            //      "SendAsync",
            //      ItExpr.IsAny<HttpRequestMessage>(),
            //      ItExpr.IsAny<CancellationToken>()
            //   )
            //   // prepare the expected response of the mocked http call
            //   .ReturnsAsync(new HttpResponseMessage()
            //   {
            //       StatusCode = HttpStatusCode.OK,
            //       Content = new StringContent("{ \"errors\": { \"detail\": null, \"source\": { \"pointer\": \"/api/auth/token\" }, \"status\": 401, \"title\": \"Cannot find client information\" } }"),
            //   })
            //   .Verifiable();

            //// use real http client with mocked handler here
            //var httpClient = new RestClient(handlerMock.Object)
            //{
            //    BaseAddress = new Uri("http://test.com/"),
            //};


            //HacarusVisualInspection visualInspection = new HacarusVisualInspection();
            //visualInspection.SetClient(httpClient);
            ////var subjectUnderTest = new MyTestClass(httpClient);

            //// ACT
            //var response = visualInspection.Authorize("", "");

            //// ASSERT
            //response.httpResponse.StatusCode.Equals(404); // this is fluent assertions here...
            //response.Id.Should().Be(1);

            //// also check the 'http' call was like we expected it
            //var expectedUri = new Uri("http://test.com/api/auth/token");

            //handlerMock.Protected().Verify(
            //   "SendAsync",
            //   Times.Exactly(1), // we expected a single external request
            //   ItExpr.Is<HttpRequestMessage>(req =>
            //      req.Method == HttpMethod.Get  // we expected a GET request
            //      && req.RequestUri == expectedUri // to this uri
            //   ),
            //   ItExpr.IsAny<CancellationToken>()
            //);

        }
    }
}
