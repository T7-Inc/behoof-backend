namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

public class AmazonSearchResult
{
    public string Asin { get; set; } = null!;

    public string Title { get; set; } = null!;

    public List<string> Images { get; set; } = null!;
    
    public Price ProductPrice { get; set; } = null!;

    public class Price
    {
        public string Amount { get; set; } = null!;
        
        public string ListPrice { get; set; } = null!;
        
        public string Currency { get; set; } = null!;
        
        public string Symbol { get; set; } = null!;
    }
}