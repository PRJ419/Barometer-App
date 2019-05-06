using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTClient
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient(string baseAddress, AuthenticationHeaderValue token)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Authorization = token;
            return client;
        }
    }
}