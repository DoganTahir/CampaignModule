using CampaignModuleApi.BusinessServices;
using CampaignModuleApi.Data;
using CampaignModuleApi.Models;
using CampaignModuleApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CampaignModuleApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBusiness orderBusiness = new OrderBusiness();


        [SwaggerOperation(Summary = "Adds new Orders", Tags = new[] { "Product" })]
        [HttpPost("/orders")]
        [SwaggerResponse(200, "Order created successfully", typeof(void))]
        public IActionResult Post([FromBody] PostOrderCreateRequest data)
        {
            if(orderBusiness.updateStock(data.ProductCode,data.Quantity)==false)
            {
                 return this.StatusCode(460, "Stock Information Incorrect or incorrect");
            }
            using (var db = new DataBaseContext())
            {
                db.Add(new Order
                {
                    ProductCode = data.ProductCode,
                    Quantity = data.Quantity,
                    OrderTime = data.OrderTime

                });
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
