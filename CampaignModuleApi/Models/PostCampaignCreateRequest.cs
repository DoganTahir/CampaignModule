using CampaignModuleApi.Models.Database;

namespace CampaignModuleApi.Models
{
    public class PostCampaignCreateRequest
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public Product Product { get; set; }
        public int ManipulationLimit { get; set; }
        public int TargetCount { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignFinishDate { get; set; }
        public int CampaignStatus { get; set; }
    }
}
