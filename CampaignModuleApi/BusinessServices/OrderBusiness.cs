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
                if (product == null)
                    return false;
                if (product.Stock >= quantity)
                {
                    product.Stock = (product.Stock - quantity);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
