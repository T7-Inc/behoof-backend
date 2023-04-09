namespace ProductsManagement.BLL.DTO.Responses;

public class ProductSearchResponse
{
    public string ImageUrl { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public float PriceUSD { get; set; }
    
    public string ProductId { get; set; } = null!;
    
    public string Url { get; set; } = null!;
}