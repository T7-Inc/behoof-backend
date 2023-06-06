namespace ProductsManagement.BLL.DTO.Requests;

public class LikedProductRequest
{
    public string UserId { get; set; } = null!;
    public int ProductId { get; set; }
}