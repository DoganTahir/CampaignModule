using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignModuleApi.Models.Database
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int ManipulationLimit { get; set; }
        public int TargetCount { get; set; }
        public int TotalSales { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignFinishDate { get; set; }
        public decimal Turnover { get; set; }
        public int CampaignStatus { get; set; }


    }
}