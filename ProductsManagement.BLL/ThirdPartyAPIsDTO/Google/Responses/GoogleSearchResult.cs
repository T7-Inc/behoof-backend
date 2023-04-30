namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Google.Responses;

public class GoogleSearchResult
{
    public int Position { get; set; }
    public string Title { get; set; } = null!;
    public string Link { get; set; } = null!;
    public string Source { get; set; } = null!;
    public PriceNested? Price { get; set; } = null!;
    public string Thumbnail { get; set; } = null!;

    public class PriceNested
    {
        public string Value { get; set; } = null!;
    }
}