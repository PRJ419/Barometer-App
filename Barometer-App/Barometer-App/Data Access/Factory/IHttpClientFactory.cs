using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTClient
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient(string baseAddress, AuthenticationHeaderValue token);
    }
}