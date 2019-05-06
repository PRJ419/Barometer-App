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

        public HttpClient CreateHttpClient(string baseAddress, AuthenticationHeaderValue token)
        {
            var client = new HttpClient(_mockHandler);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Authorization = token;
            return client;
        }
    }
}