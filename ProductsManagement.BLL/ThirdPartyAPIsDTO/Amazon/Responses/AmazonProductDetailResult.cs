namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

public class AmazonProductDetailResult
{
    public string Asin { get; set; }

    public string Title { get; set; }

    public IEnumerable<ImageNested> Images { get; set; }
    
    public IEnumerable<string> Features { get; set; }
    
    public string Brand { get; set; }
    
    public NestedInfo Info {get; set; }
    
    public IEnumerable<NestedDictionary> Extra_info { get; set; }
    
    public IEnumerable<NestedDictionary> Overview { get; set; }

    public class ImageNested
    {
        public string Hi_res {get; set; }
    }
    
    public class NestedInfo
    {
        public string Dimensions { get; set; }
        
        public string Weight { get; set; }
    }
    
    public class NestedDictionary
    {
        public string Name { get; set; }
        
        public string Value { get; set; }
    }
}