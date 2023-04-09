using Newtonsoft.Json.Linq;

namespace ProductsManagement.BLL.Helpers;

public static class JsonParseHelper
{
    public static T ObjectFromJsonPropertyName<T>(string json,string jsonPropertyName)
    {                      
        var parsedResult= JObject.Parse(json);

        var token = parsedResult.SelectToken(jsonPropertyName)!;
        var obj = token.ToObject<T>()!;
        return obj;
    }
}