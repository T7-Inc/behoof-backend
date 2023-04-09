namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

public class AliexpressSearchResult
{
    public ItemNested Item { get; set; } = null!;

    public class ItemNested
    {
        public string ItemId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Image { get; set; } = null!;
        public SkuNested Sku { get; set; } = null!;

        public class SkuNested
        {
            public DefNested Def { get; set; } = null!;

            public class DefNested
            {
                public float PromotionPrice { get; set; }
            }
        }
    }
}