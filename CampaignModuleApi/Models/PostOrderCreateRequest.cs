namespace CampaignModuleApi.Models
{
    public class PostOrderCreateRequest
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }

    }
}
