namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

public class AmazonProductDetailForOfferResult
{
    public PriceNested Price { get; set; } = null!;
    
    public ReviewsNested Reviews { get; set; }
    
    public SoldByNested SoldBy { get; set; }

    public class PriceNested
    {
        public string Amount { get; set; } = null!;
    }
    
    public class ReviewsNested
    {
        public float? AvgRating { get; set; }
    }
    
    public class SoldByNested
    {
        public string? Availability { get; set; }
    }
}