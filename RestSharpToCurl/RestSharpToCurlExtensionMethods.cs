using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mono.Reflection;
using RestSharp;

namespace RestSharpToCurl
{
    public static class RestSharpToCurlExtensionMethods
    {
        private static RestClient AttachGeneratorHandler(this RestClient client, StrongBox<string> curlScript)
        {
            var handler = new CurlGeneratorHandler(new HttpClientHandler(), curlScript);
            var newHttpClient = new HttpClient(handler);
            handler.HttpClient = newHttpClient;

            client.SetHttpClientField(newHttpClient);
            return client;
        }

        private static void SetHttpClientField(this RestClient client, HttpClient httpClient)
        {
            FieldInfo httpClientField=Utils.GetHttpClientField();
            httpClientField.SetValue(client, httpClient);
        }

        private static HttpClient GetHttpClientField(this RestClient client)
        {
            FieldInfo httpClientField=Utils.GetHttpClientField();
            return httpClientField.GetValue(client) as HttpClient;
        }



        public static string GetCurl(this RestClient client, RestRequest request)
        {
            var curlScript = new StrongBox<string>();
            HttpClient oldHttpClient = client.GetHttpClientField();
            var _ = client.AttachGeneratorHandler(curlScript).Execute(request);
            client.SetHttpClientField(oldHttpClient);  //reattach the old client before returning
            return curlScript.Value;
        }
    }
}