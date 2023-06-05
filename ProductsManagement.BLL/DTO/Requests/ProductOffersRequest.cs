namespace ProductsManagement.BLL.DTO.Requests;

public class ProductOffersRequest
{
    public string ProductImageUrl { get; set; } = null!;
    
    public string? Region { get; set; }
}