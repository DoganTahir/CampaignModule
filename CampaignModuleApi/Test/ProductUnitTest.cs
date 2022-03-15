using CampaignModuleApi.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CampaignModuleApi.Test
{

    public class ProductUnitTest
    {
        [Fact]
        public void UpdateProductPrice()
        {
            // Arrange
            string productCode = "P54";
            int  discount = 50;
            ProductBusiness productBusiness = new ProductBusiness();
            // Act
            Boolean result = productBusiness.UpdateProductPrice(productCode, discount);
            // Assert
            Assert.Equal(true, result);

        }


    }
}

