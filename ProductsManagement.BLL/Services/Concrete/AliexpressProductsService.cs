using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

namespace ProductsManagement.BLL.Services.Concrete;

public class AliexpressProductsService : IMarketplaceProductsService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public AliexpressProductsService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductSearchResponse>> SearchAsync(string query, int page, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["q"] = query,
            ["page"] = page.ToString(),
            ["sort"] = "default",
            ["locale"] = "en_US", 
            ["currency"] = "USD"
        };
        if(region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_search", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedSearchResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<AliexpressSearchResult>>(
            responseContent, "result.resultList");
        return searchContent.Select(_mapper.Map<AliexpressSearchResult, ProductSearchResponse>);
    }
    
    public async Task<ProductDetailResponse> ProductDetailAsync(string productId, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["itemId"] = productId
        };
        if(region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_detail", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDetailResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var productDetail = JsonParseHelper.ObjectFromJsonPropertyName<AliexpressProductDetailResult>(
            responseContent, "result.item");
        return _mapper.Map<AliexpressProductDetailResult, ProductDetailResponse>(productDetail);
    }
    
    public async Task<IEnumerable<ProductSearchResponse>> SearchByImage(string imgUrl, string? sort, string? categoryId, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["imgUrl"] = imgUrl
        };
        if(sort != null)
            parameters.Add("sort", sort);
        if(categoryId != null)
            parameters.Add("categoryId", categoryId);
        if(region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_search_image", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDetailResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<AliexpressSearchResult>>(
            responseContent, "result.resultList");
        return searchContent.Select(_mapper.Map<AliexpressSearchResult, ProductSearchResponse>);
    }
}