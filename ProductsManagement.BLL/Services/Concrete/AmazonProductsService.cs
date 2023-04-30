using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

namespace ProductsManagement.BLL.Services.Concrete;

public class AmazonProductsService : IAmazonProductsService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public AmazonProductsService(HttpClient httpClient, IMapper mapper)
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
        
        var uri = QueryHelpers.AddQueryString("search/", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Amazon/storedSearchResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
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

        var uri = QueryHelpers.AddQueryString("product/", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        // var r = new StreamReader("StoredJsonAPIResponses/Amazon/storedProductDetailResponse.json");
        // var responseContent = await r.ReadToEndAsync();

        var productDetail = JsonConvert.DeserializeObject<AmazonProductDetailResult>(responseContent);
        if (productDetail == null)
            throw new JsonException("Unsuccessful json deserialization");
            
        return _mapper.Map<AmazonProductDetailResult, ProductDetailResponse>(productDetail);
    }

    public async Task<ProductDetailForOfferResponse> ProductDetailForOfferAsync(string productId, string? region, int? n)
    {
        var parameters = new Dictionary<string, string>
        {
            ["asin"] = productId,
        };
        if (region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("product/", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Amazon/storedProductDetailForOfferResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var productDetail = JsonConvert.DeserializeObject<AmazonProductDetailForOfferResult>(responseContent);
        if (productDetail == null)
            throw new JsonException("Unsuccessful json deserialization");

        var result = 
            _mapper.Map<AmazonProductDetailForOfferResult, ProductDetailForOfferResponse>(productDetail);
        return result;
    }
}