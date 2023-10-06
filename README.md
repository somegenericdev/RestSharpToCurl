# RestSharpToCurl

[![Get me on](https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/SomeGenericDev.RestSharpToCurl)

A tiny and hacky library that uses reflection and [DelegatingHandlers](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.delegatinghandler) to generate a cURL script out of RestSharp's requests.

```csharp
var client = new RestClient();
var request = new RestRequest("http://localhost:9001/anEndpoint", Method.Get);
request.AddParameter(Parameter.CreateParameter("aKey", "aValue",ParameterType.GetOrPost));
var curl = client.GetCurl(request);
Console.WriteLine(curl);
```
