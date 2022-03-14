namespace CampaignModuleApi.Models.Database
{
    public class Order
    {
        public int OrderId { get; set; }

        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
