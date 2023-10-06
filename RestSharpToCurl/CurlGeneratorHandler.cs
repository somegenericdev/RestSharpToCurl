using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using HttpClientToCurl;

namespace RestSharpToCurl
{
    public class CurlGeneratorHandler : DelegatingHandler
    {
        public HttpClient HttpClient;
        private StrongBox<string> CurlScript;

        public CurlGeneratorHandler(HttpMessageHandler innerHandler, StrongBox<string> curlScript)
            : base(innerHandler)
        {
            CurlScript = curlScript;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CurlScript.Value=HttpClient.GenerateCurlInString(request);
            HttpResponseMessage response=null;
            return response;
        }
    }
}