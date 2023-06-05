namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

public class AliexpressProductDescriptionResult
{
    public NestedProperties Properties { get; set; }
    
    public NestedDescription Description { get; set; }
    
    public class NestedProperties
    {
        public IEnumerable<NestedList> List { get; set; }
        
        public class NestedList
        {
            public string Name { get; set; }
            
            public string Value { get; set; }
        }
    }

    public class NestedDescription
    {
        public IEnumerable<string> Images { get; set; }
        
        public IEnumerable<string> Text { get; set; }
    }
}