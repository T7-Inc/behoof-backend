using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Google.Responses;

namespace ProductsManagement.BLL.Services.Concrete;

public class GoogleSearchService : IGoogleSearchService
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public GoogleSearchService(IConfiguration configuration, HttpClient httpClient)
    {
        _apiKey = configuration["ThirdPartyAPIs:GoogleAPI:Key"];
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<GoogleSearchResult>> SearchByImage(string imgUrl)
    {
        var parameters = new Dictionary<string, string>
        {
            ["api_key"] = _apiKey,
            ["engine"] = "google_lens",
            ["url"] = imgUrl,
            ["hl"] = "en"
        };

        var uri = QueryHelpers.AddQueryString("search.json", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Google/storedSearchByImage.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<GoogleSearchResult>>(
            responseContent, "visual_matches");
        return searchContent;
    }
}