
using System.Net.Http;

namespace Insurance.Common
{
    /// <summary>
    /// Single HttpClient instance
    /// reference: https://docs.microsoft.com/en-us/azure/architecture/antipatterns/improper-instantiation/
    /// </summary>
    public static class HttpClientManager
    {
        public static HttpClient SingleHttpClient = new HttpClient();
    }
}
