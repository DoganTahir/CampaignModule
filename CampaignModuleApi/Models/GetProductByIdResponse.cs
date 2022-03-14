namespace CampaignModuleApi.Models
{
    public class GetProductByIdResponse
    {
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        
        public int Status { get; set; }
    }
}
