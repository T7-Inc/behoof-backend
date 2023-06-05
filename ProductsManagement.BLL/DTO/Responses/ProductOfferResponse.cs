namespace ProductsManagement.BLL.DTO.Responses;

public class ProductOfferResponse
{
    public string ImgUrl { get; set; } = null!;

    public string? SellerRating { get; set; }

    public string? ShippingFrom { get; set; }
    
    public string? ShippingTo { get; set; }

    public float? ShippingPrice { get; set; }

    public float ProductPrice { get; set; }

    public float TotalPrice { get; set; }
    
    public bool? Available { get; set; }
    
    public string SellerUrl { get; set; } = null!;
}