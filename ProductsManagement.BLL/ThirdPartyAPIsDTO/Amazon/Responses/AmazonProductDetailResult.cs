namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

public class AmazonProductDetailResult
{
    public string Asin { get; set; }

    public string Title { get; set; }

    public IList<ImageNested> Images { get; set; }

    public class ImageNested
    {
        public string Hi_res {get; set; }
    }
}