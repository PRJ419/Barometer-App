using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTClient
{
    public class MockHttpClientFactory : IHttpClientFactory
    {
        private HttpMessageHandler _mockHandler;

        public MockHttpClientFactory(HttpMessageHandler mock)
        {
            _mockHandler = mock; 
        }

        public HttpClient CreateHttpClient()
        {
            return new HttpClient(_mockHandler);
        }
    }
}