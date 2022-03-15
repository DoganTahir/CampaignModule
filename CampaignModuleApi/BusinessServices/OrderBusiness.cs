using CampaignModuleApi.Data;

namespace CampaignModuleApi.BusinessServices
{
    public class OrderBusiness
    {
        public Boolean updateStock(string productCode,int quantity)
        {
            using (var db = new DataBaseContext())
            {
                var product = db.Products.FirstOrDefault(s => s.ProductCode == productCode);
                var campaign = db.Campaigns.FirstOrDefault(s => s.ProductCode == productCode);

                if (product == null)
                    return false;
                if (product.Stock >= quantity)
                {
                    product.Stock = (product.Stock - quantity);

                    if (campaign !=null)
                    {
                         if(campaign.CampaignStatus == 1)
                        {
                            campaign.Turnover = product.DiscountedPrice * quantity;
                            campaign.TotalSales = campaign.TotalSales+ quantity;
                        }
                    }
                    db.SaveChanges();
                    return true;
                }
            }
                return false;
            }
        }
    }

