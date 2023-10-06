using System.Reflection;
using Mono.Reflection;
using RestSharp;

namespace RestSharpToCurl
{
    public static class Utils
    {
        public static FieldInfo GetHttpClientField()
        {
            PropertyInfo httpClientProperty = typeof(RestClient).GetProperty ("HttpClient", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo httpClientField = httpClientProperty.GetBackingField();
            return httpClientField;
        }
    }
}