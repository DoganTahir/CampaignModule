namespace CampaignModuleApi.Models
{
    public class PostProductCreateRequest
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Status { get; set; }
        public decimal DiscountedPrice { get; set; }


    }
}
