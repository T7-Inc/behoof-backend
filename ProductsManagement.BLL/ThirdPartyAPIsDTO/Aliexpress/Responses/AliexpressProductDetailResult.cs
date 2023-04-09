namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

public class AliexpressProductDetailResult
{
    public string ItemId { get; set; }

    public string Title { get; set; }

    public IList<string> Images { get; set; }
    
    public string CatId { get; set; }
}