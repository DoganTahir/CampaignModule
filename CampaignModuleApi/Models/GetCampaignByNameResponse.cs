namespace CampaignModuleApi.Models
{
    public class GetCampaignByNameResponse
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
        public string CampaignStatus { get; set; }
    }
}
