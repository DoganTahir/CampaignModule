using CampaignModuleApi.Data;

namespace CampaignModuleApi.BusinessServices
{
    public class ProductBusiness
    {
        public Boolean UpdateProductPrice(string productCode,int discount)
        {
            using (var db = new DataBaseContext())
            {
                var product = db.Products.FirstOrDefault(s => s.ProductCode == productCode);
                if (product == null)
                    return false;
             
                product.DiscountedPrice = (product.Price * discount) / 100;

                db.SaveChanges();
                return true;
            }
        }
    }
}


