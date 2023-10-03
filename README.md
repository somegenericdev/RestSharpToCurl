# RestSharpToCurl
A tiny and hacky library that uses reflection to generate a curl script out of RestSharp's requests.

```csharp
var client = new RestClient();
var request = new RestRequest("http://localhost:9001/anEndpoint", Method.Get);
request.AddParameter(Parameter.CreateParameter("aKey", "aValue",ParameterType.GetOrPost));

var curlScript = new StrongBox<string>();
var response = client.GenerateCurl(ref curlScript).Execute(request);
Console.WriteLine(curlScript.Value);
```