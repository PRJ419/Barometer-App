using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTClient
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }
    }
}