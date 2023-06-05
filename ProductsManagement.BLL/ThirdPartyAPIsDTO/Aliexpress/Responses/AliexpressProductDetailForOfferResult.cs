namespace ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

public class AliexpressProductDetailForOfferResult
{
    public NestedSeller Seller { get; set; } = null!;
    public NestedDelivery Delivery { get; set; } = null!;
    public NestedItem Item { get; set; } = null!;

    public class NestedDelivery
    {
        public string ShippingFrom { get; set; } = null!;

        public IList<NestedShippingItem> ShippingList { get; set; } = null!;

        public class NestedShippingItem
        {
            public string ShippingFee { get; set; } = null!;
        }
    }

    public class NestedSeller
    {
        public string StoreRating { get; set; } = null!;
    }

    public class NestedItem
    {
        public NestedSku Sku { get; set; } = null!;
        
        public class NestedSku
        {
            public NestedDef Def { get; set; } = null!;

            public class NestedDef
            {
                public int Quantity { get; set; }
                public string? PromotionPrice { get; set; }
            }
        }
    }
}