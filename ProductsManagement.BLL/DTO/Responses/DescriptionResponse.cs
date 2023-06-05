namespace ProductsManagement.BLL.DTO.Responses;

public class DescriptionResponse
{
    public Dictionary<string, string> Properties { get; set; }

    public string Text { get; set; } = null!;
        
    public IEnumerable<string> Images { get; set; }
}