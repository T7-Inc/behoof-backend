namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

public class AmazonSearchResult
{
    public string Asin { get; set; } = null!;

    public string Title { get; set; } = null!;

    public List<ImageNested> Images { get; set; } = null!;
    
    public PriceNested Price { get; set; } = null!;

    public class ImageNested
    {
        public string Image { get; set; }
    }

    public class PriceNested
    {
        public string Amount { get; set; } = null!;
    }
}