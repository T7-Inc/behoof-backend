namespace ProductsManagement.BLL.DTO.Responses;

public class ProductDetailResponse
{
    public string ProductId { get; set; } = null!;
    
    public string Title { get; set; } = null!;

    public IList<string> Images { get; set; } = null!;
    
    public string CategoryId { get; set; } = null!;
}