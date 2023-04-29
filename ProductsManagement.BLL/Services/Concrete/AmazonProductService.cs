using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

namespace ProductsManagement.BLL.Services.Concrete;

public class AmazonProductService : IMarketplaceProductsService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public AmazonProductService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductSearchResponse>> SearchAsync(string query, int page, string? region)
    {
        var parameters = new Dictionary<string, string>()
        {
            ["keywords"] = query,
            ["page"] = page.ToString(),
        };
        if(region != null)
            parameters.Add("region", region);
        
        // var uri = QueryHelpers.AddQueryString("search/", parameters);
        // var response = await _httpClient.GetAsync(uri);
        // response.EnsureSuccessStatusCode();
        // var responseContent = await response.Content.ReadAsStringAsync();
        
        var r = new StreamReader("StoredJsonAPIResponses/Amazon/storedSearchResponse.json");
        var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<AmazonSearchResult>>(
            responseContent, "results");
        return searchContent.Select(_mapper.Map<AmazonSearchResult, ProductSearchResponse>);
        
    }

    public async Task<ProductDetailResponse> ProductDetailAsync(string productId, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["asin"] = productId,
        };
        if (region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_detail", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDetailResponse.json");
        // var responseContent = await r.ReadToEndAsync();

        var productDetail = JsonParseHelper.ObjectFromJsonPropertyName<AmazonProductDetailResult>(
            responseContent, "result.item");
        return _mapper.Map<AmazonProductDetailResult, ProductDetailResponse>(productDetail);
    }
}