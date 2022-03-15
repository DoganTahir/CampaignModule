using CampaignModuleApi.Data;
using CampaignModuleApi.Models.Database;

namespace CampaignModuleApi.BusinessServices
{
    public class CampaignBusiness
    {
        public string CheckCampaignTime(DateTime incresedTime)
        {
            List<Campaign> campaigns;

            using (var db = new DataBaseContext())
            {
                    campaigns = db.Campaigns.Where(s =>
                    s.CampaignStatus == 1 || s.CampaignFinishDate<incresedTime ).ToList();
                foreach (var campaign in campaigns)
                {
                    campaign.CampaignStatus = 0;
                }
                db.SaveChanges();
            }
            return null;
        }
        public string UpdateCampaignStatus(DateTime incresedTime)
        {
            List<Campaign> campaigns;

            using (var db = new DataBaseContext())
            {
                campaigns = db.Campaigns.Where(s =>
                s.CampaignStatus == 1 || s.CampaignFinishDate < incresedTime).ToList();
                foreach (var campaign in campaigns)
                {
                    campaign.CampaignStatus = 0;
                }
                db.SaveChanges();
            }
            return null;

        }
    }
}
