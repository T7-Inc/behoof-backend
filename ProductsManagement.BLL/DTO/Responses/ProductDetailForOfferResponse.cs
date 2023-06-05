namespace ProductsManagement.BLL.DTO.Responses;

public class ProductDetailForOfferResponse
{
    public float? ProductPrice { get; set; }
    
    public string? ShippingFrom { get; set; }
    
    public float? ShippingPrice { get; set; }

    public float? SellerRating { get; set; }
    
    public bool Available { get; set; }
}