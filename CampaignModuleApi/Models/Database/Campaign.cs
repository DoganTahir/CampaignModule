using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignModuleApi.Models.Database
{
    public class Campaign
    {
        public int CampaignId{get;set;}
        public string Name {get;set;}
        public int ProductCode { get; set; }
        public Product Product { get; set; }
        public int Duration{get;set;}
        public int ManipulationLimit{get;set;}
        public int TargetCount{get;set;}
    }
}