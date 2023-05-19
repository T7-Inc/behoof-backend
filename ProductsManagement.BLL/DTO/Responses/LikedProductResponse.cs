namespace ProductsManagement.BLL.DTO.Responses;

public class LikedProductResponse
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Url { get; set; }
}