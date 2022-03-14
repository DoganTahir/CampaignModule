
namespace CampaignModuleApi.Models.Database
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductCode { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}