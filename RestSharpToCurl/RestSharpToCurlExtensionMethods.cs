using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mono.Reflection;
using RestSharp;

namespace RestSharpToCurl
{

    public static class RestSharpToCurlExtensionMethods
    {
        public static RestClient GenerateCurl(this RestClient client,ref StrongBox<string> curlScript)
        {
            PropertyInfo httpClientProperty = typeof (RestClient).GetProperty ("HttpClient", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo httpClientField = httpClientProperty.GetBackingField();

            var handler = new CurlGeneratorHandler(new HttpClientHandler(),ref curlScript);
            var newHttpClient = new HttpClient(handler);
            handler.HttpClient = newHttpClient;
            httpClientField.SetValue (client, newHttpClient );
            return client;
        }
    }
}
